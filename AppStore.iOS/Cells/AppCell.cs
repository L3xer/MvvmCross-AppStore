using System;
using UIKit;

namespace AppStore.iOS.Cells
{
    public class AppCell : UICollectionViewCell
    {
        public AppCell(IntPtr handle) : base(handle)
        {
            SetupViews();
        }

        private void SetupViews()
        {
            BackgroundColor = UIColor.Black;
        }
    }
}