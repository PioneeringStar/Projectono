using System;
using Android.App;
using Android.Views;
using Xamarin.Forms;
using ProjectOno.Environment;
using ProjectOno.Environment.Adaptors;

namespace ProjectOno.App.Environment.Adaptors
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