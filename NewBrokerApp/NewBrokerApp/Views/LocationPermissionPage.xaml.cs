using NewBrokerApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPermissionPage : ContentPage
    {
        public LocationPermissionPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Denied)
            {
                var result = await DisplayAlert("Location Permission Required", "Please enable location permission in app settings to use this feature.", "Open Settings", "Cancel");
                if (result)
                {
                   // AppInfo.OpenSettings();
                    // Open the app settings
                      AppInfo.ShowSettingsUI(); 
                }
                // await Permissions.OpenAppSettingsAsync();
                // Display a message or dialog explaining why the permission is necessary
                // Provide an option to navigate to app settings
            }
            if (status == PermissionStatus.Granted)
            {
                await App.Current.MainPage.Navigation.PopAsync();
               await App.Current.MainPage.Navigation.PushAsync(new LoadingPage());
            }
           
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }
            if (status != PermissionStatus.Granted)
            {
                await Application.Current.MainPage.DisplayAlert("","Please allow location for this","ok");
                // return;
            }
            else if (status == PermissionStatus.Granted)
            {
                //Then checking the GPS state like below
                bool gpsStatus = DependencyService.Get<ILocSettings>().isGpsAvailable();
                if (!gpsStatus)
                {
                    //show a message to user here for sharing the GPS
                    //If user granted GPS Sharing, opening the location settings page like below:
                    DependencyService.Get<ILocSettings>().OpenSettings();
                }
            }

           
        }
    }
}