using SampleApp.FreshMVVM.Interfaces;
using SampleApp.FreshMVVM.iOS.CustomRendrers;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageOperations))]
namespace SampleApp.FreshMVVM.iOS.CustomRendrers
{
    public class ImageOperations : IImageOperations
    {
        public byte[] CompressImage(byte[] imageData, float width, float height)
        {
            throw new NotImplementedException();
        }

        public byte[] ConvertToJpg(string path)
        {
            throw new NotImplementedException();
        }
    }
}