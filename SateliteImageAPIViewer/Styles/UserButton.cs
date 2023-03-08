using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SateliteImageAPIViewer.Styles
{
    public class UserButton : RadioButton
    {
        static UserButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UserButton),new FrameworkPropertyMetadata(typeof(UserButton)));
        }
    }
}
