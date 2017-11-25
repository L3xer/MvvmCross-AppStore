using MvvmCross.iOS.Views;
using Appstore.Core.ViewModels;
using UIKit;
using Foundation;
using System;

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
        }
    }
}