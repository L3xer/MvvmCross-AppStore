using System;
using MvvmCross.Binding.BindingContext;
using AppStore.iOS.ViewSources;
using Appstore.Core.Models;

namespace AppStore.iOS.Cells
{
    public class LargeCategoryCell : CategoryCell
    {
        public static new readonly string Id = "LargeCategoryCellId";

        private LargeAppsCollectionViewSource _appsSource;

        public LargeCategoryCell(IntPtr handle) : base(handle)
        {
            SetupViews();
            SetupBindings();
        }

        private void SetupViews()
        {
            AppsCollectionView.RegisterClassForCell(typeof(LargeAppCell), LargeAppCell.Id);

            _appsSource = new LargeAppsCollectionViewSource(this, AppsCollectionView, LargeAppCell.Id);
            AppsCollectionView.Source = _appsSource;
        }

        private void SetupBindings()
        {
            this.DelayBind(() => {
                var set = this.CreateBindingSet<LargeCategoryCell, AppCategory>();
                set.Bind(_appsSource).To(c => c.Apps);
                set.Apply();
            });
        }
    }
}