using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReadySet.Core
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Delegates

        public delegate void CloseEventHandler(object sender);
        public delegate void MessageBoxRequestEventHandler(object sender, MessageBoxRequestEventArgs args);

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        public event CloseEventHandler CloseRequest;
        public event MessageBoxRequestEventHandler MessageBoxRequest;

        #endregion

        #region Private functionality

        private void RequestMessage(MessageType messageType, string message, string title)
        {
            if (MessageBoxRequest != null)
                MessageBoxRequest(this, new MessageBoxRequestEventArgs { Message = message, MessageType = messageType, Title = title });
        }

        #endregion

        #region Protected functionality

        protected void Changed<T>(Expression<Func<T>> exp)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs((exp.Body as MemberExpression).Member.Name));
        }

        protected void Close()
        {
            if (CloseRequest != null)
                CloseRequest(this);
        }

        protected void InfoMessage(string message, string title = null)
        {
            RequestMessage(MessageType.Info, message, string.IsNullOrEmpty(title) ? "Info" : title);
        }

        protected void WarningMessage(string message, string title = null)
        {
            RequestMessage(MessageType.Warning, message, string.IsNullOrEmpty(title) ? "Warning" : title);
        }

        protected void ErrorMessage(string message, string title = null)
        {
            RequestMessage(MessageType.Error, message, string.IsNullOrEmpty(title) ? "Error" : title);
        }

        #endregion

        #region Sub types

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

        public enum MessageType { Info, Error, Warning }

        public class MessageBoxRequestEventArgs
        {
            public MessageType MessageType { get; set; }
            public string Message { get; set; }
            public string Title { get; set; }
        }

        #endregion
    }
}
