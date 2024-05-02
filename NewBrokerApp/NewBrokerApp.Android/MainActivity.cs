using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms.GoogleMaps.Android;
using FFImageLoading.Forms.Platform;
using Android.Support.V7.App;
using Acr.UserDialogs;
using Android;
using Plugin.FirebasePushNotification;
using Android.Media;
using Firebase.Iid;
using Android.Views;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;


namespace NewBrokerApp.Droid
{
    //| ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize
    [Activity(Label = "NewBrokerApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation ,ScreenOrientation =ScreenOrientation.Portrait )]
    //[IntentFilter(new[] { Intent.ActionView },
    //    Categories = new[]
    //    {
    //        Intent.ActionView,
    //        Intent.CategoryDefault,
    //        Intent.CategoryBrowsable
    //    },
    //    DataScheme = "https",
    //    DataHost = "broker.nahrdev.website",
    //    DataPathPrefix = "/",
    //    AutoVerify = true, Categories = new[] { Android.Content.Intent.ActionView, Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable })])
    //]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
           DataScheme = "https",
           DataHost = "broker.nahrdev.website",
           DataPathPrefix = "/",
           AutoVerify = true, Categories = new[] { Android.Content.Intent.ActionView, Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable })]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static readonly string CHANNEL_ID = "my_notification_channel";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Plugin.InputKit.Platforms.Droid.Config.Init(this, savedInstanceState);
                // Override default BitmapDescriptorFactory by your implementation. 
            var platformConfig = new PlatformConfig
            {
                BitmapDescriptorFactory = new CachingNativeBitmapDescriptorFactory()
            };

            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState, platformConfig); // initialize for Xamarin.Forms.GoogleMaps


            //Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            CachedImageRenderer.Init(true);
            CachedImageRenderer.InitImageViewHandler();
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
            //var platformConfig = new PlatformConfig
            //{
            //    BitmapDescriptorFactory = new BitmapConfig()
            //};
            //Xamarin.FormsGoogleMaps.Init(this, savedInstanceState, platformConfig);
            Rg.Plugins.Popup.Popup.Init(this);
            // FormsGoogleMaps.Init(this, savedInstanceState);
            FirebasePushNotificationManager.ProcessIntent(this, Intent);
           // AndroidAppLinks.Init(this);
            LoadApplication(new App());
            var uri = Intent?.Data;
            if (uri != null)
            {
                if (uri.Host == "broker.nahrdev.website")
                {
                    StartActivity(typeof(SplashActivity));
                    //IniProperties.Host = uri.Host;
                    //IniProperties.LastPathSegment = uri.LastPathSegment;

                }
                // OnNewIntent(Intent);
                //if (uri.Host == "zadegy.com")
                //{
                //    if (!string.IsNullOrEmpty(IniProperties.productId))
                //    {


                //    }
                //}

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
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnStart()
        {
            base.OnStart();
            Helpers.Constants.DeviceToken = FirebaseInstanceId.Instance.Token;

            //if (CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != (int)Android.Content.PM.Permission.Granted)
            //{
            //    RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
            //}
        }
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }

    }
}