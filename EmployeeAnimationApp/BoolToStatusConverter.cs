using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace EmployeeAnimationApp
{
    public class BoolToStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool status)
            {
                return status ? Brushes.Green : Brushes.Red;
            }
            return Brushes.Gray; 
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; 
        }
    }
}
