using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ProjectOno.App.Views
{
	public partial class Splash : StackLayout
    {
		public Splash ()
		{
			InitializeComponent ();
			Animate();
		}

		public async void Animate() {
			await LogoImage.FadeTo(1d, 500, Easing.SinOut);
			await LogoImage.FadeTo(1d, 500, Easing.SinOut);
		}
	}
}
