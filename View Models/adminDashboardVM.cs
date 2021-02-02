using Assignment02.Commands;
using Assignment02.Models;
using Assignment02.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Assignment02.View_Models
{
    class adminDashboardVM:BaseViewM
    {
        public myCommand addPcmd { get; set; }
        public myCommand delPcmd { get; set; }
        public myCommand logOcmd { set; get; }
        public myCommand showPcmd { get; set; }

        public adminDashboardVM()
        {
            addPcmd = new myCommand(CanexeAdd, ExeAdd);
            delPcmd = new myCommand(CanexeDel, ExeDel);
            logOcmd = new myCommand(CanexeLog, ExeLog);
            showPcmd = new myCommand(CanexeShow, ExeShow);

        }

        public bool CanexeAdd(object obj)
        {
            var data = obj as object[];
            if (data != null)
            {
                if(!(string.IsNullOrEmpty(data[0].ToString())) && !(string.IsNullOrEmpty(data[1].ToString())) 
                    && !(string.IsNullOrEmpty(data[2].ToString())) && !(string.IsNullOrEmpty(data[3].ToString())))
                {
                    
                    return true;
                }

            }
            else {
                return false;
            }
            return false;
        }

        public bool CanexeDel(object obj)
        {
            if (obj != null && obj.ToString() != "")
                return true;
            
            return false;
        }
        public bool CanexeLog(object obj)
        {
            return true;
        }
        public bool CanexeShow(object obj)
        {
            return true;
        }

        public void ExeAdd(object obj)
        {
            try
            {
                var data = obj as object[];
                Product p = new Product
                {
                    ProductID = Convert.ToInt32(data[0]),
                    ProductName = Convert.ToString(data[1]).Trim(),
                    ProductPrice = (int)Convert.ToDecimal(data[2]),
                    ProductQuantity = Convert.ToInt32(data[3])
                };
                ProductServices addproduct = new ProductServices();
                if (addproduct.AddProductDB(p))
                {
                    MessageBox.Show("Data added to database Successfully");
                }
                else
                {
                    MessageBox.Show("Product cannot be added or item already exists");
                }
                addproduct.closeConnestion();

            }
            catch
            {
                MessageBox.Show("Enter correct Values to Proceed");
            }
        }

        public void ExeDel(object obj)
        {
            try
            {
                var data = obj as string;
                int num = Convert.ToInt32(data);
                ProductServices p = new ProductServices();
                if (p.DelProduct(num))
                {
                    MessageBox.Show("Your Product is deleted");
                }
                else
                {
                    MessageBox.Show("try again you have entered wrong id");
                }
            }
            catch
            {
                MessageBox.Show("Please enter correct form of values as input");
            }

        }

        public void ExeLog(object obj)
        {

            var w = Application.Current.Windows[0];
            w.Content = new startupPage();

        }

        public void ExeShow(object obj)
        {

            var w = Application.Current.Windows[0];
            w.Content = new showProducts();

        }







    }
}
