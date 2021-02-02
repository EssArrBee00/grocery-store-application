using Assignment02.Commands;
using Assignment02.Models;
using Assignment02.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Assignment02.View_Models
{
    class customerMenuVM:BaseViewM
    {
        public myCommand LIcmd { get; set; }
        public myCommand SUcmd { get; set; }
        public myCommand bcmd { get; set; }

        public customerMenuVM()
        {
            LIcmd = new myCommand(canLogIn,exeLogIn);
            SUcmd = new myCommand(canSignup, exeSignup);
            bcmd = new myCommand(canBack, exeBack);
        }

        public bool canLogIn(object obj)
        {
            var data = obj as object[];
            var x = data[1] as System.Windows.Controls.PasswordBox;
            if (!(string.IsNullOrEmpty(data[0].ToString())) && !(string.IsNullOrEmpty(x.Password.ToString())))
            {
                return true;
            }

            return false;

        }

        public bool canSignup(object obj)
        {
            var data = obj as object[];
            if ( !(string.IsNullOrEmpty(data[0].ToString())) && !(string.IsNullOrEmpty(data[1].ToString())) && !(string.IsNullOrEmpty(data[2].ToString())))
            {
                return true;
            }
            return false;
        }

        public void exeLogIn(object obj)
        {
            var data = obj as object[];
            var x = data[1] as System.Windows.Controls.PasswordBox;
            CustotmerServices o = new CustotmerServices();
            if (o.CustomerExists(data[0].ToString(), x.Password))
            {
                var w = Application.Current.Windows[0];
                w.Content = new SaleDashBoard();
            }
            else
            {
                MessageBox.Show("Wrong credentials entered please try again");
            }

        }
        public void exeSignup(object obj)
        {
            try
            {
                var data = obj as object[];
                var x = data[1] as System.Windows.Controls.PasswordBox;

                Customer C = new Customer
                {
                    CustomerName = data[0].ToString(),
                    Password = x.Password,
                    Phonenum = Convert.ToInt32(data[2])

                };

                CustotmerServices cs = new CustotmerServices();
                if (cs.AddCustomerDB(C))
                {
                    MessageBox.Show("Successfully added user now LOGIN");
                }
                else
                {
                    MessageBox.Show("User cannot be added due to wrong inputs");
                }
            }
            catch
            {
                MessageBox.Show("Your have entered wrong values");
            }
        }

        public bool canBack(object obj)
        {
            return true;
        }
        public void exeBack(object obj)
        {
            var w = Application.Current.Windows[0];
            w.Content = new startupPage();

        }




    }
}
