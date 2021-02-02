using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace Assignment02.Models
{
    class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; //for notification whe change occur

        public void OnPropertyChanged(string name)
        {
            //explore this later
            if (PropertyChanged != null) {
               
                PropertyChanged(this, new PropertyChangedEventArgs(name));

            }

        }

        private int productID;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; OnPropertyChanged("productID"); }
        }


        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged("productName"); }
        }

        private int productQuantity;

        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; OnPropertyChanged("productQuantity"); }
        }

        private int productPrice;

        public int ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; OnPropertyChanged("productPrice"); }
        }











    }
}
