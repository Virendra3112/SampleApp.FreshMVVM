
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using SampleApp.FreshMVVM.Pages;
using Plugin.CurrentActivity;
using SampleApp.FreshMVVM.Droid.CustomRendrers;
using Android.Content;
using SampleApp.FreshMVVM.Interfaces;
using Plugin.Permissions;
//using LibVLCSharp.Forms.Shared;
//using Plugin.MediaManager.Forms.Android;
//using UltimateXF.Droid;


namespace SampleApp.FreshMVVM.Droid
{
    [Activity(Label = "SampleApp.FreshMVVM", Icon = "@mipmap/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);

                Forms.SetFlags("RadioButton_Experimental");

                //VideoViewRenderer.Init();

                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                CrossCurrentActivity.Current.Init(this, savedInstanceState);

                //CrossMediaManager.Current.Init(this);

                //UltimateXFSettup.Initialize(this);

                FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
                //var ignore = typeof(SvgCachedImage);
                Acr.UserDialogs.UserDialogs.Init(this);

                //LibVLCSharpFormsRenderer.Init();


                //allowing the device to change the screen orientation based on the rotation 
                MessagingCenter.Subscribe<SampleVideoPlayerPage>(this, "AllowLandscape", sender =>
                {
                    RequestedOrientation = ScreenOrientation.Landscape;
                });

                //during page close setting back to portrait
                MessagingCenter.Subscribe<SampleVideoPlayerPage>(this, "PreventLandscape", sender =>
                {
                    RequestedOrientation = ScreenOrientation.Portrait;
                });

                FreshMvvm.FreshIOC.Container.Register<IMultiMediaPickerService, MultiMediaPickerService>();
                FreshMvvm.FreshIOC.Container.Register<IAppOperations, AppOperations>();

                LoadApplication(new App());
            }
            catch (System.Exception ex)
            {
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            //base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            MultiMediaPickerService.SharedInstance.OnActivityResult(requestCode, resultCode, data);
        }
    }
}