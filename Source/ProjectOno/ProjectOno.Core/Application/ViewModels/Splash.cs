using ProjectOno.Environment;

namespace ProjectOno.Application.ViewModels
{
    public class Splash : PagedViewModel
    {
        public EventCommand ViewReady { get { return Get<EventCommand>(); } set { Set(value); } }

        public Splash() {
            ViewReady = new EventCommand();
            ViewReady.CommandExecuted += (s, e) => Navigate<MainMenu>();
        }

        protected override void OnReady() { }
    }
}
