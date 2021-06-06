using SampleApp.FreshMVVM.Interfaces;
using System;
using System.Threading.Tasks;

namespace SampleApp.FreshMVVM.iOS.CustomRendrers
{
    public class AppLogger : IAppLogger
    {
        public Task AddErrorLog(string ClassName, string method, Exception ex, string parameters)
        {
            throw new NotImplementedException();
        }

        public Task AddLog(string ClassName, string method, string parameters)
        {
            throw new NotImplementedException();
        }

        public Task SetupLogger(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}