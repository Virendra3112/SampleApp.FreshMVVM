using System;
using System.Threading.Tasks;

namespace SampleApp.FreshMVVM.Interfaces
{
    public interface IAppLogger
    {
        Task SetupLogger(string fileName);
        void AddLog(string ClassName, string method, string parameters);
        void AddErrorLog(string ClassName, string method, Exception ex, string parameters);
    }
}
