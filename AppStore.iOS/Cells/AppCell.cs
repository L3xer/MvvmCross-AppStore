using System;
using UIKit;
using Foundation;
using CoreGraphics;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using Appstore.Core.Models;
using Appstore.Core.Converters;
using AppStore.iOS.Controls;
using AppStore.iOS.Converters;


namespace AppStore.iOS.Cells
{
    public class AppCell : MvxCollectionViewCell
    {
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
                }

                return imageView;
            }
        }

        private SALabel nameLabel;
        public SALabel NameLabel
        {
            get
            {
                if (nameLabel == null) {
                    nameLabel = new SALabel {
                        Lines = 2,
                        Font = UIFont.SystemFontOfSize(14)
                    };
                }

                return nameLabel;
            }
        }

        private UILabel categoryLabel;
        public UILabel CategoryLabel
        {
            get
            {
                if (categoryLabel == null) {
                    categoryLabel = new UILabel {
                        TextColor = UIColor.DarkGray,
                        Font = UIFont.SystemFontOfSize(13)
                    };
                }

                return categoryLabel;
            }
        }

        private UILabel priceLabel;
        public UILabel PriceLabel
        {
            get
            {
                if (priceLabel == null) {
                    priceLabel = new UILabel {
                        TextColor = UIColor.DarkGray,
                        Font = UIFont.SystemFontOfSize(13)
                    };
                }

                return priceLabel;
            }
        }

        public AppCell(IntPtr handle) : base(handle)
        {
            SetupViews();
            SetupBindings();
        }

        private void SetupViews()
        {
            AddSubview(ImageView);
            AddSubview(NameLabel);
            AddSubview(CategoryLabel);
            AddSubview(PriceLabel);

            ImageView.Frame = new CGRect(0, 0, Frame.Width, Frame.Width);
            NameLabel.Frame = new CGRect(0, Frame.Width + 2, Frame.Width, 40);
            CategoryLabel.Frame = new CGRect(0, Frame.Width + 38, Frame.Width, 20);
            PriceLabel.Frame = new CGRect(0, Frame.Width + 56, Frame.Width, 20);

            NameLabel.TextUpdated += (object sender, EventArgs e) => {
                UpdateLayout();
            };
        }


        private void SetupBindings()
        {
            this.DelayBind(() => {
                var set = this.CreateBindingSet<AppCell, StoreApp>();
                set.Bind(NameLabel).For(l => l.LabelText).To(a => a.Name);
                set.Bind(CategoryLabel).To(a => a.Category);
                set.Bind(PriceLabel).To(a => a.Price).WithConversion(new PriceToFormattedPriceValueConverter());
                set.Bind(ImageView).For(iv => iv.Image).To(a => a.ImageName).WithConversion(new ImageNameToUIImageValueConverter());
                set.Apply();
            });
        }

        private void UpdateLayout()
        {
            var rect = new NSString(NameLabel.LabelText).GetBoundingRect(
                new CGSize(Frame.Width, 1000),
                NSStringDrawingOptions.UsesFontLeading | NSStringDrawingOptions.UsesLineFragmentOrigin,
                new UIStringAttributes() { Font = UIFont.SystemFontOfSize(14) },
                null);

            if (rect.Height > 20) {
                CategoryLabel.Frame = new CGRect(0, Frame.Width + 38, Frame.Width, 20);
                PriceLabel.Frame = new CGRect(0, Frame.Width + 56, Frame.Width, 20);
            } else {
                CategoryLabel.Frame = new CGRect(0, Frame.Width + 22, Frame.Width, 20);
                PriceLabel.Frame = new CGRect(0, Frame.Width + 40, Frame.Width, 20);
            }

            NameLabel.Frame = new CGRect(0, Frame.Width + 5, Frame.Width, 40);
            NameLabel.SizeToFit();
        }
    }
}