using CoreGraphics;
using System;
using UIKit;

namespace AppStore.iOS.Cells
{
    public class AppCell : UICollectionViewCell
    {
        private UIImageView imageView;
        public UIImageView ImageView
        {
            get
            {
                if (imageView == null) {
                    imageView = new UIImageView(UIImage.FromBundle("frozen"));
                    imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
                    imageView.Layer.CornerRadius = 16;
                    imageView.Layer.MasksToBounds = true;
                }

                return imageView;
            }
        }

        private UILabel nameLabel;
        public UILabel NameLabel
        {
            get
            {
                if (nameLabel == null) {
                    nameLabel = new UILabel {
                        Text = "Disney Build It: Frozen",
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
                        Text = "Entertaiment",
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
                        Text = "$3.99",
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
        }
    }
}