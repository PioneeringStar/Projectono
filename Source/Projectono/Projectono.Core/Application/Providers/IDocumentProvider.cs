using Projectono.Environment;
using System.IO;
using System;
using System.Threading.Tasks;

namespace Projectono.Application.Providers
{
	/// <summary>
	/// A singleton provider allowing app-wide disassociated access to a single document.<br />
	/// File loading components will set the IDocumentProvider information<br />
	/// File reading components will retrieve the current application document from the IDocumentProvider
	/// </summary>
	public interface IDocumentProvider
    {
        /// <summary>
        /// Should represent the file and file origin in a human readable way.<br />
        /// e.g. a file path with file name would denote both the file name and its origin to a user.
        /// </summary>
        string File { get; set; }

        /// <summary>
        /// Retrieves a new accessor to the current application document. <br />
        /// This method should support multiple concurrent requests.
        /// </summary>
        Stream GetFileContent();

        /// <summary>
        /// Sets the content of the current application document. <br />
        /// This should operate asynchronously
        /// </summary>
        Task SetFileContent(Stream source);

        /// <summary>
        /// Alerts existing consumers that the current application document has been updated. <br />
        /// Note: This may fire asynchronously after the SetFileContent method has completed.
        /// </summary>
        event EventHandler DocumentUpdated;
    }

    [Dependency.Singleton]
    public class DocumentProvider : IDocumentProvider
    {
        private byte[] _content = new byte[0];
        public string File { get; set; }

        public Stream GetFileContent() {
            return new MemoryStream(_content);
        }

        public async Task SetFileContent(Stream source) {
            // TODO: To support large files: First ask why. Next write a less memory intensive provider.
            await source.ReadAsync(_content = new byte[source.Length], 0, (int)source.Length);
            if (DocumentUpdated != null) { DocumentUpdated(this, null); }
        }

        public event EventHandler DocumentUpdated;
    }
}
