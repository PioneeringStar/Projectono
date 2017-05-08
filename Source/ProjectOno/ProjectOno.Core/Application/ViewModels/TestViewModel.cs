using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOno.Application.ViewModels
{
    public class TestViewModel : PagedViewModel
    {
        public EventCommand CloseTestPage { get { return Get<EventCommand>(); } set { Set(value); } }

        protected override void OnReady() {
            TestText = "Value Appropriately Bound";
            CloseTestPage = new EventCommand();
            CloseTestPage.CommandExecuted += (s, e) => Terminate();
        }

        public string TestText { get { return Get<string>(); } set { Set(value); } }
    }
}
