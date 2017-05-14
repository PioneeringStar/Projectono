using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOno.Application.ViewModels.FileLocators
{
    [Dependency.Transient]
    public class TestLocator : FileLocator
    {
        public override void Reset()
        {
            Name = "Test Locator";
        }

        protected override void OnReady() { }
    }
}
