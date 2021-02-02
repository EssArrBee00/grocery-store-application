using Assignment02.Commands;
using Assignment02.Models;
using Assignment02.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Windows;

namespace Assignment02.View_Models
{
    class showpeoductVM:BaseViewM
    {
        public List<Product> dataFromDB { get; set; }
       

        public myCommand backcmd { get; set; }


        public showpeoductVM()
        {
            backcmd = new myCommand(canBack, exeBack);
            dataFromDB = new List<Product>();
            ShowData();
        }

        public void ShowData()
        {
            ProductServices obj = new ProductServices();
            dataFromDB= obj.GetProdList();
        }

        public bool canBack(object obj)
        {
            return true;
        }
        public void exeBack(object obj)
        {
            var w = Application.Current.Windows[0];
            w.Content = new AdminDashboard();

        }


    }
}
