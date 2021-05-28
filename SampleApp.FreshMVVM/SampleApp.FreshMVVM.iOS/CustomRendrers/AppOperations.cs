using Foundation;
using SampleApp.FreshMVVM.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SampleApp.FreshMVVM.iOS.CustomRendrers
{
    public class AppOperations : IAppOperations
    {
        public string bundleIdentifier { get; set; }
        public string bundleVersion { get; set; }
        public string Version { get; set; }
        public string Url { get; set; }

        public AppOperations()
        {
            bundleIdentifier = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleIdentifier").ToString();
            bundleVersion = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }
        public async Task<string> CheckAppVersion(string currentVersion)
        {
            var countryCode = "us";//specify country code

            try
            {
                using (var http = new HttpClient())
                {
                    var response = await http.GetAsync($"http://itunes.apple.com/{countryCode}/lookup?bundleId={bundleIdentifier}");
                    var content = response.Content == null ? null : await response.Content.ReadAsStringAsync();
                    var appLookup = System.Json.JsonValue.Parse(content);

                    return appLookup["results"][0]["version"] + "" + appLookup["results"][0]["trackViewUrl"];                  
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Task OpenAppInStore()
        {
            throw new NotImplementedException();
        }
    }
}