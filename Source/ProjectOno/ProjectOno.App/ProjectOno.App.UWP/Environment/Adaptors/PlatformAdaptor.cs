using ProjectOno.App;
using ProjectOno.Environment;
using ProjectOno.Environment.Adaptors;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectOno.Environment.Adaptors
{
    [Dependency.Transient]
    public class PlatformAdaptor : IPlatformAdaptor
    {
		public void QuitApplication()
		{
            Application.Current.Exit();
		}

		public void SetFullScreen(bool value)
		{
			throw new NotImplementedException();
		}
	}
}
