namespace SampleApp.FreshMVVM.Interfaces
{
    public interface IAppFileHelper
    {
        bool? IsPreferredLanguageArabic();

        void SaveUserLanguagePreference(bool status);
    }
}
