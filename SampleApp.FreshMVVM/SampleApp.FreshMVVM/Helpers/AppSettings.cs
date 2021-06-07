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

        public static string CurrentLanguage
        {
            get
            {
                return Settings.GetValueOrDefault(nameof(CurrentLanguage), DefaultUserObjectId);
            }
            set
            {
                Settings.AddOrUpdateValue(nameof(CurrentLanguage), value);
            }
        } 
        
        public static string CurrentSecurity
        {
            get
            {
                return Settings.GetValueOrDefault(nameof(CurrentSecurity), DefaultUserObjectId);
            }
            set
            {
                Settings.AddOrUpdateValue(nameof(CurrentSecurity), value);
            }
        }
        
        public static string CurrentTheme
        {
            get
            {
                return Settings.GetValueOrDefault(nameof(CurrentTheme), DefaultUserObjectId);
            }
            set
            {
                Settings.AddOrUpdateValue(nameof(CurrentTheme), value);
            }
        } 
        
        public static string LoggerFilePath
        {
            get
            {
                return Settings.GetValueOrDefault(nameof(LoggerFilePath), DefaultUserObjectId);
            }
            set
            {
                Settings.AddOrUpdateValue(nameof(LoggerFilePath), value);
            }
        }
    }
}
