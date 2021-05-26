using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SampleApp.FreshMVVM.Interfaces;
using SampleApp.FreshMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.FreshMVVM.PageModels
{
    public class SampleImageEditPageModel : BasePageModel
    {
        public ICommand SelectImagesCommand { get; set; }

        private ObservableCollection<MediaFile> media;
        public ObservableCollection<MediaFile> Media;
        //{
        //    get { return media; }
        //    set { SetPropertyValue(ref media, value); }
        //}


        public IMultiMediaPickerService _multiMediaPickerService { get; set; }


        public SampleImageEditPageModel(IMultiMediaPickerService multiMediaPickerService)
        {
            try
            {
                _multiMediaPickerService = multiMediaPickerService;

                SelectImagesCommand = new Command(async (obj) =>
                {
                    var hasPermission = await CheckPermissionsAsync();
                    if (hasPermission)
                    {
                        Media = new ObservableCollection<MediaFile>();
                        //await DependencyService.Get<IMultiMediaPickerService>().PickPhotosAsync();
                        await _multiMediaPickerService.PickPhotosAsync();
                    }
                });



                //DependencyService.Get<IMultiMediaPickerService>().OnMediaPicked += (s, a) =>
                _multiMediaPickerService.OnMediaPicked += (s, a) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Media.Add(a);

                    });

                };

                _multiMediaPickerService.OnMediaPickedCompleted += (s, a) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {

                    });

                };




            }
            catch (Exception ex)
            {

            }
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

        }

        async Task<bool> CheckPermissionsAsync()
        {
            var retVal = false;
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.Storage))
                    {
                        await App.Current.MainPage.DisplayAlert("Alert", "Need Storage permission to access to your photos.", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Plugin.Permissions.Abstractions.Permission.Storage });
                    status = results[Plugin.Permissions.Abstractions.Permission.Storage];
                }

                if (status == PermissionStatus.Granted)
                {
                    retVal = true;

                }
                else if (status != PermissionStatus.Unknown)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Permission Denied. Can not continue, try again.", "Ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                await App.Current.MainPage.DisplayAlert("Alert", "Error. Can not continue, try again.", "Ok");
            }

            return retVal;

        }

    }
}
