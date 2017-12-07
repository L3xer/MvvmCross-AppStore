using System;
using UIKit;
using Foundation;
using CoreGraphics;
using MvvmCross.Binding.iOS.Views;
using AppStore.iOS.Cells;


namespace AppStore.iOS.ViewSources
{
    public class AppsCollectionViewSource : MvxCollectionViewSource, IUICollectionViewDelegateFlowLayout
    {
        protected CategoryCell _categoryCell;

        public AppsCollectionViewSource(CategoryCell categoryCell, UICollectionView collectionView, string cellId) : base(collectionView, new NSString(cellId))
        {
            _categoryCell = categoryCell;

            collectionView.RegisterClassForCell(typeof(AppCell), AppCell.Id);
        }


        #region IUICollectionViewDelegateFlowLayout

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(100, _categoryCell.Frame.Height - 32);
        }

        [Export("collectionView:layout:insetForSectionAtIndex:")]
        public virtual UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout, Int32 section)
        {
            return new UIEdgeInsets(0, 14, 0, 14);
        }

        #endregion
    }
}