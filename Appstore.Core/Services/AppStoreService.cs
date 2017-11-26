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
    }
}
