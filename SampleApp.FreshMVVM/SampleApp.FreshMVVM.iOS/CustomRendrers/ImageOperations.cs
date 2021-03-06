using CoreGraphics;
using Foundation;
using SampleApp.FreshMVVM.Interfaces;
using SampleApp.FreshMVVM.iOS.CustomRendrers;
using SampleApp.FreshMVVM.Models;
using System;
using System.Drawing;
using System.IO;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageOperations))]
namespace SampleApp.FreshMVVM.iOS.CustomRendrers
{
    public class ImageOperations : IImageOperations
    {
        public byte[] CompressImage(byte[] imageData, float width, float height)
        {
            UIImage sourceImage = ConvertImage(imageData);

            UIImageOrientation orientation = sourceImage.Orientation;

            using (CGBitmapContext cGBitmapContext = new CGBitmapContext(IntPtr.Zero, (int)width, (int)height, 8,
              4 * (int)width, CGColorSpace.CreateDeviceRGB(), CGImageAlphaInfo.PremultipliedFirst))
            {
                RectangleF imageReact = new RectangleF(0, 0, width, height);

                cGBitmapContext.DrawImage(imageReact, sourceImage.CGImage);

                UIKit.UIImage resizedImage = UIKit.UIImage.FromImage(cGBitmapContext.ToImage(), 0, orientation);

                return resizedImage.AsJPEG().ToArray();

            }

        }

        private static UIKit.UIImage ConvertImage(byte[] ImageData)
        {
            try
            {
                if (ImageData == null)
                    return null;

                UIKit.UIImage uiImage = new UIImage(Foundation.NSData.FromArray(ImageData));

                return uiImage;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public byte[] ConvertToJpg(string path)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {

                    using (MemoryStream memoryStream = new MemoryStream())
                    {

                        byte[] imageBytes = new byte[memoryStream.Length];
                        memoryStream.Read(imageBytes, 0, imageBytes.Length);

                        UIKit.UIImage uIImage = new UIImage(Foundation.NSData.FromArray(imageBytes));

                        byte[] bytes = uIImage.AsJPEG(0.9f).ToArray();

                        return bytes;
                    }

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public ImageDataModel GetImageData(string fileName)
        {
            UIImage image = UIImage.LoadFromData(new NSData());

            var result = new Xamarin.Forms.Size((double)image.Size.Width, (double)image.Size.Height);

            return new ImageDataModel { Height = result.Height, Width = result.Width };
        }

        public void SaveImageToStorage(byte[] imageData, string fileName)
        {
            var image = new UIImage(NSData.FromArray(imageData));

            image.SaveToPhotosAlbum((img, error) =>
            {
                if (error != null)
                    Console.WriteLine("Saved");

            });
        }
    }
}