using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Appstore.Core.Models;
using Appstore.Core.Services;
using Appstore.Core.Extensions;
using Appstore.Core.CellViewModels;


namespace Appstore.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private IAppStoreService _appStoreService;

        public IMvxCommand<StoreApp> AppSelectedCommand { get; private set; }

        public MvxObservableCollection<CategoryCellViewModel> Categories { get; } = new MvxObservableCollection<CategoryCellViewModel>();

        public MainViewModel(IAppStoreService appStoreService)
        {
            _appStoreService = appStoreService;

            AppSelectedCommand = new MvxAsyncCommand<StoreApp>(AppSelectedExecute);
        }

        public override async Task Initialize()
        {
            var categories = await _appStoreService.GetAppCategoriesAsync();

            Categories.Clear();
            Categories.AddRange(categories.ToCategoryCellViewModel(this));
        }

        private async Task AppSelectedExecute(StoreApp app)
        {
            System.Diagnostics.Debug.WriteLine("App selected: " + app.Id);
        }
    }
}
