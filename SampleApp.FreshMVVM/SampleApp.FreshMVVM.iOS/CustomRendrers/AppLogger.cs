using SampleApp.FreshMVVM.Helpers;
using SampleApp.FreshMVVM.Interfaces;
using System;
using System.Threading.Tasks;

namespace SampleApp.FreshMVVM.iOS.CustomRendrers
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
                filePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

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