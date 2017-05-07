using ProjectOno.Assets;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectOno.App.Environment
{
    [ContentProperty("Path")]
    public class Asset : IMarkupExtension
    {
        public string Path { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var path = "ProjectOno.Assets." + Path;
            var asset = ImageSource.FromResource(path, AssemblyProvider.Get());
            return asset;
        }
    }
}
