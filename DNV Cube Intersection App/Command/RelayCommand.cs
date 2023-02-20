using System;
using System.Windows.Input;

namespace DNV_Cube_Intersection_App.Command
{
    /// <summary>
    /// Implementation of ICommand
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="canExecute">Is posible to execute predicate</param>
        /// <param name="execute">Execution action</param>
        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="execute">Execution action</param>
        public RelayCommand(Action<object> execute)
        {
            _canExecute = (param) => true;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Determines if the command can be executed
        /// </summary>
        /// <param name="parameter">Context parameter that can be used in the execution</param>
        /// <returns>True if the command can be executed</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        /// <summary>
        /// The action of the command
        /// </summary>
        /// <param name="parameter">Context parameter that can be used in the execution</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
