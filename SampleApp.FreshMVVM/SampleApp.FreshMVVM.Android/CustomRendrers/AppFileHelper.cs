using SampleApp.FreshMVVM.Droid.CustomRendrers;
using SampleApp.FreshMVVM.Interfaces;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppFileHelper))]
namespace SampleApp.FreshMVVM.Droid.CustomRendrers
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