/*The MIT License (MIT)

Copyright (c) 2014 Sean/Zhang Xuan

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

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
            return String.Format(@"{0}\{1}.jpg", ConfigurationManager.AppSettings["ImagePath"], value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class DatetimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToString("yyyy-MM-dd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? "♂" : "♀";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(object))]
    public class GradeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			return Meth.GetGradesByStudent(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class ClassConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			return Meth.GetClassName(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(List<KeyValuePair<string, int>>))]
    public class CourseGradeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			var gs = Meth.GetGradesByCourse(value.ToString());


            return new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string,int>("优秀",gs.Count(g => g.GMark >=80)),
                new KeyValuePair<string,int>("良好",gs.Count(g => g.GMark < 80 && g.GMark >= 70)),
                new KeyValuePair<string,int>("及格",gs.Count(g => g.GMark < 70 && g.GMark >= 60)),
                new KeyValuePair<string,int>("不及格",gs.Count(g => g.GMark < 60)),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(object))]
    public class JobConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			return Meth.GetJobBySID(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(object))]
    public class TotalGradeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			var tg = Meth.GetTotalGrade(value.ToString());
            return new { Max = tg.Max(), Min = tg.Min(), Avg = tg.Average(), Data = tg.GroupBy(g => g).Select(p => new { Key = p.Key, Value = p.Count() }) };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(object))]
    public class JobListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			var jb = Meth.GetJobsByCID(value.ToString());
            return new
            {
                Area = jb.GroupBy(j => j.City).Select(p => new { Key = p.Key, Value = p.Count() }),
                Salary = jb.GroupBy(j => j.Salary).Select(p => new { Key = p.Key, Value = p.Count() }),
                Company = jb.GroupBy(j => j.Company).Select(p => new { Key = p.Key, Value = p.Count() })
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
