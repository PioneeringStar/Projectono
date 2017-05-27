using System;
using Projectono.Environment;
using System.Threading.Tasks;
using Projectono.Environment.Adaptors;
using System.Windows.Input;
using System.Collections.Generic;
using Projectono.Application.ViewModels;

namespace Projectono.Application.ViewModels
{
	public class Application : ViewModel
	{
        private readonly Stack<PagedViewModel> ViewStack = new Stack<PagedViewModel>();
        public PagedViewModel CurrentView { get { return Get<PagedViewModel>(); } private set { Set(value); } }

        public Application()
        {
        }

        protected override void OnReady()
        {
            Navigate<Splash>();
        }

        public void Navigate<TPage>() where TPage : PagedViewModel
        {
            Navigate(typeof(TPage));
        }

        public void Navigate(Type page)
        {
            if (CurrentView != null) { ViewStack.Push(CurrentView); }
            CurrentView = (PagedViewModel)CreateChild(page);
            CurrentView.OnTerminate += (s, e) => Back();
            CurrentView.OnNavigation += (s, e) => Navigate(e.PageType);
        }

        public void Back()
        {
            CurrentView = ViewStack.Pop();
        }
    }
}
