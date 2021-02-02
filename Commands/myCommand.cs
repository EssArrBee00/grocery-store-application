using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace Assignment02.Commands
{
    class myCommand : ICommand //implementing Icommand interface
    {
        public event EventHandler CanExecuteChanged  //executes when command manager notices a change in property
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        private Action<object> execute;  //for return type void and parameter object
        private Predicate<object> canExecute; //return type bool

        public myCommand(Predicate<object> canExecute,Action<object> execute) //constructor
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }
        



        public bool CanExecute(object parameter) 
        {
            return this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
