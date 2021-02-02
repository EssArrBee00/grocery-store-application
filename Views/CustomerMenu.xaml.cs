using Assignment02.View_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment02.Views
{
    /// <summary>
    /// Interaction logic for CustomerMenu.xaml
    /// </summary>
    public partial class CustomerMenu : UserControl
    {
        public CustomerMenu()
        {
            InitializeComponent();
            this.loginButton.DataContext = new customerMenuVM();
            this.SignupButton.DataContext = new customerMenuVM();
            this.Bbutton.DataContext = new customerMenuVM();
        }

    }
}
