using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PruebaNivel
{
    public abstract class ViewModelBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler  PropertyChanged;

        protected void OnPropertyChanging([CallerMemberName] string propertyName ="")
        {
            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
