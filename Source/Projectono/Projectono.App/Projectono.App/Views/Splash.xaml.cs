using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projectono.App.Views
{
	public partial class Splash : StackLayout
    {
        public static BindableProperty OnReadyProperty = BindableProperty.Create("OnReady", typeof(ICommand), typeof(Splash));
        public ICommand OnReady { get { return (ICommand)GetValue(OnReadyProperty); } set { SetValue(OnReadyProperty, value); } }

		public Splash ()
		{
			InitializeComponent ();
            TryAnimate();
		}

        // Xamarin developer's official (apparently) stance on adding an event to let you know when a view lifecycle is complete and is showing on the screen is "You shouldn't need that". So we are going to be a little messy here...
        // https://forums.xamarin.com/discussion/29714/is-there-an-event-that-fires-after-a-page-is-showed
        public void TryAnimate() {
            if (SplashImage == null || OnReady == null) {
                Task.Factory.StartNew(() => {
                    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                    TryAnimate();
                });
            } else {
                SplashImage.Opacity = 0d;
                SplashImage.FadeTo(1d, 2500, Easing.Linear).Wait();
                Task.Delay(TimeSpan.FromSeconds(3)).Wait();
                SplashImage.FadeTo(0d, 1000, Easing.Linear).Wait();
                OnReady.Execute(null);
            }
		}
	}
}
