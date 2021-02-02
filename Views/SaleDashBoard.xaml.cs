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
    /// Interaction logic for SaleDashBoard.xaml
    /// </summary>
    public partial class SaleDashBoard : UserControl
    {
        public SaleDashBoard()
        {
            InitializeComponent();
            //this.AddtocButton.DataContext = new salesDashboardVM();
            //this.finishButton.DataContext = new salesDashboardVM();
            //this.logoutButton.DataContext = new salesDashboardVM();
            //this.LeftDgrid.DataContext = new salesDashboardVM();
            //this.RightDgrid.DataContext = new salesDashboardVM();
            this.DataContext = new salesDashboardVM();
        }

        
    }
}
