using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOno.Application.ViewModels.Locators
{
    [Dependency.Transient]
    public class WebLocator : FileLocator
    {
        public string Url { get { return Get<string>(); } set { Set(value); } }
        public string WebUrl { get { return Get<string>(); } set { Set(value); } }
        public EventCommand NavigateBack { get { return Get<EventCommand>(); } set { Set(value); } }
        public EventCommand UserNavigation { get { return Get<EventCommand>(); } set { Set(value); } }

        public WebLocator()
        {
            Name = "Download From Web";
            Url = "http://www.google.com";
            WebUrl = Url;
            NavigateBack = new EventCommand();
        }

        public override void Reset() { }

        protected override void OnReady() { }

        public void UrlSet(object sender, System.EventArgs e)
        {
            WebUrl = Url;
        }

        public void Navigation(object sender, NavigationEventArgs e)
        {
        }

        public class NavigationEventArgs : System.EventArgs
        {
            public bool Cancel { get; set; }
            public string Url { get; set; }
        }
    }
}
