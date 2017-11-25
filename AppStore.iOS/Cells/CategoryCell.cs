using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace AppStore.iOS.Cells
{
    public class CategoryCell : UICollectionViewCell, IUICollectionViewDataSource, IUICollectionViewDelegate, IUICollectionViewDelegateFlowLayout
    {
        private string cellId = "appCellId";

        private UICollectionView appsCollectionView;
        public UICollectionView AppsCollectionView
        {
            get
            {
                if (appsCollectionView == null) {
                    var layout = new UICollectionViewFlowLayout();
                    layout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;

                    appsCollectionView = new UICollectionView(CGRect.Empty, layout);

                    appsCollectionView.BackgroundColor = UIColor.Clear;
                    appsCollectionView.TranslatesAutoresizingMaskIntoConstraints = false;
                }

                return appsCollectionView;
            }
        }

        public CategoryCell(IntPtr handle) : base(handle)
        {
            SetupViews();
        }

        private void SetupViews()
        {
            BackgroundColor = UIColor.Clear;

            AddSubview(AppsCollectionView);

            AppsCollectionView.WeakDataSource = this;
            AppsCollectionView.Delegate = this;

            AppsCollectionView.RegisterClassForCell(typeof(AppCell), cellId);


            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v0]|", 0, "v0", AppsCollectionView));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[v0]|", 0, "v0", AppsCollectionView));
        }

        public nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 5;
        }

        public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return collectionView.DequeueReusableCell(cellId, indexPath) as AppCell;
        }

        #region IUICollectionViewDelegateFlowLayout

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(100, Frame.Height);
        }

        #endregion
    }
}