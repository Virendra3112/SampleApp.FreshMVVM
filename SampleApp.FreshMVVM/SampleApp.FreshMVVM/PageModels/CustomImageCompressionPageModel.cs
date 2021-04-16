using Plugin.Media;
using SampleApp.FreshMVVM.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.FreshMVVM.PageModels
{
    public class CustomImageCompressionPageModel : BasePageModel
    {

        public ICommand SelectImageCommand { get; set; }

        public CustomImageCompressionPageModel()
        {
            SelectImageCommand = new Command(OnSelectImageClicked);

        }

        private async void OnSelectImageClicked(object obj)
        {
            try
            {

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    //await Page.DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg",

                });

                if (file == null)
                    return;



                //await Page.DisplayAlert("File Location", file.Path, "OK");


                //compress image

                byte[] filebytes = null;



                using (var streamReader = new StreamReader(file.Path))
                {
                    var bytes = default(byte[]);
                    using (var memstream = new MemoryStream())
                    {
                        streamReader.BaseStream.CopyTo(memstream);
                        bytes = memstream.ToArray();


                    }

                    var item = DependencyService.Get<IImageOperations>().CompressImage(bytes, 50, 50);

                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
