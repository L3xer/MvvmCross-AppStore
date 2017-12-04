using Android.OS;
using Android.App;
using MvvmCross.Droid.Views;
using Appstore.Core.ViewModels;


namespace AppStore.Droid.Views
{
    [Activity(Label = "Featured Apps", MainLauncher = true)]
    public class MainView : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MainView);
        }
    }
}