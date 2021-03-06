﻿using UIKit;
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

            NavigationItem.Title = "Featured Apps";

            CollectionView.BackgroundColor = UIColor.White;

            var source = new CategoriesCollectionViewSource(this, CollectionView, CategoryCell.Id);
            CollectionView.Source = source;

            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(source).To(vm => vm.Categories);
            set.Apply();
        }
    }
}