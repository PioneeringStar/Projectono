using ProjectOno.Environment;
using System.IO;

namespace ProjectOno.Application.ViewModels.FileLocators
{
    public interface IFileLocator : IViewModel
    {
        string Name { get; }
        string SelectedFileName { get; }
        Stream SelectedFileContent { get; }
        EventCommand Start { get; }
        EventCommand FileFound { get; }
        EventCommand FindCancelled { get; }
        void Reset();
    }

    public abstract class FileLocator : ViewModel, IFileLocator
    {
        public string Name { get { return Get<string>(); } set { Set(value); } }
        public string SelectedFileName { get { return Get<string>(); } set { Set(value); } }
        public Stream SelectedFileContent { get { return Get<Stream>(); } set { Set(value); } }
        public EventCommand Start { get { return Get<EventCommand>(); } set { Set(value); } }
        public EventCommand FileFound { get { return Get<EventCommand>(); } set { Set(value); } }
        public EventCommand FindCancelled { get { return Get<EventCommand>(); } set { Set(value); } }
        public abstract void Reset();

        protected FileLocator()
        {
            Start = new EventCommand(this);
            FileFound = new EventCommand(this);
            FindCancelled = new EventCommand(this);
        }
    }
}
