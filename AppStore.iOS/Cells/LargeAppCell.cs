using System;
using UIKit;
using Appstore.Core.Models;
using AppStore.iOS.Converters;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;


namespace AppStore.iOS.Cells
{
    public class LargeAppCell : MvxCollectionViewCell
    {
        public static readonly string Id = "LargeAppCellId";

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

        public LargeAppCell(IntPtr handle) : base(handle)
        {
            SetupViews();
            SetupBindings();
        }

        private void SetupViews()
        {
            AddSubview(ImageView);

            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[v0]|", 0, "v0", ImageView));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-2-[v0]-14-|", 0, "v0", ImageView));
        }

        private void SetupBindings()
        {
            this.DelayBind(() => {
                var set = this.CreateBindingSet<LargeAppCell, StoreApp>();
                set.Bind(ImageView).For(iv => iv.Image).To(a => a.ImageName).WithConversion(new ImageNameToUIImageValueConverter());
                set.Apply();
            });
        }
    }
}