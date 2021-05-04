using SampleApp.FreshMVVM.Models;

namespace SampleApp.FreshMVVM.Interfaces
{
    public interface IImageOperations
    {
        byte[] CompressImage(byte[] imageData, float width, float height);

        byte[] ConvertToJpg(string path);

        ImageDataModel GetImageData(string fileName);

        void SaveImageToStorage(byte[] imageData, string fileName);
    }
}
