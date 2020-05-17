﻿using SafePassVault.App.Helpers;
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

namespace SafePassVault.App.UserControls
{
    /// <summary>
    /// Interaction logic for ConfirmWithPassword.xaml
    /// </summary>
    public partial class ConfirmWithPasswordDialog : UserControl
    {
        public bool IsPasswordCorrect => Password.Password == Encoding.UTF8.GetString(UserData.BytePassword);

        public ConfirmWithPasswordDialog()
        {
            InitializeComponent();
        }
    }
}