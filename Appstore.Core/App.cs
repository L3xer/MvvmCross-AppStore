using Appstore.Core.ViewModels;
using MvvmCross.Core.ViewModels;


namespace Appstore.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}
