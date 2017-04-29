using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectOno.Environment
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null) return _canExecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public Command(Action<object> execute, Func<object, bool> canExecute) { _execute = execute; _canExecute = canExecute; }
        public Command(Action<object> execute, Func<bool> canExecute) : this(execute, p => canExecute()) { }
        public Command(Action execute, Func<object, bool> canExecute) : this(p => execute(), canExecute) { }
        public Command(Action execute, Func<bool> canExecute) : this(p => execute(), p => canExecute()) { }
        public Command(Action<object> execute) : this(execute, (Func<object, bool>)null) { }
        public Command(Action execute) : this(() => execute(), (Func<object, bool>)null) { }
    }
}
