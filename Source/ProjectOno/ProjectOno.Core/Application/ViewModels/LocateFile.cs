using ProjectOno.Application.Providers;
using ProjectOno.Application.ViewModels.FileLocators;
using ProjectOno.Environment;
using System.IO;

namespace ProjectOno.Application.ViewModels
{
    public class LocateFile : PagedViewModel
    {
        protected override void OnReady() { }

        public IFileLocator[] Locators { get { return Get<IFileLocator[]>(); } set { Set(value); } }

        public IViewModel Layout { get { return Get<IViewModel>(); } set { Set(value); } }

        private readonly IDocumentProvider _document;

        public LocateFile(IFileLocator[] locators, IDocumentProvider document)
        {
            _document = document;
            foreach (var locator in locators) {
                locator.Reset();
                locator.Start.CommandExecuted += (s, e) => StartLocator(locator);
                locator.FileFound.CommandExecuted += (s, e) => PrintFile(locator);
                locator.FindCancelled.CommandExecuted += (s, e) => ShowMenu();
            }
            Locators = locators;
            ShowMenu();
        }

        private void StartLocator(IFileLocator locator)
        {
            locator.Reset();
            Layout = locator;
        }

        private void ShowMenu()
        {
            Layout = this;
        }

        private void PrintFile(IFileLocator locator)
        {
            _document.File = locator.SelectedFileName;
            _document.Content = locator.SelectedFileContent;
            Navigate<PrintDocument>();
        }

    }
}
