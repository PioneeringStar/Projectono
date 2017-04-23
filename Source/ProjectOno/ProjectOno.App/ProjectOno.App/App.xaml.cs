using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ProjectOno.App
{
	public partial class App : Xamarin.Forms.Application
	{
		public App ()
		{
			InitializeComponent();

            var Application = Bootstrap.StartApplication();
			MainPage = new MainPage {
                BindingContext = Application
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
