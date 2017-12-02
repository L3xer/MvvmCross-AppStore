using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Appstore.Core.Models;
using Appstore.Core.Services;
using Appstore.Core.Extensions;
using Appstore.Core.CellViewModels;


namespace Appstore.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public IMvxCommand<StoreApp> AppSelectedCommand { get; private set; }
        public MvxObservableCollection<CategoryCellViewModel> Categories { get; } = new MvxObservableCollection<CategoryCellViewModel>();

        private IAppStoreService _appStoreService;
        private IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService, IAppStoreService appStoreService)
        {
            _navigationService = navigationService;
            _appStoreService = appStoreService;

            AppSelectedCommand = new MvxAsyncCommand<StoreApp>(AppSelectedExecute);
        }

        public override async Task Initialize()
        {
            var categories = await _appStoreService.GetAppCategoriesAsync();

            Categories.Clear();
            Categories.AddRange(categories.ToCategoryCellViewModel(this));
        }

        private async Task AppSelectedExecute(StoreApp storeApp)
        {
            await _navigationService.Navigate<AppDetailViewModel, StoreApp>(storeApp);
        }
    }
}
