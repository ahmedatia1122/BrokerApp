
using Acr.UserDialogs;
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

namespace NewBrokerApp.Views.Company
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetAddressCompanyPage : PopupPage
    {


        private Pin currentPin;
        public int MapKM;
        Plugin.Geolocator.Abstractions.Position position;
        CancellationTokenSource cts;
        TaskCompletionSource<CompanyDetailsModel> ChooseCompletionTask;
        CompanyDetailsModel model;
        public GetAddressCompanyPage(CompanyDetailsModel data, TaskCompletionSource<CompanyDetailsModel> ChooseCompletionTask)
        {
            InitializeComponent();
            this.ChooseCompletionTask = ChooseCompletionTask;
            model = new CompanyDetailsModel();
            if (data != null)
            {
                model = data;
            }
            position = new Plugin.Geolocator.Abstractions.Position();
            setMapLayout();
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
            if (model.Latitude == null && model.Longitude == null)
            {
                Task.Run(async () =>
                {
                    try
                    {
                        var position = await Geolocation.GetLastKnownLocationAsync();

                        if (position == null)
                        {
                            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                            cts = new CancellationTokenSource();
                            position = await Geolocation.GetLocationAsync(request, cts.Token);
                        }
                        if (position != null)
                        {
                            try
                            {


                                Geocoder geoCoder = new Geocoder();
                                var currentAddress = await geoCoder.GetAddressesForPositionAsync(new Position(position.Latitude, position.Longitude));
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    string alladd = "";
                                    if (currentAddress != null || currentAddress.Count() != 0)
                                    {
                                        var a = currentAddress.FirstOrDefault();
                                        alladd = a;
                                    }
                                    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                                         Distance.FromKilometers(2)).WithZoom(3));

                                    var positionMapnew = new Position(Convert.ToDouble(position.Latitude)
                                        , Convert.ToDouble(position.Longitude));

                                    currentPin = new Pin
                                    {
                                        Type = PinType.Place,
                                        Position = positionMapnew,
                                        Label = "",
                                        Address = "",
                                        IsDraggable = true,
                                    };
                                    map.Pins.Add(currentPin);
                                    model.Latitude = position.Latitude.ToString();
                                    model.Longitude = position.Longitude.ToString();


                                });
                            }
                            catch (Exception ex)
                            {
                                // Toast.ShowError(ex.Message);
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                        // Latitude, Longitude
                        var positionMap = new Position(33.312805, 44.361488);

                        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(positionMap.Latitude,
                            positionMap.Longitude), Distance.FromKilometers(2)).WithZoom(3));

                        var positionMapnew = new Position(Convert.ToDouble(positionMap.Latitude)
                            , Convert.ToDouble(positionMap.Longitude));
                        currentPin = new Pin
                        {
                            Position = positionMapnew,
                            // Label = AppResources.Address,
                            Label = "",
                            Address = "",
                            IsDraggable = true,
                        };
                        map.Pins.Add(currentPin);

                    }
                });
            }
            else
            {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(model.Latitude), Convert.ToDouble(model.Longitude)),
                                          Distance.FromKilometers(2)).WithZoom(3));

                var positionMapnew = new Position(Convert.ToDouble(model.Latitude)
                    , Convert.ToDouble(model.Longitude));

                currentPin = new Pin
                {
                    Type = PinType.Place,
                    Position = positionMapnew,
                    Label = "",
                    Address = "",
                    IsDraggable = true,
                };
                map.Pins.Add(currentPin);
            }
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
            model.Longitude = position.Longitude.ToString();
            model.Latitude = position.Latitude.ToString();

            // Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private void map_PinDragStart(object sender, PinDragEventArgs e)
        {

        }

        private void map_PinDragEnd(object sender, PinDragEventArgs e)
        {
            var pos = new Position(e.Pin.Position.Latitude, e.Pin.Position.Longitude);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(pos.Latitude, pos.Longitude), Distance.FromKilometers(2)).WithZoom(3));

            model.Longitude = position.Longitude.ToString();
            model.Latitude = position.Latitude.ToString();

            ChooseCompletionTask.TrySetResult(model);
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            ChooseCompletionTask.TrySetResult(model);
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLocation.Text))
            {
                UserDialogs.Instance.ShowLoading();
                Task.Run(async () =>
                {
                    try
                    {
                        Geocoder geoCoder = new Geocoder();
                        var postions = await geoCoder.GetPositionsForAddressAsync(txtLocation.Text);

                        if (postions != null && postions.Count() != 0)
                        {
                            var Positionaddress = postions.First();
                            var address = await geoCoder.GetAddressesForPositionAsync(new Position(Positionaddress.Latitude, Positionaddress.Longitude));
                            string alladd = "";
                            if (address != null || address.Count() != 0)
                            {
                                alladd = address.FirstOrDefault();
                            }
                            //if (addresses != null || addresses.Count() != 0)
                            //{
                            //    string addressString = addresses.FirstOrDefault().ToString();
                            //    List<string> addressParse = addressString.Split("\n".ToCharArray()).ToList<string>();
                            //    string cityState = Regex.Replace(addressParse[1], @"[\d-]", string.Empty);
                            //    alladd = cityState.Trim();
                            //    //  alladd =  $"{a.AdminArea} {a.SubAdminArea} {a.Thoroughfare} {a.Locality}  {a.SubLocality} {a.SubThoroughfare}";
                            //}
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                //  viewModel.EditCustomerAddressModel.Address.Latitude = Positionaddress.Latitude.ToString();
                                //viewModel.EditCustomerAddressModel.Address.Longitude = Positionaddress.Longitude.ToString();
                                txtLocation.Text = alladd;

                                map.Pins.Remove(currentPin);
                                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Positionaddress.Latitude,
                                          Positionaddress.Longitude), Distance.FromMiles(0.8)));

                                var positionMap = new Position(Convert.ToDouble(Positionaddress.Latitude)
                                , Convert.ToDouble(Positionaddress.Longitude));
                                currentPin = new Pin
                                {
                                    Type = PinType.Place,
                                    Position = positionMap,
                                    //  Label = AppResources.Address,
                                    //   Address = alladd,
                                    Label = "",
                                    Address = "",
                                    IsDraggable = true,
                                };
                                map.Pins.Add(currentPin);

                                UserDialogs.Instance.HideLoading();
                            });
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                UserDialogs.Instance.ShowError("locationnotfount");
                                //Toast.ShowError(strings.get("locationnotfount"));
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.HideLoading();
                    }
                });
            }
            else
            {
                // Toast.ShowError(strings.get("pleasewriteaddressinsearch"));
            }
        }

    }
}