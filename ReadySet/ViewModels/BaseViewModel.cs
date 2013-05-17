using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReadySet.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Changed<T>(Expression<Func<T>> exp)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs((exp.Body as MemberExpression).Member.Name));
        }

        protected class ActionCommand : ICommand
        {
            Action _action;

            public ActionCommand(Action action) { _action = action; }

            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action();
            }

            #endregion
        }
    }
}
