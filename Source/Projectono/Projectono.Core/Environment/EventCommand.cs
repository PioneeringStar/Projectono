using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projectono.Environment
{
    public class EventCommand : ICommand
    {
        private readonly object _sender;

        public EventCommand() { _sender = this; }
        public EventCommand(object sender) { _sender = sender; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return ExecuteCommand != null;
        }

        public void Execute(object parameter)
        {
            if (ExecuteCommand != null) { ExecuteCommand(_sender, null); }
        }

        private event EventHandler ExecuteCommand;

        public event EventHandler CommandExecuted
        {
            add {
                var changed = ExecuteCommand == null;
                ExecuteCommand += value;
                if (changed && CanExecuteChanged != null) { CanExecuteChanged(_sender, null); }
            }
            remove {
                ExecuteCommand -= value;
                if (ExecuteCommand == null && CanExecuteChanged != null) { CanExecuteChanged(_sender, null); }
            }
        }
    }
}
