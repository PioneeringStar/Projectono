using System;
using Projectono.Environment;
using Projectono.Application.Providers;
using System.Threading.Tasks;

namespace Projectono.Application.ViewModels.Locators
{
    public class FileLocatorLoadStatus : ViewModel
    {
        public float Progress { get { return Get<float>(); } set { Set(value); } }
        protected override void OnReady() { }
        public FileLocatorLoadStatus(IDocumentProvider document)
        {
            var timeout = DateTime.Now + TimeSpan.FromMinutes(5);
            var complete = false;
            document.DocumentUpdated += (s, e) => { complete = true; };
            Task.Factory.StartNew(() => {
                while (!complete && DateTime.Now < timeout && document.Progress < .99f) {
                    Progress = document.Progress * 100;
                    Task.Delay(TimeSpan.FromSeconds(0.5)).Wait();
                }
            });
        }
    }
}
