using System;
using UIKit;

namespace AppStore.iOS.Cells
{
    public class CategoryCell : UICollectionViewCell
    {
        public CategoryCell(IntPtr handle) : base(handle)
        {
            SetupViews();
        }

        private void SetupViews()
        {
            BackgroundColor = UIColor.Black;
        }
    }
}