using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOno.Application.ViewModels
{
    public abstract class PagedViewModel : ViewModel
    {
        protected virtual void Terminate() {
            if (OnTerminate != null) { OnTerminate(this, null); }
        }

        public event EventHandler OnTerminate;

        protected virtual void Navigate<TPage>() where TPage : PagedViewModel {
            if (OnNavigation != null) { OnNavigation(this, new PageEventArgs(typeof(TPage))); }
        }

        public event EventHandler<PageEventArgs> OnNavigation;

        public class PageEventArgs : System.EventArgs
        {
            public Type PageType { get; private set; }
            public PageEventArgs(Type pageType) { PageType = pageType; }
        }
    }
}
