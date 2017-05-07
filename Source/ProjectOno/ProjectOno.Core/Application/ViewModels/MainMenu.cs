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

        public MainMenu()
        {
            ViewTestPage = new EventCommand();
            ViewSettings = new EventCommand();
        }
    }
}
