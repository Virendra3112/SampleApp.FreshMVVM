using System;
using System.Threading.Tasks;

namespace SampleApp.FreshMVVM.Interfaces
{
    public interface IAppLogger
    {
        Task SetupLogger(string fileName);
        Task AddLog(string ClassName, string method, string parameters);
        Task AddErrorLog(string ClassName, string method, Exception ex, string parameters);
    }
}
