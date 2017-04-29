using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectOno.App.Environment
{
    [ContentProperty("Assignments")]
    public class ViewModelSelector
    {
        public IList<Assignment> Assignments { get; private set; }
        public ViewModelSelector() { Assignments = new List<Assignment>(); }
    }

    public class Assignment
    {
        public string ValueA { get; set; }
        public string ValueB { get; set; }
    }
}
