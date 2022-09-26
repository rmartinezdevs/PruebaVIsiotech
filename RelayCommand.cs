﻿using System;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaNivel
{
    class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        public RelayCommand (Action <object> execute) : this(execute, null)
        {

        }

        public RelayCommand(Action<object> execute, Predicate <object> canExecute)
        {
            if (null == execute)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return null == _canExecute ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
