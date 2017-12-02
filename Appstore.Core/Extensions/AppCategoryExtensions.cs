using System.Linq;
using System.Collections.Generic;
using Appstore.Core.Models;
using Appstore.Core.ViewModels;
using Appstore.Core.CellViewModels;


namespace Appstore.Core.Extensions
{
    public static class AppCategoryExtensions
    {
        public static IEnumerable<CategoryCellViewModel> ToCategoryCellViewModel(this IEnumerable<AppCategory> categories, MainViewModel viewModel)
        {
            return categories.Select(c => new CategoryCellViewModel { ViewModel = viewModel, Item = c });
        }
    }
}
