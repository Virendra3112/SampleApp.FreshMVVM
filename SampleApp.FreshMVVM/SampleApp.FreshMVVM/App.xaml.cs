using FreshMvvm;
using SampleApp.FreshMVVM.Helpers;
using SampleApp.FreshMVVM.PageModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.FreshMVVM
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();

                //MainPage = new MainPage();

                var loginPage = FreshMvvm.FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
                var loginContainer = new FreshNavigationContainer(loginPage, "login");
                var myPitchListViewContainer = new FreshTabbedNavigationContainer("Main");


                if (!AppSettings.IsUserLoggedIn)
                {
                    MainPage = loginContainer;
                }

                else
                {
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
