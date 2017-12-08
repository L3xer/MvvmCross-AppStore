using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using Appstore.Core.ViewModels;
using AppStore.iOS.Converters;

namespace AppStore.iOS.Cells
{
    public class AppDetailDescriptionCell : MvxCollectionViewCell
    {
        public static readonly string Id = "AppDetailDescriptionCellId";

        private UITextView textView;
        public UITextView TextView
        {
            get
            {
                if (textView == null) {
                    textView = new UITextView {
                        TranslatesAutoresizingMaskIntoConstraints = false
                    };
                }

                return textView;
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

        public AppDetailDescriptionCell(IntPtr handle) : base(handle)
        {
            SetupViews();
            SetupBindings();
        }

        private void SetupViews()
        {
            AddSubview(TextView);
            AddSubview(DividerLineView);

            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-8-[v0]-8-|", 0, "v0", TextView));
            AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-14-[v0]|", 0, "v0", DividerLineView));

            AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-4-[v0]-4-[v1(1)]|", 0, "v0", TextView, "v1", DividerLineView));
        }


        private void SetupBindings()
        {
            this.DelayBind(() => {
                var set = this.CreateBindingSet<AppDetailDescriptionCell, AppDetailViewModel>();
                set.Bind(TextView).For(t => t.AttributedText).To(vm => vm.AppDetailDescription).WithConversion(AppDetailDescriptionToAttributedTextConverter.Instance);
                set.Apply();
            });
        }

    }
}