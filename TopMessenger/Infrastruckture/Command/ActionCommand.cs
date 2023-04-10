using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TopMessenger.ViewModels.Command
{
    public class ActionCommand : ICommand
    {
        public readonly Action<object> execute;
        public readonly Func<object, bool> canExecute;
        private Action<object> value;

        public event EventHandler CanExecuteChanged
        {
            add=>CommandManager.RequerySuggested += value;
            remove=>CommandManager.RequerySuggested -= value;
        }
        public ActionCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute=execute;
            this.canExecute=canExecute;
        }

        public ActionCommand(Action<object> value)
        {
            this.value=value;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
