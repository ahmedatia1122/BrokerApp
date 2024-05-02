
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Common;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

using Xamarin.Forms.Xaml;


namespace NewBrokerApp.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage : PopupPage
    {


        private Pin currentPin;
        public int MapKM;
        Plugin.Geolocator.Abstractions.Position position;
        AdvertisementModel model;
      
        public LocationPage(double? Latitude, double? Longitude)
        {
            InitializeComponent();
            model = new AdvertisementModel();
            model.Longitude = Convert.ToString(Longitude);
            model.Latitude = Convert.ToString(Latitude);
            position = new Plugin.Geolocator.Abstractions.Position();
          //  getCurrentLocation();
            setMapLayout();
        }
        public async void getCurrentLocation()
        {
            CancellationTokenSource cts;
            var position = await Geolocation.GetLastKnownLocationAsync();

            if (position == null)
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                position = await Geolocation.GetLocationAsync(request, cts.Token);
            }
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                                                               Distance.FromKilometers(2)).WithZoom(3));
        }
        private async void MyMap_PinClicked(object sender, PinClickedEventArgs e)
        {
            var data = sender;
            e.Handled = true;
            Constants.NavigationParamter = e.Pin.Tag;
            await PopupNavigation.Instance.PushAsync(new PropertyDetailsPopUp());

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
        void setMapLayout()
        {
            stack.HeightRequest = Constants.screenHeigth / 3;
            MapKM = 100;
            if (!string.IsNullOrEmpty(model.Latitude) &&
                     !string.IsNullOrEmpty(model.Longitude))
            {
                Task.Run(() => {
               

                    var positionMapnew = new Position(Convert.ToDouble(model.Latitude)
                       , Convert.ToDouble(model.Longitude));
                    map.Pins.Clear();
                    currentPin = new Pin
                    {
                        Type = PinType.Place,
                        Label = "",
                        Address = "",
                        IsDraggable = true,
                        Position = positionMapnew,
                    };
                    map.Pins.Add(currentPin);
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(model.Latitude),
           Convert.ToDouble(model.Longitude)), Distance.FromKilometers(2)).WithZoom(3));
                });
              
            }
                //Task.Run(async () =>
                //{
                //    try
                //    {
                //        var position = await Geolocation.GetLastKnownLocationAsync();

                //        if (position == null)
                //        {
                //            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                //            cts = new CancellationTokenSource();
                //            position = await Geolocation.GetLocationAsync(request, cts.Token);
                //        }
                //        if (position != null)
                //        {
                //            try
                //            {


                //                Geocoder geoCoder = new Geocoder();
                //                var currentAddress = await geoCoder.GetAddressesForPositionAsync(new Position(position.Latitude, position.Longitude));
                //                Device.BeginInvokeOnMainThread(() =>
                //                {
                //                    string alladd = "";
                //                    if (currentAddress != null || currentAddress.Count() != 0)
                //                    {
                //                        var a = currentAddress.FirstOrDefault();
                //                        alladd = a;
                //                    }
                //                    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                //                         Distance.FromKilometers(2)).WithZoom(3));

                //                    var positionMapnew = new Position(Convert.ToDouble(position.Latitude)
                //                        , Convert.ToDouble(position.Longitude));

                //                    currentPin = new Pin
                //                    {
                //                        Type = PinType.Place,
                //                        Position = positionMapnew,
                //                        Label = "",
                //                        Address = "",
                //                        IsDraggable = true,
                //                    };
                //                    map.Pins.Add(currentPin);
                //                    model.Latitude = position.Latitude.ToString();
                //                    model.Longitude = position.Longitude.ToString();


                //                });
                //            }
                //            catch (Exception ex)
                //            {
                //                // Toast.ShowError(ex.Message);
                //            }
                //        }

                //    }
                //    catch (Exception ex)
                //    {

                //        // Latitude, Longitude
                //        var positionMap = new Position(33.312805, 44.361488);

                //        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(positionMap.Latitude,
                //            positionMap.Longitude), Distance.FromKilometers(2)).WithZoom(3));

                //        var positionMapnew = new Position(Convert.ToDouble(positionMap.Latitude)
                //            , Convert.ToDouble(positionMap.Longitude));
                //        currentPin = new Pin
                //        {
                //            Position = positionMapnew,
                //            // Label = AppResources.Address,
                //            Label = "",
                //            Address = "",
                //            IsDraggable = true,
                //        };
                //        map.Pins.Add(currentPin);

                //    }
                //});




            }
        private void map_MapClicked(object sender, MapClickedEventArgs e)
        {
            var x = e.Point.Latitude;
            var y = e.Point.Longitude;
            var pos = new Position(e.Point.Latitude, e.Point.Longitude);
            position.Latitude = pos.Latitude;
            position.Longitude = pos.Longitude;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.GoogleMaps.Position(position.Latitude, position.Longitude), Distance.FromKilometers(2)).WithZoom(3));
            map.Pins.Clear();
            currentPin = new Pin
            {
                Label = "",
                Address = "",
                Type = PinType.Place,
                Position = new Position(position.Latitude, position.Longitude),
                IsDraggable = false
            };
            map.Pins.Add(currentPin);
           
        }
        private void map_PinDragEnd(object sender, PinDragEventArgs e)
        {
            var pos = new Position(e.Pin.Position.Latitude, e.Pin.Position.Longitude);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(pos.Latitude, pos.Longitude), Distance.FromKilometers(2)).WithZoom(3));
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}