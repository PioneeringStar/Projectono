using Projectono.Application.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectono.Application.ViewModels
{
    public class PrintDocument : PagedViewModel
    {
        protected override void OnReady() { }

        private readonly IDocumentProvider _document;

        public PrintDocument(IDocumentProvider document)
        {
            _document = document;
        }
    }
}
