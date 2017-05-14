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
        public EventCommand NavigateBack { get { return Get<EventCommand>(); } set { Set(value); } }

        public WebLocator()
        {
            Name = "Download From Web";
            Url = "http://www.google.com";
            NavigateBack = new EventCommand();
        }

        public override void Reset() { }

        protected override void OnReady() { }
    }
}
