﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegistrationSystem.DAL.Concrete;
using RegistrationSystem.DAL.Interfaces;
using RegistrationSystem.Entities;
using RegistrationSystem.WPFUI.ViewModel;

namespace RegistrationSystem.WPFUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginViewModel viewModel = new LoginViewModel(); // this creates an instance of the ViewModel
            this.DataContext = viewModel; // this sets the newly created ViewModel as the DataContext for the View
            if (viewModel.CloseAction == null)
            {
                viewModel.CloseAction = new Action(() => this.Close());
            }
        }

    }
}
