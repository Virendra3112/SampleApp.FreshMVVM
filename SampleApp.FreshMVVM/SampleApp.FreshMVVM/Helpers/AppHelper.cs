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
            try
            {
                masterDetailNav = new FreshMasterDetailNavigationContainer();

                var drawerMenuPage = FreshPageModelResolver.ResolvePageModel<DrawerMenuPageModel>();
                var homePageModel = FreshPageModelResolver.ResolvePageModel<HomePageModel>();
                var navContainer = new NavigationPage(homePageModel)
                {
                    BarBackgroundColor = Color.FromHex("#121212"),
                    BarTextColor = (Color.White)
                };
                masterDetailNav.Master = drawerMenuPage;
                masterDetailNav.Detail = navContainer;
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
            catch (System.Exception ex)
            {

            }

        }
    }
}