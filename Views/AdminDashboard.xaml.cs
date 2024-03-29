﻿using Assignment02.View_Models;
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
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : UserControl
    {
        public AdminDashboard()
        {
            InitializeComponent();
            this.AddPbutton.DataContext = new adminDashboardVM();
            this.DelButton.DataContext = new adminDashboardVM();
            this.ShowPbutton.DataContext = new adminDashboardVM();
            this.LogOutButton.DataContext = new adminDashboardVM();
        }
    }
}
