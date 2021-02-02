using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Assignment02.View_Models
{
    class BaseViewM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
