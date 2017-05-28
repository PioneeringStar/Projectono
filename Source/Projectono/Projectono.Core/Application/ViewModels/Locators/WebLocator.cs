using Projectono.Environment;
using System.IO;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Projectono.Application.ViewModels.Locators
{
    [Dependency.Transient]
    public class WebLocator : FileLocator
    {
        public string Url { get { return Get<string>(); } set { Set(value); } }
        public string WebUrl { get { return Get<string>(); } set { Set(value); } }
        public EventCommand NavigateBack { get { return Get<EventCommand>(); } set { Set(value); } }
        public EventCommand UserNavigation { get { return Get<EventCommand>(); } set { Set(value); } }

        public WebLocator()
        {
            Name = "Download From Web";
            Url = "http://www.google.com";
            WebUrl = Url;
            NavigateBack = new EventCommand();
        }

        public override void Reset() { }

        protected override void OnReady() { }

        public void UrlSet(object sender, System.EventArgs e)
        {
            WebUrl = Url;
        }

        public void Navigation(object sender, NavigationEventArgs e)
        {
            if (e.Url != null && e.Url.ToLower().EndsWith(".svg")) {
                e.Cancel = true;
                this.SelectedFileName = e.Url;
                this.SelectedFileContent = new WebStream(e.Url);
                this.FileFound.Execute(null);
            } else {
                Url = e.Url;
            }
        }

        public class NavigationEventArgs : System.EventArgs
        {
            public bool Cancel { get; set; }
            public string Url { get; set; }
        }

        private class WebStream : Stream
        {
            private readonly Task _request;
            private Stream _source;

            public WebStream(string url)
            {
                _request = WebRequest
                    .Create(url)
                    .GetResponseAsync()
                    .ContinueWith(t => {
                        _source = t.Result.GetResponseStream();
                    });
            }

            public override bool CanRead { get { _request.Wait(); return _source.CanRead; } }

            public override bool CanSeek { get { _request.Wait(); return _source.CanSeek; } }

            public override bool CanWrite { get { _request.Wait(); return _source.CanWrite; } }

            public override long Length { get { _request.Wait(); return _source.Length; } }

            public override long Position { get { _request.Wait(); return _source.Position; } set { _request.Wait(); _source.Position = value; } }

            public override void Flush() { _request.Wait(); _source.Flush(); }

            public override int Read(byte[] buffer, int offset, int count) { _request.Wait(); return _source.Read(buffer, offset, count); }

            public override long Seek(long offset, SeekOrigin origin) { _request.Wait(); return _source.Seek(offset, origin); }

            public override void SetLength(long value) { _request.Wait(); _source.SetLength(value); }

            public override void Write(byte[] buffer, int offset, int count) { _request.Wait(); _source.Write(buffer, offset, count); }
        }
    }
}
