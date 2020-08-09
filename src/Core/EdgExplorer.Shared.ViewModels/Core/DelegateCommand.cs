using System;
using System.Windows.Input;

namespace EdgExplorer.Shared.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _canExecute;

        public DelegateCommand(Action<object> action, Predicate<object> canExecute = null)
            => (_action, _canExecute) = (action, canExecute);

        public bool CanExecute(object parameter)
            => _canExecute?.Invoke(parameter) != false;

        public void Execute(object parameter)
            => _action?.Invoke(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}