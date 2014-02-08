using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace Trackboard
{
    /// <summary>
    /// 值转换器，返回SID.jpg文件路径
    /// </summary>
    [ValueConversion(typeof(object), typeof(string))] 
    public class IMGPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format(@"{0}\{1}.jpg", AppDomain.CurrentDomain.BaseDirectory, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
