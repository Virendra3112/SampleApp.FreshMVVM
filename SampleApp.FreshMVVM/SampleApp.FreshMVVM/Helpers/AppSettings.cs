using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SampleApp.FreshMVVM.Helpers
{
    public class AppSettings
    {
        private const string DefaultUserObjectId = "";

        public static ISettings Settings
        {
            get
            {
                if (CrossSettings.IsSupported)
                    return CrossSettings.Current;

                return null;
            }
        }

        public static bool IsUserLoggedIn
        {
            get
            {
                return Settings.GetValueOrDefault(nameof(IsUserLoggedIn), false);
            }
            set
            {
                Settings.AddOrUpdateValue(nameof(IsUserLoggedIn), value);
            }
        }
    }
}
