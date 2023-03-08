using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SateliteImageAPIViewer.Views
{
    /// <summary>
    /// SignUpView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();
        }

        private void xPhoneNumber_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPhoneNumber.Focus();
        }
        private void txtId_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text) && txtId.Text.Length > 0)
                xTextId.Visibility = Visibility.Collapsed;
            else
                xTextId.Visibility = Visibility.Visible;
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
                xTextPassword.Visibility = Visibility.Collapsed;
            else
                xTextPassword.Visibility = Visibility.Visible;
        }

        private void xTextId_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtId.Focus();
        }

        private void xTextPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPhoneNumber.Text) && txtPhoneNumber.Text.Length > 0)
            {
                xPhoneNumber.Visibility = Visibility.Collapsed;
                if (!Regex.IsMatch(txtPhoneNumber.Text, @"^01([0|1|6|7|8|9]?)([0-9]{3,4})([0-9]{4})$"))
                {

                }
            }                
            else
                xPhoneNumber.Visibility = Visibility.Visible;
        }

        private void xEmapl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
            {
                xEmail.Visibility = Visibility.Collapsed;

            }
                
            else
                xEmail.Visibility = Visibility.Visible;
        }
    }
}
