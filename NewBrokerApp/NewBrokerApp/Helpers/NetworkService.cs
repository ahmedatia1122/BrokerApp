using System;
using Plugin.Connectivity;
using System.Threading.Tasks;
using Plugin.Connectivity.Abstractions;

namespace NewBrokerApp.Helpers
{
   public class NetworkService
    {
        public bool IsConnected => CrossConnectivity.Current.IsConnected;

        public event EventHandler<bool> InternetConnectivityChanged;

        public NetworkService()
        {
            CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChanged;
        }

        async void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            InternetConnectivityChanged?.Invoke(this, e.IsConnected);
        }
    }
}
