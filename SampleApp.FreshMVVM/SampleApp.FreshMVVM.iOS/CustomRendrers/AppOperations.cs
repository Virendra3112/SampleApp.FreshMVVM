using SampleApp.FreshMVVM.Interfaces;
using System;
using System.Threading.Tasks;

namespace SampleApp.FreshMVVM.iOS.CustomRendrers
{
    public class AppOperations : IAppOperations
    {
        public Task<string> CheckAppVersion(string currentVersion)
        {
            throw new NotImplementedException();
        }

        public Task OpenAppInStore()
        {
            throw new NotImplementedException();
        }
    }
}