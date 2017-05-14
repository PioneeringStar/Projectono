using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjectOno.Environment.Adaptors;

namespace ProjectOno.Application.ViewModels
{
    public class MainMenu : PagedViewModel
    {
        protected override void OnReady() { }

        public EventCommand ViewTestPage { get { return Get<EventCommand>(); } private set { Set(value); } }
        public EventCommand StartPrint { get { return Get<EventCommand>(); } private set { Set(value); } }

        public MainMenu(IPlatformAdaptor platform)
        {
            BackText = "Quit";
            ViewTestPage = new EventCommand();
            StartPrint = new EventCommand();
            Back = new EventCommand();

            ViewTestPage.CommandExecuted += (s, e) => Navigate<TestViewModel>();
            StartPrint.CommandExecuted += (s, e) => Navigate<LocateFile>();
            Back.CommandExecuted += (s, e) => platform.QuitApplication();
        }
    }
}
