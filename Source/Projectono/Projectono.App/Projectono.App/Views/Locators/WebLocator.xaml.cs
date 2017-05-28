using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projectono.Environment;

using Xamarin.Forms;

namespace Projectono.App.Views.Locators
{
	public partial class WebLocator : ContentView
	{
        public event EventHandler<Projectono.Application.ViewModels.Locators.WebLocator.NavigationEventArgs> Navigation;

		public WebLocator ()
		{
			InitializeComponent ();
            WebView.Navigating += (s, e) => {
                var fwdargs = new Projectono.Application.ViewModels.Locators.WebLocator.NavigationEventArgs {
                    Url = e.Url,
                    Cancel = e.Cancel
                };
                if (Navigation != null) { Navigation(this, fwdargs); }
                e.Cancel = fwdargs.Cancel;
            };
            BindingContextChanged += (s, e) => {
                var vm = BindingContext as Application.ViewModels.Locators.WebLocator;
                if (vm == null) { return; }
                vm.NavigateBack.CommandExecuted += (ss, ee) => {
                    if (WebView.CanGoBack) {
                        WebView.GoBack();
                    }
                };
            };
		}
	}
}
