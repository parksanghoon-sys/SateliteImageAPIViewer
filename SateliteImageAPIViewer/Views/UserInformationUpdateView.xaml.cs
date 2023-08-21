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

namespace SateliteImageAPIViewer.Views
{
    /// <summary>
    /// UserInformationUpdateView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserInformationUpdateView : UserControl
    {
        public UserInformationUpdateView()
        {
            InitializeComponent();
        }

        private void xTextPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
                xTextPassword.Visibility = Visibility.Collapsed;
            else
                xTextPassword.Visibility = Visibility.Visible;
        }
    }
}
