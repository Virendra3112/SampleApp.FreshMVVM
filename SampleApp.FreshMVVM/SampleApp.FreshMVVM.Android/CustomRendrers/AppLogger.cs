using SampleApp.FreshMVVM.Helpers;
using SampleApp.FreshMVVM.Interfaces;
using System;
using System.Threading.Tasks;

namespace SampleApp.FreshMVVM.Droid.CustomRendrers
{
    public class AppLogger : IAppLogger
    {
        public string filePath { get; set; }

        public async Task AddErrorLog(string ClassName, string method, Exception ex, string parameters)
        {
        }

        public async Task AddLog(string ClassName, string method, string parameters)
        {
        }

        public async Task SetupLogger(string fileName)
        {
            try
            {
                //Depricated
                //filePath = Android.OS.Environment.ExternalStorageDirectory.ToString();

                filePath = Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath;


                var filename = System.IO.Path.Combine(filePath, "MyLogs.txt");
                System.IO.File.WriteAllText(filename,
                    "********************************My App Logs********************************");

                AppSettings.LoggerFilePath = filePath;

            }
            catch (Exception ex)
            {

            }
        }
    }
}