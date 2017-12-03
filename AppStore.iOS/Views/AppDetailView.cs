using UIKit;
using MvvmCross.iOS.Views;
using Appstore.Core.ViewModels;
using AppStore.iOS.Cells;
using AppStore.iOS.ViewSources;


namespace AppStore.iOS.Views
{
    public class AppDetailView : MvxCollectionViewController<AppDetailViewModel>, IUICollectionViewDelegateFlowLayout
    {
        public AppDetailView() : base(new UICollectionViewFlowLayout())
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CollectionView.BackgroundColor = UIColor.White;
            CollectionView.AlwaysBounceVertical = true;
            CollectionView.RegisterClassForSupplementaryView(typeof(AppDetailHeaderCell), UICollectionElementKindSection.Header, AppDetailHeaderCell.Id);

            var source = new AppDetailCollectionViewSource(this, CollectionView, AppDetailHeaderCell.Id);
            CollectionView.Source = source;
        }
    }
}