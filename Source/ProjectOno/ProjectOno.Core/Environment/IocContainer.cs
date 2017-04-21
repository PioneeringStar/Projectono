using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProjectOno.Environment
{
    public interface IIocContainer
    {
        void AddFactory(Type type, Func<object> factory);
        void AddInstance(Type type, object instance);
        void AddSingleton(Type type, Type singleton);
        void AddTransient(Type type, Type transient);
        object Resolve(Type type);
        IIocContainer CreateScope();
    }

    public class IocContainer : IIocContainer
    {
        private readonly IocContainer _parent;
        private readonly Dictionary<Type, Func<object>[]> _factories = new Dictionary<Type, Func<object>[]>();

        private IocContainer(IocContainer parent)
        {
            _parent = parent;
            AddInstance(typeof(IIocContainer), this);
        }

        public IocContainer() : this(null) { }

        private Func<object>[] GetFactories(Type type)
        {
            type = type.IsArray ? type.GetElementType() : type;
            return _factories.ContainsKey(type)
                ? _factories[type]
                : _parent.GetFactories(type);
        }

        public bool HasFactory(Type type)
        {
            type = type.IsArray ? type.GetElementType() : type;
            return _factories.ContainsKey(type) || (_parent != null && _parent.HasFactory(type));
        }

        public void AddFactory(Type type, Func<object> factory)
        {
            if (type.IsArray) { throw new ContainerException("Array types can't be added as dependencies"); }
            var wrapper = ManageFactory(factory);
            if (!_factories.ContainsKey(type)) {
                _factories.Add(type, new[] { wrapper });
            } else {
                var existing = _factories[type];
                Array.Resize(ref existing, existing.Length + 1);
                existing[existing.Length - 1] = wrapper;
                _factories[type] = existing;
            }
        }

        public void AddSingleton(Type type, Type singleton)
        {
            object resolution = null;
            AddFactory(type, () => resolution ?? (resolution = Create(singleton)));
        }

        public void AddTransient(Type type, Type transient)
        {
            AddFactory(type, () => Create(transient));
        }

        public void AddInstance(Type type, object instance)
        {
            AddFactory(type, () => instance);
        }

        public object Resolve(Type type)
        {
            var isArray = type.IsArray;
            type = isArray ? type.GetElementType() : type;
            if (!HasFactory(type)) {
                return isArray ? CastArray(type, new[] { Create(type) }) : Create(type);
            }
            var factories = GetFactories(type);
            return isArray
                ? CastArray(type, factories.Select(f => f()).ToArray())
                : factories.First()();
        }

        public IIocContainer CreateScope()
        {
            return new IocContainer(this);
        }

        private object CastArray(Type type, Array values)
        {
            var array = Array.CreateInstance(type, values.Length);
            for (var i = 0; i < array.Length; i++) {
                array.SetValue(values.GetValue(i), i);
            }
            return array;
        }

        private object Create(Type type)
        {
            var info = type.GetTypeInfo();
            var ctors = info
                .DeclaredConstructors
                .Select(c => new { ctor = c, args = c.GetParameters() })
                .ToArray();

            if (ctors.Length == 0) {
                throw new ContainerException(string.Format("Can't create type {0}. No constructors found.", type.Name));
            }

            var match = ctors
                .OrderBy(c => c.args.Length)
                .FirstOrDefault(c => c.args.All(a => HasFactory(a.ParameterType)));
            if (match == null) {
                throw new ContainerException(string.Format("Unable to locate enough dependencies for type {0}", type.Name));
            }

            var args = match.args.Select(p => Resolve(p.ParameterType)).ToArray();
            var resolution = Activator.CreateInstance(type, args);
            return resolution;
        }

        private Func<object> ManageFactory(Func<object> factory)
        {
            return () => {
                try { return factory(); } catch (Exception e) { throw new ContainerException("Error resolving dependency", e); }
            };
        }

        public class ContainerException : Exception
        {
            public ContainerException(string message) : base(message) { }
            public ContainerException(string message, Exception inner) : base(message, inner) { }
        }
    }
}
