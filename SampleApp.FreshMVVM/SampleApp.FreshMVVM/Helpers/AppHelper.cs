using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
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
           
        }
    }
}