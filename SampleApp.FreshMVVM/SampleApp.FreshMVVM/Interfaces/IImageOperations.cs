namespace SampleApp.FreshMVVM.Interfaces
{
    public interface IImageOperations
    {
        byte[] CompressImage(byte[] imageData, float width, float height);

        byte[] ConvertToJpg(string path);

        void GetImageData(string fileName);

        void SaveImageToStorage(byte[] imageData, string fileName);
    }
}
