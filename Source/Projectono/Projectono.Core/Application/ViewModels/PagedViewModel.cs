using Projectono.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectono.Application.ViewModels
{
    public abstract class PagedViewModel : ViewModel
    {
        public EventCommand Back { get { return Get<EventCommand>(); } protected set { Set(value); } }

        public string BackText { get { return Get<string>(); } set { Set(value); } }

        public PagedViewModel()
        {
            Back = new EventCommand();
            Back.CommandExecuted += (s, e) => Terminate();
            BackText = "<< Back";
        }

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
