using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace Appstore.Core.Converters
{
    public class PriceToFormattedPriceValueConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("${0:0.00}", (float)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return base.ConvertBack(value, targetType, parameter, culture);
        }
    }
}
