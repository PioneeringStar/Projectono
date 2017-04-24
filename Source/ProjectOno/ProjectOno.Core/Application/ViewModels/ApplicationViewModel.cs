using System;
using ProjectOno.Environment;
using System.Threading.Tasks;
using ProjectOno.Environment.Adaptors;

namespace ProjectOno.Application.ViewModels
{
	public class ApplicationViewModel : ViewModel
	{
        public string TestData { get { return Get<string>(); } set { Set(value); } }

        private readonly IPlatformAdaptor _adaptor;

        public ApplicationViewModel(IPlatformAdaptor adaptor)
        {
            _adaptor = adaptor;
        }

        protected override void OnReady() {
            Task.Factory.StartNew(Timer);
		}

        private async void Timer() {
            TestData = DateTime.Now.ToString();
            await Task.Delay(TimeSpan.FromSeconds(1));
            _adaptor.FullScreenEnabled = true;
            Task.Factory.StartNew(Timer);
        }

        private class Data
        {
            public string Text { get; set; }
        }
	}
}
