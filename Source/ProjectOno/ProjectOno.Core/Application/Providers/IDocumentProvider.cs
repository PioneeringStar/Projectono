using ProjectOno.Environment;
using System.IO;

namespace ProjectOno.Application.Providers
{
    public interface IDocumentProvider
    {
        string File { get; set; }
        Stream Content { get; set; }
    }

    [Dependency.Singleton]
    public class DocumentProvider : IDocumentProvider
    {
        public string File { get; set; }
        public Stream Content { get; set; }
    }
}
