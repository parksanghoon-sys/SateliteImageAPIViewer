using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SateliteImageAPIViewer.Helpers
{
    public class PopUpHelper : ContentControl
    {
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(PopUpHelper), new PropertyMetadata(false));
        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }
        static PopUpHelper()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PopUpHelper), new FrameworkPropertyMetadata(typeof(PopUpHelper)));
            BackgroundProperty.OverrideMetadata(typeof(PopUpHelper), new FrameworkPropertyMetadata(CreateDefaultBackground()));
        }

        private static object CreateDefaultBackground()
        {
            return new SolidColorBrush(Colors.Black)
            {
                Opacity = 0.3
            };
        }
    }
}
