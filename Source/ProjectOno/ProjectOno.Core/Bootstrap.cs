using System;
using System.Linq;
using System.Reflection;
using ProjectOno.Application.ViewModels;
using ProjectOno.Environment;

namespace ProjectOno
{
	public static class Bootstrap
	{
        public static Application.ViewModels.Application StartApplication(IIocContainer container = null)
        {
            container = container ?? new IocContainer();

            RegisterCustomDependencies(container);
            ReflectDependencies(container, typeof(Bootstrap).GetTypeInfo().Assembly);
            RegisterPlugins(container);

            var application = (Application.ViewModels.Application)container.Resolve(typeof(Application.ViewModels.Application));
            ViewModel.Factory.Configure(application, container, null);
            return application;
        }


        public static void ReflectDependencies(IIocContainer container, Assembly assembly) {
			var dependencies = assembly
				.DefinedTypes
				.Where(t => t.GetCustomAttributes().Any(a => a is Dependency))
				.ToArray();

			foreach (var transient in dependencies.Where(d => d.GetCustomAttributes().Any(a => a is Dependency.Transient))) {
				foreach (var iface in transient.ImplementedInterfaces) {
					container.AddTransient(iface, transient.AsType());
				}
			}

			foreach (var singleton in dependencies.Where(d => d.GetCustomAttributes().Any(a => a is Dependency.Singleton))) {
				object value = null;
				var factory = new Func<object>(() => value ?? (value = container.Resolve(singleton.AsType())));
				foreach (var iface in singleton.ImplementedInterfaces) {
					container.AddFactory(iface, factory);
				}
			}

			foreach (var instance in dependencies.Where(d => d.GetCustomAttributes().Any(a => a is Dependency.Instance))) {
				var value = container.Resolve(instance.AsType());
				container.AddInstance(instance.AsType(), value);
				foreach (var iface in instance.ImplementedInterfaces) {
					container.AddInstance(iface, value);
				}
			}
		}

		private static void RegisterCustomDependencies(IIocContainer container) {
			// TODO: Add custom dependency configurations here
		}

		private static void RegisterPlugins(IIocContainer container) {
			// TODO: Add plugin configuration here
		}
	}
}
