using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using Appstore.Core.Models;
using Appstore.Core.Converters;
using AppStore.iOS.Converters;


namespace AppStore.iOS.Cells
{
    public class AppDetailHeaderCell : MvxCollectionViewCell
    {
        public static readonly string Id = "AddDetailHeaderId";

        private UIImageView imageView;
        public UIImageView ImageView
        {
            get
            {
                if (imageView == null) {
                    imageView = new UIImageView();
                    imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
                    imageView.Layer.CornerRadius = 16;
                    imageView.Layer.MasksToBounds = true;
                    imageView.TranslatesAutoresizingMaskIntoConstraints = false;
                }

                return imageView;
            }
        }

        private UISegmentedControl segmentedControl;
        public UISegmentedControl SegmentedControl
        {
            get
            {
                if (segmentedControl == null) {
                    segmentedControl = new UISegmentedControl(new string[] { "Details", "Reviews", "Related" }) {
                        TintColor = UIColor.DarkGray,
                        SelectedSegment = 0,
                        TranslatesAutoresizingMaskIntoConstraints = false
                    };
                }

                return segmentedControl;
            }
        }

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

        private UIButton buyButton;
        public UIButton BuyButton
        {
            get
            {
                if (buyButton == null) {
                    buyButton = new UIButton(UIButtonType.System);
                    buyButton.Layer.BorderColor = UIColor.FromRGB(0, 129, 205).CGColor;
                    buyButton.Layer.BorderWidth = 1;
                    buyButton.Layer.CornerRadius = 5;
                    buyButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(14);
                    buyButton.TranslatesAutoresizingMaskIntoConstraints = false;
                }

                return buyButton;
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


        public AppDetailHeaderCell(IntPtr handle) : base(handle)
        {
            SetupViews();
            SetupBindings();
        }

        private void SetupViews()
        {
            AddSubview(ImageView);
            AddSubview(SegmentedControl);
            AddSubview(NameLabel);
            AddSubview(BuyButton);
            AddSubviews(DividerLineView);

            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-14-[v0(100)]-8-[v1]|", 0, "v0", ImageView, "v1", NameLabel));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-14-[v0(100)]", 0, "v0", ImageView));

            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-14-[v0(20)]", 0, "v0", NameLabel));

            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-40-[v0]-40-|", 0, "v0", SegmentedControl));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:[v0(34)]-8-|", 0, "v0", SegmentedControl));

            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:[v0(60)]-14-|", 0, "v0", BuyButton));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:[v0(32)]-56-|", 0, "v0", BuyButton));

            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v0]|", 0, "v0", DividerLineView));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:[v0(0.5)]|", 0, "v0", DividerLineView));
        }

        private void SetupBindings()
        {
            this.DelayBind(() => {
                var set = this.CreateBindingSet<AppDetailHeaderCell, StoreApp>();
                set.Bind(NameLabel).To(a => a.Name);
                set.Bind(BuyButton).For("Title").To(a => a.Price).WithConversion(new PriceToFormattedPriceValueConverter());
                set.Bind(ImageView).For(iv => iv.Image).To(a => a.ImageName).WithConversion(ImageNameToUIImageValueConverter.Instance);
                set.Apply();
            });
        }
    }
}