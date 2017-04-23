using System;
using ProjectOno.Environment;
using System.Threading.Tasks;

namespace ProjectOno.Application.ViewModels
{
	public class ApplicationViewModel : ViewModel
	{
        public string TestData { get { return Get<string>(); } set { Set(value); } }

        protected override void OnReady() {
            Task.Factory.StartNew(Timer);
		}

        private async void Timer() {
            TestData = DateTime.Now.ToString();
            await Task.Delay(TimeSpan.FromSeconds(1));
            Task.Factory.StartNew(Timer);
        }

        private class Data
        {
            public string Text { get; set; }
        }
	}
}
