using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Appstore.Core.Models;
using Appstore.Core.Services;
using Appstore.Core.Extensions;

namespace Appstore.Core.ViewModels
{
    public class AppDetailViewModel : MvxViewModel<StoreApp>
    {
        public StoreApp StoreApp { get; set; }
        public MvxObservableCollection<string> Screenshots { get; } = new MvxObservableCollection<string>();

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

            Screenshots.ReplaceRange(StoreApp.Screenshots);
        }
    }
}
