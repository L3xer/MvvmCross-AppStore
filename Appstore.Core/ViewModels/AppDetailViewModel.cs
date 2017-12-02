using MvvmCross.Core.ViewModels;
using Appstore.Core.Models;

namespace Appstore.Core.ViewModels
{
    public class AppDetailViewModel : MvxViewModel<StoreApp>
    {
        public override void Prepare(StoreApp storeApp)
        {
            System.Diagnostics.Debug.WriteLine("App id: " + storeApp.Id);
        }
    }
}
