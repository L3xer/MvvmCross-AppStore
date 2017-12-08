using System;
using System.Globalization;
using UIKit;
using Foundation;
using MvvmCross.Platform.Converters;



namespace AppStore.iOS.Converters
{
    public class AppDetailDescriptionToAttributedTextConverter : IMvxValueConverter
    {
        public static AppDetailDescriptionToAttributedTextConverter Instance = new AppDetailDescriptionToAttributedTextConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string appDetailDescription = (string)value;

            if (string.IsNullOrWhiteSpace(appDetailDescription))
                return null;

            var attributedText = new NSMutableAttributedString("Description\n", new UIStringAttributes { Font = UIFont.SystemFontOfSize(14) });
            var style = new NSMutableParagraphStyle();
            style.LineSpacing = 10;

            var range = new NSRange(0, attributedText.Length);
            attributedText.AddAttribute(UIStringAttributeKey.ParagraphStyle, style, range);

            attributedText.Append(new NSAttributedString(appDetailDescription, new UIStringAttributes { Font = UIFont.SystemFontOfSize(11), ForegroundColor = UIColor.DarkGray }));

            return attributedText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}