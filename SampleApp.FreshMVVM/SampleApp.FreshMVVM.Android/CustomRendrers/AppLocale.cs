using SampleApp.FreshMVVM.Droid.CustomRendrers;
using SampleApp.FreshMVVM.Interfaces;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppLocale))]
namespace SampleApp.FreshMVVM.Droid.CustomRendrers
{
    public class AppLocale : IAppLocale
    {
        public void SetLocale(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            var androidLocale = Java.Util.Locale.Default;
            netLanguage = androidLocale.ToString().Replace("_", "-");

            System.Globalization.CultureInfo ci = null;
            try
            {
                ci = new System.Globalization.CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException ex)
            {
                ci = new System.Globalization.CultureInfo("en");
            }

            return ci;
        }
    }
}