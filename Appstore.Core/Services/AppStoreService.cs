using System.Threading.Tasks;
using System.Collections.Generic;
using Appstore.Core.Models;


namespace Appstore.Core.Services
{
    public class AppStoreService : IAppStoreService
    {
        public async Task<IEnumerable<AppCategory>> GetAppCategoriesAsync()
        {
            return await Task.Run(() => {
                var bestNewAppsCategory = new AppCategory {
                    Name = "Best New Apps"
                };

                var apps = new List<StoreApp>();

                var frozenApp = new StoreApp {
                    Name = "Disney Build It: Frozen",
                    ImageName = "frozen",
                    Category = "Entertaiment",
                    Price = 3.99f
                };

                apps.Add(frozenApp);
                bestNewAppsCategory.Apps = apps;


                var bestNewGamesCategory = new AppCategory {
                    Name = "Best New Games"
                };

                var bestNewGames = new List<StoreApp>();

                var telepaintApp = new StoreApp {
                    Name = "Telepaint",
                    Category = "Games",
                    Price = 2.99f
                };

                bestNewGames.Add(telepaintApp);

                bestNewGamesCategory.Apps = bestNewGames;

                return new List<AppCategory> { bestNewAppsCategory, bestNewGamesCategory };
            });
        }
    }
}
