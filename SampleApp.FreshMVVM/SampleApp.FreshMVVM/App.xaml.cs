using FreshMvvm;
using SampleApp.FreshMVVM.Helpers;
using SampleApp.FreshMVVM.Interfaces;
using SampleApp.FreshMVVM.PageModels;
using SampleApp.FreshMVVM.Resources;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Xamarin.Forms;

namespace SampleApp.FreshMVVM
{
    public partial class App : Application
    {
        private CultureInfo language;

        public App()
        {
            try
            {
                InitializeComponent();

                //Set application culture by default based on device culture
                var phoneCulture = DependencyService.Get<IAppLocale>().GetCurrentCultureInfo();
                AppLanguageHelper.UpdateLangauge(phoneCulture);

                var loginPage = FreshMvvm.FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
                var loginContainer = new FreshNavigationContainer(loginPage, "login");
                var myPitchListViewContainer = new FreshTabbedNavigationContainer("Main");

               // FreshIOC.Container.Resolve<IMultiMediaPickerService>();

                

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
