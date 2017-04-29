using ProjectOno.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectOno.Application.ViewModels.MainMenu
{
    public interface IMenuItem : IViewModel
    {
        string Name { get; }
        int Order { get; }
        ICommand Start { get; }
        event EventHandler OnStarted;
        IViewModel GetView();
    }
}
