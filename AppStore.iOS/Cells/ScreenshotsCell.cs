using System;
using UIKit;
using CoreGraphics;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using Appstore.Core.ViewModels;
using AppStore.iOS.ViewSources;


namespace AppStore.iOS.Cells
{
    public class ScreenshotsCell : MvxCollectionViewCell
    {
        public static readonly string Id = "ScreenshotsCellId";

        private UICollectionView collectionView;
        public UICollectionView CollectionView
        {
            get
            {
                if (collectionView == null) {
                    var layout = new UICollectionViewFlowLayout();
                    layout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;

                    collectionView = new UICollectionView(CGRect.Empty, layout) {
                        BackgroundColor = UIColor.Clear,
                        TranslatesAutoresizingMaskIntoConstraints = false
                    };
                }

                return collectionView;
            }
        }

        private ScreenshotsCollectionViewSource _source;

        public ScreenshotsCell(IntPtr handle) : base(handle)
        {
            SetupViews();
            SetupBindings();
        }

        private void SetupViews()
        {
            AddSubview(CollectionView);

            _source = new ScreenshotsCollectionViewSource(this, CollectionView, ScreenshotImageCell.Id);
            CollectionView.Source = _source;

            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v0]|", 0, "v0", CollectionView));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[v0]|", 0, "v0", CollectionView));
        }

        private void SetupBindings()
        {
            this.DelayBind(() => {
                var set = this.CreateBindingSet<ScreenshotsCell, AppDetailViewModel>();
                set.Bind(_source).To(vm => vm.Screenshots);
                set.Apply();
            });
        }
    }
}