using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBrokerApp.Droid
{
    public class WifiService
    {
        public event EventHandler<bool> WifiStatusChanged;

        public async Task StartMonitoring(Context context)
        {
            while (true)
            {
                bool isConnected = IsWifiConnected(context);
                WifiStatusChanged?.Invoke(this, isConnected);
                await Task.Delay(TimeSpan.FromSeconds(5)); // Adjust the interval as needed
            }
        }

        bool IsWifiConnected(Context context)
        {
            var connectivityManager = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            var networkInfo = connectivityManager.GetNetworkInfo(ConnectivityType.Wifi);
            return networkInfo != null && networkInfo.IsConnected;
        }
    }
}
