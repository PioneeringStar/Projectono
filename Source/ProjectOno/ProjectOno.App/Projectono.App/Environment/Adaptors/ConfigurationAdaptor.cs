using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Projectono.Core.Environment.Adaptors;
using Projectono.Environment;

namespace Projectono.App.Environment.Adaptors
{
    [Dependency.Transient]
    public class ConfigurationAdaptor : IConfigurationAdaptor
    {
        public Task<XElement> LoadConfiguration(string name)
        {
            return Task.Factory.StartNew(() => {
				if (!Xamarin.Forms.Application.Current.Properties.ContainsKey("/Configuration/" + name)) return null;
				return XElement.Parse(Xamarin.Forms.Application.Current.Properties["/Configuration/" + name] as string ?? "");
			});
        }

        public Task WriteConfiguration(string name, XElement data)
        {
            return Task.Factory.StartNew(() => {
                if (Xamarin.Forms.Application.Current.Properties.ContainsKey("/Configuration/" + name)) {
                    Xamarin.Forms.Application.Current.Properties.Add("/Configuration/" + name, data.ToString());
                } else {
                    Xamarin.Forms.Application.Current.Properties["/Configuration/" + name] = data.ToString();
                }
			});
        }
    }
}
