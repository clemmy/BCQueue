using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace BCQueue.Resources
{
    [ValueConversion(typeof(Member.sl), typeof(Color))]
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Member.sl))
                throw new ArgumentException("Value is not of enum type sl.");

            var skillLevel = (Member.sl)value;
            if (skillLevel == Member.sl.Tournament)
                return Colors.Black.ToString();
            else if (skillLevel == Member.sl.Beginner)
                return Colors.MediumSpringGreen.ToString();
            else if (skillLevel == Member.sl.Intermediate)
                return Colors.Khaki.ToString();
            else if (skillLevel == Member.sl.Advanced)
                return Colors.Crimson.ToString();
            else
                return Colors.LightGray.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("The binding mode should be OneWay");
        }
    }
}
