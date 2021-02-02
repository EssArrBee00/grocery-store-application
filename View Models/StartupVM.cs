using Assignment02.Commands;
using Assignment02.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
namespace Assignment02.View_Models
{
    class StartupVM:BaseViewM
    {
      
        public myCommand adminCmd { set; get; }
        public myCommand customerCmd { set; get; }

        public StartupVM()
        {
            adminCmd = new myCommand(CanexeAdmin, ExeAdmin);
            customerCmd = new myCommand(CanexeCustomer, ExeCutomer);
        }

        public bool CanexeAdmin(object obj)
        {
            return true;
        }

        public void ExeAdmin(object obj)
        {
            var w = Application.Current.Windows[0];
            w.Content = new AdminDashboard();

        }

        public bool CanexeCustomer(object obj)
        {
            return true;
        }

        public void ExeCutomer(object obj)
        {
            var w = Application.Current.Windows[0];
            w.Content = new CustomerMenu();
        }



    }
}
