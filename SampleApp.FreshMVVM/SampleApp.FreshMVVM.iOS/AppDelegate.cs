using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using SampleApp.FreshMVVM.Pages;
//using MediaManager;
using UIKit;
using UltimateXF.iOS;

namespace SampleApp.FreshMVVM.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            UltimateXFSettup.Initialize();

            //CrossMediaManager.Current.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            var mainPage = Xamarin.Forms.Application.Current.MainPage;
            if (mainPage.Navigation.NavigationStack.Last() is HomePage)
            {
                return UIInterfaceOrientationMask.Landscape;
            }
            return UIInterfaceOrientationMask.Portrait;
        }
    }
}
