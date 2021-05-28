﻿using Android.App;
using Android.Content;
using SampleApp.FreshMVVM.Interfaces;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SampleApp.FreshMVVM.Droid.CustomRendrers
{
    public class AppOperations : IAppOperations
    {
        public async Task<string> CheckAppVersion(string currentVersion)
        {
            string appVersion = "";

            string packageName = Application.Context.PackageName;
            string versionName = Application.Context.PackageManager.GetPackageInfo(Application.Context.PackageName, 0).VersionName;

            var url = $"https://play.google.com/store/apps/details?id={packageName}&hl=en";

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {
                        using (var responseMsg = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead))
                        {
                            if (!responseMsg.IsSuccessStatusCode)
                            {
                                //throw new LatestVersionException($"Error connecting to the Play Store. Url={url}.");
                            }

                            try
                            {
                                var content = responseMsg.Content == null ? null : await responseMsg.Content.ReadAsStringAsync();

                                var versionMatch = Regex.Match(content, "<div[^>]*>Current Version</div><span[^>]*><div[^>]*><span[^>]*>(.*?)<").Groups[1];

                                if (versionMatch.Success)
                                {
                                    appVersion = versionMatch.Value.Trim();
                                }
                            }
                            catch (Exception e)
                            {
                                //throw new LatestVersionException($"Error parsing content from the Play Store. Url={url}.", e);
                            }
                        }
                    }
                }
            }
            return appVersion;
        }

        public async Task OpenAppInStore()
        {
            string packageName = Application.Context.PackageName;

            try
            {

                var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse($"market://details?id={packageName}"));
                intent.SetPackage("com.android.vending");
                intent.SetFlags(ActivityFlags.NewTask);
                Application.Context.StartActivity(intent);
            }
            catch (ActivityNotFoundException)
            {
                var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse($"https://play.google.com/store/apps/details?id={packageName}"));
                Application.Context.StartActivity(intent);
            }


        }

    }
}