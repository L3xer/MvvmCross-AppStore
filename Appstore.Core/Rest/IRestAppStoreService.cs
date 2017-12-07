using System.Threading.Tasks;
using Refit;
using Appstore.Core.Models;
using Appstore.Core.Rest.Dtos;


namespace Appstore.Core.Rest
{
    public interface IRestAppStoreService
    {
        [Get("/appstore/featured")]
        Task<FeaturedAppsDto> GetAppCategoriesAsync();

        [Get("/appstore/appdetail?id={id}")]
        Task<StoreApp> GetAppDetailsAsync(int id);
    }
}
