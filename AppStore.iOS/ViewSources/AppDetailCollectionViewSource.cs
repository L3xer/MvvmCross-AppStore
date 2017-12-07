using System;
using UIKit;
using Foundation;
using CoreGraphics;
using MvvmCross.Binding.iOS.Views;
using AppStore.iOS.Cells;
using AppStore.iOS.Views;

namespace AppStore.iOS.ViewSources
{
    public class AppDetailCollectionViewSource : MvxCollectionViewSource, IUICollectionViewDelegateFlowLayout
    {
        private AppDetailView _appDetailView;

        public AppDetailCollectionViewSource(AppDetailView appDetailView, UICollectionView collectionView, string cellId) : base(collectionView, new NSString(cellId))
        {
            _appDetailView = appDetailView;

            collectionView.RegisterClassForSupplementaryView(typeof(AppDetailHeaderCell), UICollectionElementKindSection.Header, AppDetailHeaderCell.Id);
            collectionView.RegisterClassForCell(typeof(ScreenshotsCell), ScreenshotsCell.Id);
        }

        public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, NSString elementKind, NSIndexPath indexPath)
        {
            var header = CollectionView.DequeueReusableSupplementaryView(elementKind, AppDetailHeaderCell.Id, indexPath) as AppDetailHeaderCell;
            header.DataContext = _appDetailView.ViewModel.StoreApp;

            return header;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 1;
        }

        protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView, NSIndexPath indexPath, object item)
        {
            var screenshotsCell = collectionView.DequeueReusableCell(ScreenshotsCell.Id, indexPath) as ScreenshotsCell;
            screenshotsCell.DataContext = _appDetailView.ViewModel;

            return screenshotsCell;
        }

        #region IUICollectionViewDelegateFlowLayout
        
        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(_appDetailView.View.Frame.Width, 200);
        }

        [Export("collectionView:layout:referenceSizeForHeaderInSection:")]
        public CGSize GetReferenceSizeForHeader(UICollectionView collectionView, UICollectionViewLayout layout, Int32 section)
        {
            return new CGSize(_appDetailView.View.Frame.Width, 170);
        }

        #endregion
    }
}