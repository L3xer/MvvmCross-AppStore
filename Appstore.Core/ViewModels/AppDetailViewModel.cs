using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Appstore.Core.Models;
using Appstore.Core.Services;


namespace Appstore.Core.ViewModels
{
    public class AppDetailViewModel : MvxViewModel<StoreApp>
    {
        public StoreApp StoreApp { get; set; }
        private IAppStoreService _appStoreService;

        public AppDetailViewModel(IAppStoreService appStoreService)
        {
            _appStoreService = appStoreService;
        }

        public override void Prepare(StoreApp storeApp)
        {
            StoreApp = storeApp;
        }

        public override async Task Initialize()
        {
            StoreApp = await _appStoreService.GetAppDetailsAsync(StoreApp.Id);
        }
    }
}
