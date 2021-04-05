using SampleApp.FreshMVVM.Interfaces;
using SampleApp.FreshMVVM.iOS.CustomRendrers;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppLocale))]
namespace SampleApp.FreshMVVM.iOS.CustomRendrers
{
    public class AppFileHelper : IAppFileHelper
    {
        public bool? IsPreferredLanguageArabic()
        {
            throw new NotImplementedException();
        }

        public void SaveUserLanguagePreference(bool status)
        {
            throw new NotImplementedException();
        }
    }
}