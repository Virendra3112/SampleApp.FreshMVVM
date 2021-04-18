using CoreGraphics;
using SampleApp.FreshMVVM.Interfaces;
using SampleApp.FreshMVVM.iOS.CustomRendrers;
using System;
using System.Drawing;
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
            throw new NotImplementedException();
        }
    }
}