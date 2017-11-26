using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Appstore.Core.Models;
using Appstore.Core.Services;

namespace Appstore.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private IAppStoreService _appStoreService;

        public MvxObservableCollection<AppCategory> Categories { get; } = new MvxObservableCollection<AppCategory>();

        public MainViewModel(IAppStoreService appStoreService)
        {
            _appStoreService = appStoreService;
        }

        public override async Task Initialize()
        {
            var categories = await _appStoreService.GetAppCategoriesAsync();

            Categories.Clear();
            Categories.AddRange(categories);
        }
    }
}
