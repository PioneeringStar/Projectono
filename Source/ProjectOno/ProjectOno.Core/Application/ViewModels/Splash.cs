using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOno.Application.ViewModels
{
    public class Splash : PagedViewModel
    {
        public float Fade { get { return Get<float>(); } set { Set(value); } }
        protected override void OnReady() {
            // This is terribly naughty - avoid doing animations in the view-model. Do these in the view's XAML (Storyboards & triggers, etc).
            Task.Factory.StartNew(() => {
                for (var i = 0f; i < 20; i++) {
                    Task.Delay(TimeSpan.FromSeconds(.25)).Wait();
                    Fade += 1f / 20f * i;
                }
                Task.Delay(TimeSpan.FromSeconds(5)).Wait();
                Navigate<MainMenu>();
            });
        }
    }
}
