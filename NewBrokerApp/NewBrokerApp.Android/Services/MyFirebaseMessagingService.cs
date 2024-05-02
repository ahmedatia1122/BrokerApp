using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Firebase.Iid;
//using Carent.Views.CarOwner.DashBoard;
//using Carent.Views.Cars;
using Firebase.Messaging;
using NewBrokerApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using NewBrokerApp.Droid;
using Acr.UserDialogs;
using NewBrokerApp.Helpers;

namespace NewBrokerApp.Droid.Services
{
    [Service(Exported = true)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        public const string PRIMARY_CHANNEL = "default";
        // [START receive_message]

        public override async void OnMessageReceived(RemoteMessage message)
        {
          
            try
            {
                await UserDialogs.Instance.AlertAsync(message.GetNotification().Body, message.GetNotification().Title, "ok");

                Helpers.Constants.SeekerId = message.Data.ContainsKey("seekerId") ? Convert.ToInt32(message.Data["seekerId"].ToString()) : 0;
                Helpers.Constants.OwnerId = message.Data.ContainsKey("ownerId") ? Convert.ToInt32(message.Data["ownerId"].ToString()) : 0;
                Helpers.Constants.BrokerId = message.Data.ContainsKey("brokerId") ? Convert.ToInt32(message.Data["brokerId"].ToString()) : 0;
                Helpers.Constants.CompanyId = message.Data.ContainsKey("companyId") ? Convert.ToInt32(message.Data["companyId"].ToString()) : 0;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    // await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new Views.Doctors.CustomersDetailsPage(Convert.ToInt32(Constants.NavigationParamter.ToString())));
                    await Shell.Current.Navigation.PushAsync(new Views.AddsPage());
                    // await Shell.Current.Navigation.PushAsync(new Views.Doctors.CustomersDetailsPage(Convert.ToInt32(Constants.NavigationParamter.ToString())));

                });


            }
            catch (Exception ex)
            {

            }
        }
        // [END receive_message]



        public void SendNotifications(RemoteMessage message)
        {
            try
            {
                NotificationManager manager = (NotificationManager)GetSystemService(NotificationService);
                var seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);
                int id = new Random(seed).Next(000000000, 999999999);
                var push = new Intent();
                var fullScreenPendingIntent = PendingIntent.GetActivity(this, 0,
               push, PendingIntentFlags.CancelCurrent);
                NotificationCompat.Builder notification;
                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    var chan1 = new NotificationChannel(PRIMARY_CHANNEL,
                     new Java.Lang.String("Primary"), NotificationImportance.High);
                    chan1.LightColor = Android.Graphics.Color.Green;
                    manager.CreateNotificationChannel(chan1);
                    notification = new NotificationCompat.Builder(this, PRIMARY_CHANNEL);
                }
                else
                {
                    notification = new NotificationCompat.Builder(this);
                }
                var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
                notification.SetContentIntent(fullScreenPendingIntent)
                         .SetContentTitle(message.GetNotification().Title)
                         .SetContentText(message.GetNotification().Body)
                         .SetLargeIcon(BitmapFactory.DecodeResource(Resources, Resource.Drawable.AppIcons))
                         .SetSmallIcon(Resource.Drawable.AppIcons)
                         .SetStyle((new NotificationCompat.BigTextStyle()))
                         .SetPriority(NotificationCompat.PriorityHigh)
                         .SetColor(0x9c6114)
                         .SetSound(defaultSoundUri)
                         .SetAutoCancel(true);
                manager.Notify(id, notification.Build());
            }
            catch (Exception ex)
            {
            }
        }
    }
    //[Service]
    //[IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    //public class MyFirebaseIIDService : FirebaseInstanceIdService
    //{
    //    const string TAG = "MyFirebaseIIDService";

    //    public override void OnTokenRefresh()
    //    {
    //        // Get updated InstanceID token. 
    //        var refreshedToken = FirebaseInstanceId.Instance.Token;
    //        Android.Util.Log.Debug(TAG, "Refreshed token: " + refreshedToken);

    //        // TODO: Implement this method to send any registration to your app's servers. 
    //        SendRegistrationToServer(refreshedToken);
    //    }
    //    void SendRegistrationToServer(string token)
    //    {
    //        App.Current.MainPage.DisplayAlert("",token,"");
    //        App.Current.Properties["CurrentToken"] = token;
    //        App.Current.SavePropertiesAsync();
    //        Task.Run(async () =>
    //        {

    //            //await App.InitApiTask;
    //            //  WebApiServices.UpdateCustomerToken(token);
    //        });
    //        // Add custom implementation, as needed. 
    //    }
    //}
}