using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjectOno.App.Environment
{
    [ContentProperty("Template")]
    public class ViewModelTemplate
    {
        public Type ViewModelType { get; set; }
        public ControlTemplate Template { get; set; }
    }
}
