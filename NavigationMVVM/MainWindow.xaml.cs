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

namespace NavigationMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void xTextId_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    txtId.Focus();
        //}

        //private void txtId_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtId.Text) && txtId.Text.Length > 0)
        //        xTextId.Visibility = Visibility.Collapsed;
        //    else
        //        xTextId.Visibility = Visibility.Visible;
        //}

        //private void xTextPassword_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    txtPassword.Focus();
        //}

        //private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
        //        xTextPassword.Visibility = Visibility.Collapsed;
        //    else
        //        xTextPassword.Visibility = Visibility.Visible;
        //}
    }
}
