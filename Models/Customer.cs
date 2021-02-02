using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Assignment02.Models
{
    class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; //this is an event that helps us in sending notification
        

        //now create a function to fire this above event

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        

        private string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value;  OnPropertyChanged("customerName"); }
        }

        private string password;

        public  string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("password"); }
        }


        private int phonenum;

        public int Phonenum
        {
            get { return phonenum; }
            set { phonenum = value; OnPropertyChanged("phonenum"); }
        }




    }
}

