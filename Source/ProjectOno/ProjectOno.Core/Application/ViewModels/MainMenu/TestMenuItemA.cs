using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectOno.Application.ViewModels.MainMenu
{
    [Dependency.Singleton]
    public class TestMenuItemA : ViewModel, IMenuItem
    {
        public string Name { get { return this.GetType().Name; } }

        public int Order { get { return 1; } }

        public bool Enabled { get { return Get<bool>(); } set { Set(value); } }

        public ICommand Start { get { return Get<ICommand>(); } set { Set(value); } }

        public event System.EventHandler OnStarted;

        public IViewModel GetView()
        {
            return CreateChild<TestViewA>();
        }

        protected override void OnReady()
        {
            Enabled = true;
            Start = new Command(() => {
                if (OnStarted != null) {
                    OnStarted(this, null);
                }
            });
        }

        private class TestViewA : ViewModel
        {
            protected override void OnReady()
            {
            }
        }
    }
}
