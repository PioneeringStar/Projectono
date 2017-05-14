using ProjectOno.Application.Providers;
using ProjectOno.Environment;
using System.IO;

namespace ProjectOno.Application.ViewModels
{
    public class LocateFile : PagedViewModel
    {
        protected override void OnReady() { }

        public FileLocator[] Locators { get { return Get<FileLocator[]>(); } set { Set(value); } }

        public IViewModel Layout { get { return Get<IViewModel>(); } set { Set(value); } }

        private readonly FileLocatorSelector _selectorLayout = new FileLocatorSelector();
        private readonly IDocumentProvider _document;

        public LocateFile(FileLocator[] locators, IDocumentProvider document)
        {
            _document = document;
            _selectorLayout.Locators = locators;
            foreach (var locator in locators) {
                locator.Reset();
                locator.Start.CommandExecuted += (s, e) => StartLocator(locator);
                locator.FileFound.CommandExecuted += (s, e) => PrintFile(locator);
                locator.FindCancelled.CommandExecuted += (s, e) => ShowMenu();
            }
            Locators = locators;
            ShowMenu();
        }

        private void StartLocator(FileLocator locator)
        {
            locator.Reset();
            Layout = locator;
        }

        private void ShowMenu()
        {
            Layout = _selectorLayout;
        }

        private void PrintFile(FileLocator locator)
        {
            _document.File = locator.SelectedFileName;
            _document.Content = locator.SelectedFileContent;
            Navigate<PrintDocument>();
        }

    }

    public abstract class FileLocator : ViewModel
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

    public class FileLocatorSelector : ViewModel
    {
        protected override void OnReady() { }
        public FileLocator[] Locators { get { return Get<FileLocator[]>(); } set { Set(value); } }
    }
}
