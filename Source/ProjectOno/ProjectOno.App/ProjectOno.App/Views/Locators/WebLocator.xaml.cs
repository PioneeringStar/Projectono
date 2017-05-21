using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectOno.Environment;

using Xamarin.Forms;

namespace ProjectOno.App.Views.Locators
{
	public partial class WebLocator : ContentView
	{
        public event EventHandler<ProjectOno.Application.ViewModels.Locators.WebLocator.NavigationEventArgs> Navigation;

		public WebLocator ()
		{
			InitializeComponent ();
            WebView.Navigating += (s, e) => {
                var fwdargs = new ProjectOno.Application.ViewModels.Locators.WebLocator.NavigationEventArgs {
                    Url = e.Url,
                    Cancel = e.Cancel
                };
                if (Navigation != null) { Navigation(this, fwdargs); }
                e.Cancel = fwdargs.Cancel;
            };
		}
	}
}
