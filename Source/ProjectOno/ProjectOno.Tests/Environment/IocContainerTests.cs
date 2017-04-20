using NUnit.Framework;
using ProjectOno.Core.Environment;

namespace ProjectOno.Tests.Environment
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void CanDoInstances()
        {
            var container = new IocContainer();
            var instance = new object();
            container.AddInstance(typeof(object), instance);
            Assert.AreSame(instance, container.Resolve(typeof(object)));
        }

        [Test]
        public void CanDoSingletons()
        {
            var container = new IocContainer();
            container.AddSingleton(typeof(object), typeof(object));
            var first = container.Resolve(typeof(object));
            var second = container.Resolve(typeof(object));
            Assert.AreSame(first, second);
        }

        [Test]
        public void CanDoTransients()
        {
            var container = new IocContainer();
            container.AddTransient(typeof(object), typeof(object));
            var first = container.Resolve(typeof(object));
            var second = container.Resolve(typeof(object));
            Assert.AreNotSame(first, second);
        }

        [Test]
        public void CanDoFactory()
        {
            var container = new IocContainer();
            var index = 1;
            container.AddFactory(typeof(int), () => index++);
            var first = container.Resolve(typeof(int));
            var second = container.Resolve(typeof(int));
            Assert.AreEqual(1, first);
            Assert.AreEqual(2, second);
        }

        [Test]
        public void CanDoParent()
        {
            var parent = new IocContainer();
            parent.AddInstance(typeof(int), 1);
            var child = parent.CreateScope();
            Assert.AreEqual(1, child.Resolve(typeof(int)));
        }

        [Test]
        public void CanDoChild()
        {
            var parent = new IocContainer();
            parent.AddInstance(typeof(int), 1);
            var child = parent.CreateScope();
            child.AddInstance(typeof(int), 2);
            child.AddInstance(typeof(object), 3);
            Assert.AreEqual(2, child.Resolve(typeof(int)));
            Assert.AreEqual(3, child.Resolve(typeof(object)));
        }

        [Test]
        public void CanDoArrays()
        {
            var container = new IocContainer();
            container.AddInstance(typeof(int), 1);
            container.AddInstance(typeof(int), 2);
            var single = (int)container.Resolve(typeof(int));
            var multiple = (int[])container.Resolve(typeof(int[]));
            Assert.AreEqual(1, single);
            Assert.AreEqual(2, multiple.Length);
            Assert.AreEqual(1, multiple[0]);
            Assert.AreEqual(2, multiple[1]);
        }

        [Test]
        public void CanResolveDependencies()
        {
            var container = new IocContainer();
            var instance = new object();
            container.AddInstance(typeof(object), instance);
            container.AddTransient(typeof(DependantObject<object>), typeof(DependantObject<object>));
            var resolution = (DependantObject<object>)container.Resolve(typeof(DependantObject<object>));
            Assert.AreSame(instance, resolution.Dependency);
        }

        [Test]
        public void CanResolveArrays()
        {
            var container = new IocContainer();
            container.AddInstance(typeof(int), 1);
            container.AddInstance(typeof(int), 2);
            var single = (DependantObject<int>)container.Resolve(typeof(DependantObject<int>));
            var multiple = (ArrayDependantObject<int>)container.Resolve(typeof(ArrayDependantObject<int>));
            Assert.AreEqual(1, single.Dependency);
            Assert.AreEqual(2, multiple.Dependencies.Length);
            Assert.AreEqual(1, multiple.Dependencies[0]);
            Assert.AreEqual(2, multiple.Dependencies[1]);
        }

        public class DependantObject<TType>
        {
            public TType Dependency { get; set; }
            public DependantObject(TType dependency) { Dependency = dependency; }
        }

        public class ArrayDependantObject<TType>
        {
            public TType[] Dependencies { get; set; }
            public ArrayDependantObject(TType[] dependencies) { Dependencies = dependencies; }
        }
    }
}
