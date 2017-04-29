using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOno.Application.ViewModels.MainMenu
{
    public class MainMenuViewModel : ViewModel
    {
        public IMenuItem[] Items { get { return Get<IMenuItem[]>(); } private set { Set(value); } }

        public IViewModel SelectedViewModel { get { return Get<IViewModel>(); } private set { Set(value); } }

        public MainMenuViewModel(IMenuItem[] items)
        {
            Items = items;
        }

        protected override void OnReady()
        {
            foreach (var item in Items.OfType<ViewModel>()) {
                AddChild(item);
            }
            foreach (var item in Items) {
                item.OnStarted += (s, e) => {
                    SelectedViewModel = item.GetView();
                };
            }
        }
    }
}
