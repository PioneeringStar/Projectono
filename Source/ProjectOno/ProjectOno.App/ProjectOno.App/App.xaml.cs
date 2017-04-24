using ProjectOno.Application.ViewModels;
using ProjectOno.Environment;
using ProjectOno.Environment.Adaptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace ProjectOno.App
{
	public partial class App : Xamarin.Forms.Application
	{
        private IIocContainer _container;
        private ApplicationViewModel _application;

		public App ()
		{
			InitializeComponent();

            _container = new IocContainer();
            _container.AddSingleton(typeof(IPlatformAdaptor), typeof(PlatformAdaptor));
            Bootstrap.ReflectDependencies(_container, typeof(App).GetTypeInfo().Assembly);
            
			MainPage = new MainPage {
                BindingContext = _application = Bootstrap.StartApplication(_container)
            };
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
