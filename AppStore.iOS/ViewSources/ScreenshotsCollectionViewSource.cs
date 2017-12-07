using System;
using System.Collections;
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

            collectionView.RegisterClassForCell(typeof(ScreenshotImageCell), ScreenshotImageCell.Id);
        }

        public override IEnumerable ItemsSource
        {
            get => base.ItemsSource;
            
            set
            {
                if (value == null)
                    return;

                base.ItemsSource = value;
            }
        }

        #region IUICollectionViewDelegateFlowLayout

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(240, _screenshotsCell.Frame.Height - 28);
        }

        [Export("collectionView:layout:insetForSectionAtIndex:")]
        public virtual UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout, Int32 section)
        {
            return new UIEdgeInsets(0, 14, 0, 14);
        }
        #endregion
    }
}