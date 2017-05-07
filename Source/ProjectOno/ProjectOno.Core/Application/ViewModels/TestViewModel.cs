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
        protected override void OnReady() {
            TestText = "Value Appropriately Bound";
        }

        public string TestText { get { return Get<string>(); } set { Set(value); } }
    }
}
