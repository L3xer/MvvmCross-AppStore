using MvvmCross.Core.ViewModels;
using Appstore.Core.Models;

namespace Appstore.Core.ViewModels
{
    public class AppDetailViewModel : MvxViewModel<StoreApp>
    {
        public StoreApp StoreApp { get; set; }

        public override void Prepare(StoreApp storeApp)
        {
            StoreApp = storeApp;
        }
    }
}
