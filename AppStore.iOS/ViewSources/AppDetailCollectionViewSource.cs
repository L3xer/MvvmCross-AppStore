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
        }

        public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, NSString elementKind, NSIndexPath indexPath)
        {
            var header = CollectionView.DequeueReusableSupplementaryView(elementKind, AppDetailHeaderCell.Id, indexPath) as AppDetailHeaderCell;
            header.DataContext = _appDetailView.ViewModel.StoreApp;

            return header;
        }

        [Export("collectionView:layout:referenceSizeForHeaderInSection:")]
        public CGSize GetReferenceSizeForHeader(UICollectionView collectionView, UICollectionViewLayout layout, Int32 section)
        {
            return new CGSize(_appDetailView.View.Frame.Width, 170);
        }
    }
}