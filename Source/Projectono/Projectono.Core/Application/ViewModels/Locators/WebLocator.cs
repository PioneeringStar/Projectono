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

        protected override void OnNotification(Notification notification)
        {
            if (notification.MemberName == "WebUrl") { Url = notification.NewValue as string; }
            base.OnNotification(notification);
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
            }
        }

        public class NavigationEventArgs : System.EventArgs
        {
            public bool Cancel { get; set; }
            public string Url { get; set; }
        }

        private class WebStream : Stream
        {
            private readonly Task<Stream> _request;

            public WebStream(string url)
            {
                _request = WebRequest
                    .Create(url)
                    .GetResponseAsync()
                    .ContinueWith(response => {
                        var source = response.Result.GetResponseStream();
                        var stream = new MemoryStream();
                        source.CopyTo(stream);
                        return (Stream)stream;
                    });
            }

            public override bool CanRead { get { _request.Wait(); return _request.Result.CanRead; } }

            public override bool CanSeek { get { _request.Wait(); return _request.Result.CanSeek; } }

            public override bool CanWrite { get { _request.Wait(); return _request.Result.CanWrite; } }

            public override long Length { get { _request.Wait(); return _request.Result.Length; } }

            public override long Position { get { _request.Wait(); return _request.Result.Position; } set { _request.Wait(); _request.Result.Position = value; } }

            public override void Flush() { _request.Wait(); _request.Result.Flush(); }

            public override int Read(byte[] buffer, int offset, int count) { _request.Wait(); return _request.Result.Read(buffer, offset, count); }

            public override long Seek(long offset, SeekOrigin origin) { _request.Wait(); return _request.Result.Seek(offset, origin); }

            public override void SetLength(long value) { _request.Wait(); _request.Result.SetLength(value); }

            public override void Write(byte[] buffer, int offset, int count) { _request.Wait(); _request.Result.Write(buffer, offset, count); }
        }
    }
}
