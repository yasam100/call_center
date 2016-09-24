using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PresentationLayer.Support
{
    public class BoolToVisibilityWithParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility res = Visibility.Visible;
            bool isVisible = value == null ? false : (bool)value;
            bool toHide = false;
            string txtParam = parameter == null ? null : parameter.ToString().ToLowerInvariant();

            if (!string.IsNullOrEmpty(txtParam))
            {
                if (txtParam.Contains("opposite"))
                    isVisible = !isVisible;
                if (txtParam.Contains("hide"))
                    toHide = true;
            }

            if (!isVisible)
                res = toHide ? Visibility.Hidden : Visibility.Collapsed;

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
