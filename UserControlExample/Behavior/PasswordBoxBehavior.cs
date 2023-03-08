using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UserControlExample.Behavior
{
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        public static DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password", typeof(string), typeof(PasswordBoxBehavior), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Password
        {
            get => GetValue(PasswordProperty) as string;
            set { SetValue(PasswordProperty, value);} 
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PasswordChanged += this.OnPasswordChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PasswordChanged -= this.OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                this.Password = passwordBox.Password;
            }
        }
    }
}
