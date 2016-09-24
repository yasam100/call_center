using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PresentationLayer.Support
{
    public class DatetimeToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string res = null;
            DateTime dt = DateTime.MinValue;
            if (value != null)
                dt = (DateTime)value;

            if(dt>DateTime.MinValue && dt<DateTime.MaxValue)
                res = dt.ToString();
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
