using System.Globalization;
using System;
using UIKit;
using MvvmCross.Platform.Converters;


namespace AppStore.iOS.Converters
{
    public class ImageNameToUIImageValueConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = (string)value;

            if (string.IsNullOrWhiteSpace(imageName))
                return null;

            return UIImage.FromBundle(imageName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}