using ProjectOno.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectOno.Environment.Adaptors
{
    public class PlatformAdaptor : IPlatformAdaptor
    {
        // TODO: Figure out how this is really done on UWP
        public static App.UWP.MainPage MainPage { get; set; }
        public bool FullScreenEnabled {
            get {
                var value = false;
                Task.WaitAll(
                    MainPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, new Windows.UI.Core.DispatchedHandler(() => {
                        var bars = new[] { MainPage.TopAppBar, MainPage.BottomAppBar }.Where(b => b != null).ToArray();
                        value = !bars.Any(b => b.Visibility == Visibility.Visible);
                    })).AsTask()
                );
                return value;
            }
            set {
                Task.WaitAll(
                    MainPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, new Windows.UI.Core.DispatchedHandler(() => {
                        var bars = new[] { MainPage.TopAppBar, MainPage.BottomAppBar }.Where(b => b != null).ToArray();
                        foreach (var bar in bars) { bar.Visibility = value ? Visibility.Collapsed : Visibility.Visible; }
                    })).AsTask()
                );
            }
        }
    }
}
