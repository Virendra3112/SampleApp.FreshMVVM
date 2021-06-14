using FreshMvvm;
using SampleApp.FreshMVVM.Helpers;
using SampleApp.FreshMVVM.Interfaces;
using SampleApp.FreshMVVM.PageModels;
using System;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SampleApp.FreshMVVM
{
    public partial class App : Application
    {
        private CultureInfo language;
        public static double ScreenWidth, ScreenHeight;

        public App()
        {
            try
            {
                InitializeComponent();


                // Get Metrics
                var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

                // Orientation (Landscape, Portrait, Square, Unknown)
                var orientation = mainDisplayInfo.Orientation;

                // Rotation (0, 90, 180, 270)
                var rotation = mainDisplayInfo.Rotation;

                // Width (in pixels)
                var width = mainDisplayInfo.Width;

                // Width (in xamarin.forms units)
                var xamarinWidth = width / mainDisplayInfo.Density;

                // Height (in pixels)
                var height = mainDisplayInfo.Height;

                // Screen density
                var density = mainDisplayInfo.Density;

                ScreenWidth = width;
                ScreenHeight = height;

                //Set application culture by default based on device culture
                var phoneCulture = DependencyService.Get<IAppLocale>().GetCurrentCultureInfo();
                AppLanguageHelper.UpdateLangauge(phoneCulture);


                //setup for App logs
                var appLogger = DependencyService.Resolve<IAppLogger>();
                appLogger.SetupLogger(AppConstants.LoggerFileName);


                var loginPage = FreshMvvm.FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
                var loginContainer = new FreshNavigationContainer(loginPage, "login");
                var myPitchListViewContainer = new FreshTabbedNavigationContainer("Main");

                if (!AppSettings.IsUserLoggedIn)
                {
                    MainPage = loginContainer;

                    //Todo
                    //language = CultureInfo.GetCultureInfo(AppSettings.CurrentLanguage);
                    //Thread.CurrentThread.CurrentUICulture = language;
                    //AppResources.Culture = language;
                }

                else
                {
                    //todo need to test
                    //language = CultureInfo.GetCultureInfo("en");
                    //Thread.CurrentThread.CurrentUICulture = language;
                    //AppResources.Culture = language;

                    //save current language

                    AppHelper.InitializeAndShowMasterDetailPage();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
