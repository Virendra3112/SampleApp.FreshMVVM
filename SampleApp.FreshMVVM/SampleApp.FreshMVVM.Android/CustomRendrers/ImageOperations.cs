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

        public byte[] ConvertToJpg(string path)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    byte[] imageData = default(byte[]);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {

                        streamReader.BaseStream.CopyTo(memoryStream);
                        imageData = memoryStream.ToArray();


                        //load bitmap
                        Android.Graphics.Bitmap bitmap = Android.Graphics.BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);

                        MemoryStream imageResult = new MemoryStream();

                        bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 80, imageResult);//todo: 

                        return imageResult.ToArray();

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void GetImageData(string fileName)
        {

        }

        public void SaveImageToStorage(byte[] imageData, string fileName)
        {

        }



    }
}