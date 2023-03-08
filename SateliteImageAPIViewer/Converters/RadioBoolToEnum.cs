using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SateliteImageAPIViewer.Converters
{
    public class RadioBoolToEnum : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //string? parameterString = parameter as string;

            //if (parameterString != null)
            //    return DependencyProperty.UnsetValue;

            //if(Enum.IsDefined(value.GetType(),value) == false)
            //    return DependencyProperty.UnsetValue;
            //object parameterValue = Enum.Parse(value.GetType(), parameterString);
            //return parameterString.Equals(value);

            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //string? parameterString = parameter as string;

            //if (parameterString == null)
            //{
            //    return DependencyProperty.UnsetValue;
            //}

            //return Enum.Parse(targetType, parameterString);
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}
