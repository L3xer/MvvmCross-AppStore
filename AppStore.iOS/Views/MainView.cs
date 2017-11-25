using System;
using UIKit;
using Foundation;
using CoreGraphics;
using MvvmCross.iOS.Views;
using Appstore.Core.ViewModels;
using AppStore.iOS.Cells;

namespace AppStore.iOS.Views
{
    public class MainView : MvxCollectionViewController<MainViewModel>, IUICollectionViewDelegateFlowLayout
    {
        private readonly string cellId = "CategoryCellId";

        public MainView() : base(new UICollectionViewFlowLayout())
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CollectionView.BackgroundColor = UIColor.White;
            CollectionView.RegisterClassForCell(typeof(CategoryCell), cellId);
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return collectionView.DequeueReusableCell(cellId, indexPath) as CategoryCell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 3;
        }

        #region IUICollectionViewDelegateFlowLayout

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(View.Frame.Width, 230);
        }

        #endregion
    }
}