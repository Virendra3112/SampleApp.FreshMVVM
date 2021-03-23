using FreshMvvm;
using SampleApp.FreshMVVM.PageModels;
using Xamarin.Forms;

namespace SampleApp.FreshMVVM.Helpers
{
    public class AppHelper
    {
        private static FreshMasterDetailNavigationContainer masterDetailNav;

        public static bool MenuIsPresented
        {
            get
            {
                return masterDetailNav.IsPresented;
            }
            set
            {
                masterDetailNav.IsPresented = value;
            }
        }

        public static void InitializeAndShowMasterDetailPage()
        {
            masterDetailNav = new FreshMasterDetailNavigationContainer();

            var hamburgerMenuPage = FreshPageModelResolver.ResolvePageModel<DrawerMenuPageModel>();
            var animalCard = FreshPageModelResolver.ResolvePageModel<HomePageModel>();
            var basicNavigationContainer = new NavigationPage(animalCard)
            {
                BarBackgroundColor = Color.FromHex("#121212"),
                BarTextColor = (Color.White)
            };
            masterDetailNav.Master = hamburgerMenuPage;
            masterDetailNav.Detail = basicNavigationContainer;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    masterDetailNav.IsGestureEnabled = false;
                    break;

                case Device.Android:
                    masterDetailNav.IsGestureEnabled = true;
                    break;

                default:
                    break;
            }
            Application.Current.MainPage = masterDetailNav;

        }
    }
}