using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;


namespace AppStore.iOS.Cells
{
    public class ScreenshotsCell : MvxCollectionViewCell
    {
        public static readonly string Id = "ScreenshotsCellId";

        public ScreenshotsCell(IntPtr handle) : base(handle)
        {
            SetupViews();
        }

        private void SetupViews()
        {
            BackgroundColor = UIColor.Blue;
        }
    }
}