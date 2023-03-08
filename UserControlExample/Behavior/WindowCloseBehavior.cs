using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserControlExample.Behavior
{
    public class WindowCloseBehavior :Behavior<Window>
    {
        public static readonly DependencyProperty CloseProperty =
            DependencyProperty.RegisterAttached("Close", typeof(bool), typeof(WindowCloseBehavior), new UIPropertyMetadata(false, OnClose));

        public static void SetClose(DependencyObject target , bool value)
        {
            target.SetValue(CloseProperty, value);
        }
        private static void OnClose(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue is bool && (bool)e.NewValue)
            {
                var window = GetWindow(d);
                if (window != null)
                    window.Close();
            }
        }

        private static Window GetWindow(object sender)
        {
            Window window = null;
            if(sender is Window)
            {
                window = sender as Window;
            }
            return window ?? Window.GetWindow(sender as Window);
        }
    }
}
