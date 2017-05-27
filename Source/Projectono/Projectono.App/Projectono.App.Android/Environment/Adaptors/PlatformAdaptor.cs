using System;
using Android.App;
using Android.Views;
using Xamarin.Forms;
using Projectono.Environment;
using Projectono.Environment.Adaptors;

namespace Projectono.App.Environment.Adaptors
{
    [Dependency.Transient]
    public class PlatformAdaptor : IPlatformAdaptor
    {

        public void QuitApplication()
        {
            ((Activity)Forms.Context).FinishAffinity();
        }

        public void SetFullScreen(bool value)
        {
            throw new NotImplementedException();
        }
    }
}