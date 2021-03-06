﻿using MahApps.Metro.Controls.Dialogs;
using SoundOryc.Desktop.ViewModel;
using System;
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

namespace SoundOryc.Desktop.View
{
    /// <summary>
    /// Interaction logic for RegisterDialogView.xaml
    /// </summary>
    public partial class RegisterDialogView : CustomDialog
    {
        public RegisterDialogView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).securePassword = ((PasswordBox)sender).SecurePassword; }
        }

        private void rePasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).reSecurePassword = ((PasswordBox)sender).SecurePassword; }
        }
    }
}
