using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadySet.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Changed<T>(Expression<Func<T>> exp)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs((exp.Body as MemberExpression).Member.Name));
        }
    }
}
