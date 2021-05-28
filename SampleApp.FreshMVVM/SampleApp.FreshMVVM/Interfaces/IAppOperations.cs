using System.Threading.Tasks;

namespace SampleApp.FreshMVVM.Interfaces
{
    public interface IAppOperations
    {
        Task<string> CheckAppVersion(string currentVersion);
        Task OpenAppInStore();
    }
}
