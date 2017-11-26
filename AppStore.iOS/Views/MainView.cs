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
        private readonly string cellId = "CategoryCellId";

        public MainView() : base(new UICollectionViewFlowLayout())
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CollectionView.BackgroundColor = UIColor.White;
            CollectionView.RegisterClassForCell(typeof(CategoryCell), cellId);

            var source = new CategoriesCollectionViewSource(this, CollectionView, cellId);
            CollectionView.Source = source;

            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(source).To(vm => vm.Categories);
            set.Apply();
        }
    }
}