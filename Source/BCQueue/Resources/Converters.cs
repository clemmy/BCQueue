using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace BCQueue.Resources
{
    /// <summary>
    /// Converts from Skill Level to a color, for use in binding
    /// </summary>
    [ValueConversion(typeof(Member.sl), typeof(Color))]
    public class Converters : IValueConverter
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

    /// <summary>
    /// Returns true if the item is the first item in the itemscontrol
    /// </summary>
    public class IsFirstItemInCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DependencyObject item = (DependencyObject)value;
            ItemsControl ic = ItemsControl.ItemsControlFromItemContainer(item);
            Console.WriteLine((ic.ItemContainerGenerator.IndexFromContainer(item) == 0).ToString());
            return (ic.ItemContainerGenerator.IndexFromContainer(item) == 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
