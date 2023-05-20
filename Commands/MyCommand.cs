using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace учет_бюджета4.Commands
{
    public class MyCommand: ICommand
    {
        private readonly Action<object> action;
        private readonly Func<object, bool> canExecute;

        public MyCommand(Action<object> action, Func<object, bool> canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            action?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
