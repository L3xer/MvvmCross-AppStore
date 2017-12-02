using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using Appstore.Core.ViewModels;
using AppStore.iOS.Cells;
using AppStore.iOS.ViewSources;


namespace AppStore.iOS.Views
{
    public class MainView : MvxCollectionViewController<MainViewModel>
    {
        public MainView() : base(new UICollectionViewFlowLayout())
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CollectionView.BackgroundColor = UIColor.White;
            CollectionView.RegisterClassForCell(typeof(CategoryCell), CategoryCell.Id);
            CollectionView.RegisterClassForCell(typeof(LargeCategoryCell), LargeCategoryCell.Id);

            var source = new CategoriesCollectionViewSource(this, CollectionView, CategoryCell.Id);
            CollectionView.Source = source;

            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(source).To(vm => vm.Categories);
            set.Apply();
        }
    }
}