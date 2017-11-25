using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace AppStore.iOS.Cells
{
    public class CategoryCell : UICollectionViewCell, IUICollectionViewDataSource, IUICollectionViewDelegate, IUICollectionViewDelegateFlowLayout
    {
        private string cellId = "appCellId";

        private UILabel nameLabel;
        public UILabel NameLabel
        {
            get
            {
                if (nameLabel == null) {
                    nameLabel = new UILabel {
                        Text = "Best New Apps",
                        Font = UIFont.SystemFontOfSize(16),
                        TranslatesAutoresizingMaskIntoConstraints = false
                    };
                }

                return nameLabel;
            }
        }


        private UICollectionView appsCollectionView;
        public UICollectionView AppsCollectionView
        {
            get
            {
                if (appsCollectionView == null) {
                    var layout = new UICollectionViewFlowLayout();
                    layout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;

                    appsCollectionView = new UICollectionView(CGRect.Empty, layout) {
                        BackgroundColor = UIColor.Clear,
                        TranslatesAutoresizingMaskIntoConstraints = false
                    };
                }

                return appsCollectionView;
            }
        }

        private UIView dividerLineView;
        public UIView DividerLineView
        {
            get
            {
                if (dividerLineView == null) {
                    dividerLineView = new UIView {
                        BackgroundColor = new UIColor(0.4f, 0.4f),
                        TranslatesAutoresizingMaskIntoConstraints = false
                    };
                }

                return dividerLineView;
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
            AddSubview(DividerLineView);
            AddSubview(NameLabel);

            AppsCollectionView.WeakDataSource = this;
            AppsCollectionView.Delegate = this;

            AppsCollectionView.RegisterClassForCell(typeof(AppCell), cellId);

            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-14-[v0]|", 0, "v0", NameLabel));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-14-[v0]|", 0, "v0", DividerLineView));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v0]|", 0, "v0", AppsCollectionView));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[v0(30)][v1][v2(0.5)]|", 0, "v0", NameLabel, "v1", AppsCollectionView, "v2", DividerLineView));
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
            return new CGSize(100, Frame.Height - 32);
        }

        [Export("collectionView:layout:insetForSectionAtIndex:")]
        public virtual UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout, Int32 section)
        {
            return new UIEdgeInsets(0, 14, 0, 14);
        }

        #endregion
    }
}