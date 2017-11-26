using Appstore.Core.ViewModels;
using MvvmCross.Platform.IoC;
using MvvmCross.Core.ViewModels;


namespace Appstore.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}
