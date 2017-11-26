﻿using CoreGraphics;
using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using Appstore.Core.Models;
using AppStore.iOS.ViewSources;

namespace AppStore.iOS.Cells
{
    public class CategoryCell : MvxCollectionViewCell
    {
        private string cellId = "appCellId";

        private UILabel nameLabel;
        public UILabel NameLabel
        {
            get
            {
                if (nameLabel == null) {
                    nameLabel = new UILabel {
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

        private AppsCollectionViewSource _appsSource;

        public CategoryCell(IntPtr handle) : base(handle)
        {
            SetupViews();
            SetupBindings();
        }

        private void SetupViews()
        {
            BackgroundColor = UIColor.Clear;

            AddSubview(AppsCollectionView);
            AddSubview(DividerLineView);
            AddSubview(NameLabel);

            AppsCollectionView.RegisterClassForCell(typeof(AppCell), cellId);

            _appsSource = new AppsCollectionViewSource(this, AppsCollectionView, cellId);
            AppsCollectionView.Source = _appsSource;


            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-14-[v0]|", 0, "v0", NameLabel));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-14-[v0]|", 0, "v0", DividerLineView));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v0]|", 0, "v0", AppsCollectionView));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[v0(30)][v1][v2(0.5)]|", 0, "v0", NameLabel, "v1", AppsCollectionView, "v2", DividerLineView));
        }

        private void SetupBindings()
        {
            this.DelayBind(() => {
                var set = this.CreateBindingSet<CategoryCell, AppCategory>();
                set.Bind(NameLabel).To(c => c.Name);
                set.Bind(_appsSource).To(c => c.Apps);
                set.Apply();
            });
        }
    }
}