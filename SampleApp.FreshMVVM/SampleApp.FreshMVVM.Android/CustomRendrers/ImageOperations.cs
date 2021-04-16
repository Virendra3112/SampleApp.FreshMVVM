using Android.Graphics;
using SampleApp.FreshMVVM.Droid.CustomRendrers;
using SampleApp.FreshMVVM.Interfaces;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageOperations))]
namespace SampleApp.FreshMVVM.Droid.CustomRendrers
{
    public class ImageOperations : IImageOperations
    {
        public byte[] CompressImage(byte[] imageData, float width, float height)
        {

            var originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            var resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                //resizedImage.SetPixels()
                resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 80, memoryStream);
                return memoryStream.ToArray();
            }





        }


    }
}