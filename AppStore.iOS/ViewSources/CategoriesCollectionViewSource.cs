using UIKit;
using Foundation;
using CoreGraphics;
using MvvmCross.Binding.iOS.Views;
using AppStore.iOS.Views;


namespace AppStore.iOS.ViewSources
{
    public class CategoriesCollectionViewSource : MvxCollectionViewSource, IUICollectionViewDelegateFlowLayout
    {
        private MainView _mainView;

        public CategoriesCollectionViewSource(MainView mainView, UICollectionView collectionView, string cellId) : base(collectionView, new NSString(cellId))
        {
            _mainView = mainView;
        }

        #region IUICollectionViewDelegateFlowLayout

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(_mainView.View.Frame.Width, 230);
        }

        #endregion
    }
}