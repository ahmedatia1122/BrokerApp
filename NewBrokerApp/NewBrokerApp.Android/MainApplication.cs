using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewBrokerApp.Droid
{
    //[Application]
    //[MetaData("com.google.android.geo.API_KEY", Value = Variables.GOOGLE_MAPS_ANDROID_API_KEY)]
    //[MetaData("com.google.android.gms.version", Value = "@integer/google_play_services_version")]
    //[UsesLibrary("org.apache.http.legacy", required: false)]
    public class MainApplication:Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
           : base(javaReference, transfer)
        {
        }
        public override void OnCreate()
        {
            base.OnCreate();
            CrossCurrentActivity.Current.Init(this);
            //Set the default notification channel for your app when running Android Oreo
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                //Change for your default notification channel id here
                FirebasePushNotificationManager.DefaultNotificationChannelId = "FirebasePushNotificationChannel";

                //Change for your default notification channel name here
                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";

                FirebasePushNotificationManager.DefaultNotificationChannelImportance = NotificationImportance.Max;
            }

            //FirebaseApp.InitializeApp(this);
            //If debug you should reset the token each time.
#if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
#else
            FirebasePushNotificationManager.Initialize(this, false);
#endif

            //Handle notification when app is closed here
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {


            };
        }
    }
}
