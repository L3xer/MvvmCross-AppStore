using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace Appstore.Core.Converters
{
    public class PriceToFormattedPriceValueConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float price = (float)value;
            if (price == 0)
                return string.Empty;

            return string.Format("${0:0.00}", price);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return base.ConvertBack(value, targetType, parameter, culture);
        }
    }
}
