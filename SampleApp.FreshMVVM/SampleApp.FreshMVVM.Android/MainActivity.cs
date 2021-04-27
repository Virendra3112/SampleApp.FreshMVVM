﻿
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Plugin.MediaManager.Forms.Android;
//using UltimateXF.Droid;


namespace SampleApp.FreshMVVM.Droid
{
    [Activity(Label = "SampleApp.FreshMVVM", Icon = "@mipmap/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
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

                VideoViewRenderer.Init();

                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

                //CrossMediaManager.Current.Init(this);

                //UltimateXFSettup.Initialize(this);

                //FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
                //var ignore = typeof(SvgCachedImage);
                Acr.UserDialogs.UserDialogs.Init(this);

                LoadApplication(new App());
            }
            catch (System.Exception ex)
            {
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}