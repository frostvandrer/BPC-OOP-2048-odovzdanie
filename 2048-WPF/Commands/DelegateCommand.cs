using System;
using System.Windows.Input;

namespace _2048_WPF.Commands
{
    internal class DelegateCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Func<object, bool> _canExecute;

        public DelegateCommand(Action<object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
        }

        /*public DelegateCommand(Func<object, bool> canExecute, Action<object> execute)
        {
            if (canExecute == null)
            {
                throw new ArgumentNullException(nameof(canExecute));
            }
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _canExecute = canExecute;
            _execute = execute;
        }*/

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;//_canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, System.EventArgs.Empty);
            }
        }
    }
}
