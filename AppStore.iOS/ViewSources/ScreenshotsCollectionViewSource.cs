using System;
using UIKit;
using Foundation;
using CoreGraphics;
using MvvmCross.Binding.iOS.Views;
using AppStore.iOS.Cells;


namespace AppStore.iOS.ViewSources
{
    public class ScreenshotsCollectionViewSource : MvxCollectionViewSource, IUICollectionViewDelegateFlowLayout
    {
        private ScreenshotsCell _screenshotsCell;

        public ScreenshotsCollectionViewSource(ScreenshotsCell screenshotsCell, UICollectionView collectionView, string cellId) : base(collectionView, new NSString(cellId))
        {
            _screenshotsCell = screenshotsCell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 5;
        }

        #region IUICollectionViewDelegateFlowLayout

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(200, _screenshotsCell.Frame.Height - 28);
        }

        [Export("collectionView:layout:insetForSectionAtIndex:")]
        public virtual UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout, Int32 section)
        {
            return new UIEdgeInsets(0, 14, 0, 14);
        }
        #endregion
    }
}