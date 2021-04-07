using SampleApp.FreshMVVM.Interfaces;
using SampleApp.FreshMVVM.Resources;
using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;
using static SampleApp.FreshMVVM.Models.Enum.LanguageEnum;

namespace SampleApp.FreshMVVM.Helpers
{
    public static class AppLanguageHelper
    {
        public static void ErrorLog(Exception exception)
        {
            Debug.WriteLine(exception);
        }

        public static void ChangeLanguage(LanguageShortCode languageShortCode)
        {
            var culture = CultureInfo.CreateSpecificCulture(languageShortCode.ToString());
            UpdateLangauge(culture);
        }

        public static void UpdateLangauge(CultureInfo culture)
        {
            DependencyService.Get<IAppLocale>().SetLocale(culture);
            AppResources.Culture = culture; 
            Application.Current.Properties["Lang"] = culture.TwoLetterISOLanguageName;
            LangResourceLoader.Instance.SetCultureInfo(culture); 
        }
    }
}
