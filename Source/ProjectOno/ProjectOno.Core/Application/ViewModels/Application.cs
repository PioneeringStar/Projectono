using System;
using ProjectOno.Environment;
using System.Threading.Tasks;
using ProjectOno.Environment.Adaptors;
using System.Windows.Input;
using System.Collections.Generic;
using ProjectOno.Application.ViewModels;

namespace ProjectOno.Application.ViewModels
{
	public class Application : ViewModel
	{
        private readonly Stack<IViewModel> ViewStack = new Stack<IViewModel>();
        public IViewModel CurrentView { get { return Get<IViewModel>(); } private set { Set(value); } }

        public Application()
        {
        }

        protected override void OnReady()
        {
            CurrentView = CreateChild<MainMenu>();
        }
    }
}
