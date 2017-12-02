using System;
using MvvmCross.Binding.BindingContext;
using AppStore.iOS.ViewSources;
using Appstore.Core.CellViewModels;

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
                var set = this.CreateBindingSet<LargeCategoryCell, CategoryCellViewModel>();
                set.Bind(_appsSource).To(c => c.Item.Apps);
                set.Bind(_appsSource).For(s => s.SelectionChangedCommand).To(c => c.ViewModel.AppSelectedCommand);
                set.Apply();
            });
        }
    }
}