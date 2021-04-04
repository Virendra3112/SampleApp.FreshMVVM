using System.Globalization;

namespace SampleApp.FreshMVVM.Interfaces
{
    public interface IAppLocale
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo cultureInfo);
    }
}
