using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectOno.Application.ViewModels
{
    public class MainMenu : PagedViewModel
    {
        protected override void OnReady() { }

        public EventCommand ViewTestPage { get { return Get<EventCommand>(); } private set { Set(value); } }
        public EventCommand ViewSettings { get { return Get<EventCommand>(); } private set { Set(value); } }
        public EventCommand ViewPrint { get { return Get<EventCommand>(); } private set { Set(value); } }
        public EventCommand ViewSearch { get { return Get<EventCommand>(); } private set { Set(value); } }
        public EventCommand ExitApp { get { return Get<EventCommand>(); } private set { Set(value); } }

        public MainMenu()
        {
            ViewTestPage = new EventCommand();
            ViewSettings = new EventCommand();
            ViewPrint = new EventCommand();
            ViewSearch = new EventCommand();
            ExitApp = new EventCommand();

            ViewTestPage.CommandExecuted += (s, e) => Navigate<TestViewModel>();
            ViewSettings.CommandExecuted += (s, e) => Navigate<TestViewModel>();
            ViewPrint.CommandExecuted += (s, e) => Navigate<TestViewModel>();
            ViewSearch.CommandExecuted += (s, e) => Navigate<TestViewModel>();

            // ExitApp.CommandExecuted += (s, e) => // TODO: Create an application exit dependency
        }
    }
}
