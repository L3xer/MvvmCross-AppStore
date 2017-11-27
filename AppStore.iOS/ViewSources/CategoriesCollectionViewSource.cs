using UIKit;
using Foundation;
using CoreGraphics;
using MvvmCross.Binding.iOS.Views;
using AppStore.iOS.Views;
using AppStore.iOS.Cells;


namespace AppStore.iOS.ViewSources
{
    public class CategoriesCollectionViewSource : MvxCollectionViewSource, IUICollectionViewDelegateFlowLayout
    {
        private MainView _mainView;

        public CategoriesCollectionViewSource(MainView mainView, UICollectionView collectionView, string cellId) : base(collectionView, new NSString(cellId))
        {
            _mainView = mainView;
        }

        protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView, NSIndexPath indexPath, object item)
        {
            if (indexPath.Item == 2) {
                return collectionView.DequeueReusableCell(LargeCategoryCell.Id, indexPath) as LargeCategoryCell;
            } else {
                return collectionView.DequeueReusableCell(CategoryCell.Id, indexPath) as CategoryCell;
            }
        }

        #region IUICollectionViewDelegateFlowLayout

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            if (indexPath.Item == 2) {
                return new CGSize(_mainView.View.Frame.Width, 150);
            }

            return new CGSize(_mainView.View.Frame.Width, 230);
        }

        #endregion
    }
}