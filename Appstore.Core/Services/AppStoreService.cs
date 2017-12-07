using System.Threading.Tasks;
using System.Collections.Generic;
using Refit;
using Appstore.Core.Rest;
using Appstore.Core.Models;


namespace Appstore.Core.Services
{
    public class AppStoreService : IAppStoreService
    {
        public async Task<IEnumerable<AppCategory>> GetAppCategoriesAsync()
        {
            var restAppStoreApiService = RestService.For<IRestAppStoreService>("http://api.letsbuildthatapp.com");
            var featuredAppsDto = await restAppStoreApiService.GetAppCategoriesAsync();

            return featuredAppsDto.Categories;
        }

        public async Task<StoreApp> GetAppDetailsAsync(int id)
        {
            var restAppStoreApiService = RestService.For<IRestAppStoreService>("http://api.letsbuildthatapp.com");
            return await restAppStoreApiService.GetAppDetailsAsync(id);
        }
    }
}
