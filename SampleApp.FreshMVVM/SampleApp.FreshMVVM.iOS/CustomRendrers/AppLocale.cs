using Foundation;
using SampleApp.FreshMVVM.Interfaces;
using SampleApp.FreshMVVM.iOS.CustomRendrers;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppLocale))]
namespace SampleApp.FreshMVVM.iOS.CustomRendrers
{
    public class AppLocale : IAppLocale
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
                netLanguage = NSLocale.PreferredLanguages[0];
            System.Globalization.CultureInfo ci = null;
            try
            {
                ci = new System.Globalization.CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException ex)
            {
                ci = new System.Globalization.CultureInfo("en");//default to en
            }

            return ci;
        }

        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}