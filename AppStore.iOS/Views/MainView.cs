using Appstore.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace AppStore.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainView : MvxViewController<MainViewModel>
    {
        public MainView() : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}
