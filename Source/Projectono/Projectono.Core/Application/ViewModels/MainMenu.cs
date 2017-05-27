using Projectono.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projectono.Environment.Adaptors;

namespace Projectono.Application.ViewModels
{
    public class MainMenu : PagedViewModel
    {
        protected override void OnReady() { }

        public EventCommand StartPrint { get { return Get<EventCommand>(); } private set { Set(value); } }
        public EventCommand Settings { get { return Get<EventCommand>(); } private set { Set(value); } }

        public MainMenu(IPlatformAdaptor platform)
        {
            BackText = "Quit";
            StartPrint = new EventCommand();
            Settings = new EventCommand();
            Back = new EventCommand();

            StartPrint.CommandExecuted += (s, e) => Navigate<LocateFile>();
            Settings.CommandExecuted += (s, e) => Navigate<TestViewModel>();
            Back.CommandExecuted += (s, e) => platform.QuitApplication();
        }
    }
}
