﻿
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
using FFImageLoading.Forms.Platform;
using FFImageLoading.Svg.Forms;
using Firebase;
using System;
using Firebase.Iid;
using Android.Gms.Common;
//using LibVLCSharp.Forms.Shared;
//using Plugin.MediaManager.Forms.Android;
//using UltimateXF.Droid;


namespace SampleApp.FreshMVVM.Droid
{
    [Activity(Label = "SampleApp.FreshMVVM", Icon = "@mipmap/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;
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
                //UltimateXFSettup.Initialize(this)
                //LibVLCSharpFormsRenderer.Init();


                Acr.UserDialogs.UserDialogs.Init(this);

                CachedImageRenderer.Init(true);
                var ignore = typeof(SvgCachedImage);

                IsPlayServicesAvailable(); //You can use this method to check if play services are available.
                CreateNotificationChannel();

                try
                {
                    FirebaseApp.InitializeApp(this);
                    Console.WriteLine(TAG, "InstanceID token: " + FirebaseInstanceId.Instance.Token);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(TAG, "InstanceID token Error " + ex.Message);
                }


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

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                //if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                //    msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                //else
                //{
                //  msgText.Text = "This device is not supported";
                Finish();
                //  }
                return false;
            }
            else
            {
                // msgText.Text = "Google Play Services is available.";
                return true;
            }
        }

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.High)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}