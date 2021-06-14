using SampleApp.FreshMVVM.Helpers;
using SampleApp.FreshMVVM.Interfaces;
using SampleApp.FreshMVVM.iOS.CustomRendrers;
using System;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(AppLogger))]
namespace SampleApp.FreshMVVM.iOS.CustomRendrers
{
    public class AppLogger : IAppLogger
    {
        public string filePath { get; set; }
        public void AddErrorLog(string ClassName, string method, Exception ex, string parameters)
        {
            try
            {
                System.IO.File.WriteAllText(AppSettings.LoggerFilePath,
                                               "ClassName: " + ClassName + " - " +
                                               "Mathod: " + method + " - " +
                                               "Parameters: " + parameters +
                                               "Exception: " + ex +
                                               "DateTime: " + DateTime.Now);
            }
            catch (Exception)
            {

            }
        }

        public void AddLog(string ClassName, string method, string parameters)
        {
            try
            {
                System.IO.File.WriteAllText(AppSettings.LoggerFilePath,
                                               "ClassName: " + ClassName + " - " +
                                               "Mathod: " + method + " - " +
                                               "Parameters: " + parameters +
                                               "DateTime: " + DateTime.Now);
            }
            catch (Exception)
            {

            }
        }

        public async Task SetupLogger(string fileName)
        {
            try
            {
                filePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                var filename = System.IO.Path.Combine(filePath, fileName);
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