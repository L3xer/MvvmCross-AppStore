using CoreGraphics;
using Foundation;
using UIKit;
using AppStore.iOS.Cells;


namespace AppStore.iOS.ViewSources
{
    public class LargeAppsCollectionViewSource : AppsCollectionViewSource
    {
        public LargeAppsCollectionViewSource(CategoryCell categoryCell, UICollectionView collectionView, string cellId) : base(categoryCell, collectionView, cellId)
        {

        }

        #region IUICollectionViewDelegateFlowLayout

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public new CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(200, _categoryCell.Frame.Height - 32);
        }

        #endregion
    }
}