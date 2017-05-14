using ProjectOno.Application.Providers;
using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOno.Application.ViewModels
{
    public class LocateFile : PagedViewModel
    {
        protected override void OnReady() { }

        public IFileLocator[] Locators { get { return Get<IFileLocator[]>(); } set { Set(value); } }

        public IViewModel Layout { get { return Get<IViewModel>(); } set { Set(value); } }

        private readonly FileLocatorSelector _selectorLayout = new FileLocatorSelector();
        private readonly IDocumentProvider _document;

        public LocateFile(IFileLocator[] locators, IDocumentProvider document)
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

        private void StartLocator(IFileLocator locator)
        {
            locator.Reset();
            Layout = locator;
        }

        private void ShowMenu()
        {
            Layout = _selectorLayout;
        }

        private void PrintFile(IFileLocator locator)
        {
            _document.File = locator.SelectedFileName;
            _document.Content = locator.SelectedFileContent;
            Navigate<PrintDocument>();
        }

        public interface IFileLocator : IViewModel
        {
            string Name { get; set; }
            string SelectedFileName { get; set; }
            Stream SelectedFileContent { get; set; }
            EventCommand Start { get; set; }
            EventCommand FileFound { get; set; }
            EventCommand FindCancelled { get; set; }
            void Reset();
        }

        private class FileLocatorSelector : ViewModel
        {
            protected override void OnReady() { }
            public IFileLocator[] Locators { get { return Get<IFileLocator[]>(); } set { Set(value); } }
        }
    }
}
