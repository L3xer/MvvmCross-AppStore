using System.Threading.Tasks;
using Refit;
using Appstore.Core.Rest.Dtos;

namespace Appstore.Core.Rest
{
    public interface IRestAppStoreService
    {
        [Get("/appstore/featured")]
        Task<FeaturedAppsDto> GetAppCategoriesAsync();
    }
}
