using Android.App;
using Android.Views;
using Xamarin.Forms;

namespace ProjectOno.Environment.Adaptors
{
    public class PlatformAdaptor : IPlatformAdaptor
    {
        private readonly WindowManagerFlags FullscreenFlag = WindowManagerFlags.Fullscreen;
        public bool FullScreenEnabled {
            get {
                return (((Activity)Forms.Context).Window.Attributes.Flags & FullscreenFlag) == FullscreenFlag;
            }
            set {
                var attributes = ((Activity)Forms.Context).Window.Attributes;
                attributes.Flags = value
                    ? attributes.Flags | FullscreenFlag
                    : attributes.Flags & ~FullscreenFlag;
            }
        }
    }
}