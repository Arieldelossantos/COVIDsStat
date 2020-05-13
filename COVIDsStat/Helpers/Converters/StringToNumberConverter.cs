using System;
using System.Globalization;
using Xamarin.Forms;

namespace COVIDsStat.Helpers.Converters
{
    public class StringToNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = (string) value;

            var statValue = 0;
            if (!string.IsNullOrEmpty(stringValue))
            {
                statValue = int.Parse(stringValue);
            }

           return statValue.ToString("N0");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
