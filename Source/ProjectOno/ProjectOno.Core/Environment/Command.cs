using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectOno.Environment
{
    public class EventCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return ExecuteCommand != null;
        }

        public void Execute(object parameter)
        {
            if (ExecuteCommand != null) { ExecuteCommand(this, null); }
        }

        private event EventHandler ExecuteCommand;

        public event EventHandler CommandExecuted
        {
            add {
                var changed = ExecuteCommand == null;
                ExecuteCommand += value;
                if (changed && CanExecuteChanged != null) { CanExecuteChanged(this, null); }
            }
            remove {
                ExecuteCommand -= value;
                if (ExecuteCommand == null && CanExecuteChanged != null) { CanExecuteChanged(this, null); }
            }
        }
    }
}
