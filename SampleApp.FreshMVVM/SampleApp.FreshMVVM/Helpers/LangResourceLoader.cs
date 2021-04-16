using SampleApp.FreshMVVM.Resources;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using Xamarin.Forms;
using static SampleApp.FreshMVVM.Models.Enum.LanguageEnum;

namespace SampleApp.FreshMVVM.Helpers
{
    public class LangResourceLoader : INotifyPropertyChanged
    {
        private readonly ResourceManager manager = AppResources.ResourceManager;

        static LangResourceLoader instance;
        private LangResourceLoader()
        {
        }

        public static void NullifySingleton()
        {
            instance = null;
        }

        public static LangResourceLoader Instance
        {
            get
            {
                if (instance == null)
                    instance = new LangResourceLoader();
                return instance;
            }
        }

        public string GetString(string resourceName)
        {
            string stringRes = this.manager.GetString(resourceName);
            return stringRes;
        }

        public string this[string key] => this.GetString(key);

        public void SetCultureInfo(CultureInfo cultureInfo)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public LanguageCode CurrentLanguageAbbr
        {
            get
            {
                //if (Application.Current.Properties["Lang"] == null)
                //    return LanguageCode.English;

                //if (Application.Current.Properties["Lang"].ToString() == LanguageShortCode.ar.ToString())
                //{
                //    return LanguageCode.Arabic;
                //}

                return LanguageCode.English;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
