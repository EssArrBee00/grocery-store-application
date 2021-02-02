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
    class salesDashboardVM : BaseViewM
    {

        public myCommand addcmd { get; set; }
        public myCommand finishcmd { get; set; } 
        public myCommand logoutcmd { get; set; }

        public List<Product> Plist { get; set; }

        public ObservableCollection<Product> Blist { get; set; }


       

        public salesDashboardVM()
        {
            
            addcmd = new myCommand(CanAdd, ExeAdd);
            finishcmd = new myCommand(Canfinish, Exefinish);
            logoutcmd = new myCommand(canLogout, exeLogout);
            ProductServices obj = new ProductServices();
            Plist = obj.GetProdList();
            Blist = new ObservableCollection<Product>();
      
        }


        public bool CanAdd(object obj)
        {
            
            return true;
        }
        public bool Canfinish(object obj)
        {
            return true;
        }
        public bool canLogout(object obj)
        {
            return true;
        }
        public void ExeAdd(object obj)
        {
            try
            {
                ProductServices s = new ProductServices();
                bool check = false;
                var x = obj as object[];
                int pid = System.Convert.ToInt32(x[0].ToString());
                int q = System.Convert.ToInt32(x[1].ToString());
                for(int i=0; i<Plist.Count;i++)
                {
                    Product t = new Product();

                    if (Plist[i].ProductID == pid && Plist[i] .ProductQuantity >= q)
                    {
                        int val = Plist[i].ProductQuantity - q;
                        t.ProductID = Plist[i].ProductID;
                        t.ProductName = Plist[i].ProductName;
                        t.ProductPrice = Plist[i].ProductPrice;
                        t.ProductQuantity = q;
                        Blist.Add(t);
                        s.UpdateProduct(pid, q);
                        Plist[i].ProductQuantity = val;
                        check = true;
                    
                    
                    }

                }
                if (check == true)
                {

                    
                    MessageBox.Show("Product Added to cart");
                    
                }
                else
                {
                    MessageBox.Show("Product is not availale at the moment try some other time");
                }



            }
            catch
            {
                MessageBox.Show("Please entered correct values donot mess with my programm :)");
            }
         }
        public void Exefinish(object obj)
        {


            int itemq = 0;
            decimal total = 0;
            for (int i = 0; i < Blist.Count; i++)
            {
                total = total + (Blist[i].ProductPrice * Blist[i].ProductQuantity);
                itemq = itemq + Blist[i].ProductQuantity;
            }
            MessageBox.Show($"Dear Customer! \nTotal Items purchased: {itemq} \nGrand Total: {total}PKR");

             //clear cart

            var w = Application.Current.Windows[0];
            w.Content = new SaleDashBoard();

        }
        public void exeLogout(object obj)
        {
            var w = Application.Current.Windows[0];
            w.Content = new CustomerMenu();
        }



    }
}
