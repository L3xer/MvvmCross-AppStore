using System.Threading.Tasks;
using System.Collections.Generic;
using Appstore.Core.Models;


namespace Appstore.Core.Services
{
    public interface IAppStoreService
    {
        Task<IEnumerable<AppCategory>> GetAppCategoriesAsync();

        Task<StoreApp> GetAppDetailsAsync(int id);
    }
}
