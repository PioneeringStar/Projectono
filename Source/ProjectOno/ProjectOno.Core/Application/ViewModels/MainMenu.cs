using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectOno.Application.ViewModels
{
    public class MainMenu : ViewModel
    {
        protected override void OnReady() { }

        public EventCommand RequestSettings { get { return Get<EventCommand>(); } private set { Set(value); } }

        public MainMenu()
        {
            RequestSettings = new EventCommand();
        }
    }
}
