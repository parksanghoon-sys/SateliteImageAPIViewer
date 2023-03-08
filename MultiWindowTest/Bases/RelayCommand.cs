using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiWindowTest.Bases
{
    public class RelayCommand : ICommand
    {
        private Action<object > _execute;
        private Predicate<object> _canExcute;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object> execute)
    : this(execute, DefaultCanExcute)
        {
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExcute)
        {
            _execute = execute;
            _canExcute = canExcute;
        }
        public event EventHandler CanExcuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExcuteChanged += value;                    
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExcuteChanged -= value;
            }
        }
        public bool CanExecute(object? parameter)
        {
            return this._canExcute != null && this._canExcute(parameter);
        }

        public void Execute(object? parameter)
        {
            this._execute(parameter);
        }
        public void OnCanExcuteChanged()
        {
            EventHandler handler = this.CanExecuteChanged;
            if (handler != null)
                handler.Invoke(this, EventArgs.Empty);
        }
        public void Destroy()
        {
            this._canExcute= _ => false;
            this._execute = _ => { return; };
        }
        private static bool DefaultCanExcute(object parameter)
        { return true; }
    }
}
