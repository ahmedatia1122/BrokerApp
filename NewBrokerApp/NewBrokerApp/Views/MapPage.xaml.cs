using Acr.UserDialogs;
using DropdownMenu.Models.DropdownModel;
using FFImageLoading;
using FFImageLoading.Forms;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Transformations;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.Services;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Common;
using NewBrokerApp.Views.Company;
using NewBrokerApp.Views.Controls;
using NewBrokerApp.Views.Popup;
using NewBrokerApp.Views.PropertiesAds;

using RatingBarControl;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;


namespace NewBrokerApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    
	public partial class MapPage : ContentPage
	{
        //public string _changePassword;
        //public string ChangePassword
        //{
        //    get { return _changePassword; }
        //    set
        //    {
        //        _changePassword = value;
        //        OnPropertyChanged(nameof(_changePassword));
        //    }
        //}
        private Pin currentPin;
        HomeViewModel homeViewModel = new HomeViewModel();
        private  Position EnterAddress { get; set; }
        private int CurrentChoise { get; set; }
        private double previousZoom = 0;
        private Location CurrentLocationMap { get; set; }
        public IWebService webService => DependencyService.Get<IWebService>();
        int Count = 0;
        public MapPage ()
		{
			InitializeComponent ();
            CurrentLocationMap =new Location();
            CurrentChoise = 0;
            BindingContext = homeViewModel;
           
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                                  new Position(30.033333, 31.233334), Distance.FromMeters(100)));
            // Task.WhenAll(Task.Run(() => LoadHome()), Task.Run(() => CurrentLocation()));
            Device.BeginInvokeOnMainThread(() =>
            {
                LoadHome();
               // CurrentLocation();
            });
           
            // GetLocationAsync();
            //    getCurrentLocation();

            // homeViewModel.LoadAllAdvertisementsCommand.Execute(true);



            StkFooter.Children.Add(new Footer("home",this));
            
           

        }
        private async   void LoadHome()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }
            if (status != PermissionStatus.Granted)
            {
                await Shell.Current.Navigation.PushAsync(new LocationPermissionPage());
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
            //var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(5000));
            //CurrentLocationMap = await Geolocation.GetLocationAsync(request);
            //if (CurrentLocationMap != null)
            //    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
            //new Position(CurrentLocationMap.Latitude, CurrentLocationMap.Longitude), Distance.FromMeters(100)));
            
            //  var status = await Permissions.RequestAsync<Permissions.LocationAlways>();

        }
  
        public async void CurrentLocation()
        {
            try
            {

                var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(5000));
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                                   new Position(location.Latitude, location.Longitude), Distance.FromMeters(100)));
                    CurrentLocationMap.Latitude = location.Latitude;
                    CurrentLocationMap.Longitude = location.Longitude;
                }
                   
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Location permission is required", "OK");
            }
            
        } 
        public async void getCurrentLocation()
        {
            if (await CheckLocationPermission())
            {
                // Load frontend
                CurrentLocation();
            }
            else
            {
                // Ask for permission
                RequestLocationPermission();

                // check again
                if (await CheckLocationPermission())
                {
                    // Load frontend
                    CurrentLocation();
                }
                //else
                //{
                //    // Show error
                //   await DisplayAlert("Error", "Location permission is required", "OK");
                //}

            }
           
        }
        private async void RequestLocationPermission()
        {
            // Ask for permission
            await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

        }

        private async Task<bool> CheckLocationPermission()
        {
            // Check if permission is granted
            if (PermissionStatus.Granted ==await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //   getCurrentLocation();
         //   GetLocationAsync();
            txtLocation.Text = null;
            Device.BeginInvokeOnMainThread(()=>{
                LoadAllDataInMap();
                homeViewModel.InitCommand.Execute(null);
               
            });
           
         //   homeViewModel.SponsorsCommand.Execute(null);
            
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        
        }
        async void LoadAllDataInMap()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status == PermissionStatus.Granted)
                {

                    UserDialogs.Instance.ShowLoading();
                    CancellationTokenSource cts;

                    //  var position = await Geolocation.GetLastKnownLocationAsync();
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    cts = new CancellationTokenSource();
                    var position = await Geolocation.GetLocationAsync(request, cts.Token);
                    if (Constants.Companylat > 0 && Constants.Companylong > 0)
                    {
                        position.Latitude = Constants.Companylat ?? 00;
                        position.Longitude = Constants.Companylong ?? 00;
                    }
                    else
                    {


                        if (position == null)
                        {
                            //var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                            //cts = new CancellationTokenSource();
                            position = await Geolocation.GetLocationAsync(request, cts.Token);
                        }
                    }
                    MyMap.Pins.Clear();
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                                     Distance.FromKilometers(2)).WithZoom(3));
                    //Device.BeginInvokeOnMainThread(async () =>
                    //{
                    //    var constat = Constants.PropertyType;
                    //    var data = await webService.GetAllAdvertisements(new Models.AdvertisementInputModel { Name = "", AgreementStatus = Constants.ArgmentStatus, Type = Constants.PropertyType, CityId = Constants.CityId, Parking = Constants.Parking, Furnished = Constants.Furnished, Decoration = Constants.FinishedId, Rooms = Constants.Rooms, StreetOrCompund = Constants.Street, PriceFrom = Constants.PriceFrom, PriceTo = Constants.PriceTo, AreaFrom = Constants.AreaFrom, AreaTo = Constants.AreaTo, CompanyIdLocation = Constants.CompanyIdLocation, Latitude = position.Latitude, Longitude = position.Longitude });
                    //    MyMap.Pins.Clear();
                    //    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                    //                     Distance.FromKilometers(2)).WithZoom(3));
                    //    Constants.ArgmentStatus = 0; Constants.PropertyType = 0; Constants.CityId = 0; Constants.Parking = null; Constants.Furnished = null; Constants.FinishedId = 0; Constants.Rooms = 0; Constants.Street = null; Constants.PriceFrom = 0; Constants.PriceTo = 0; Constants.AreaFrom = 0; Constants.AreaTo = 0; Constants.Latitude = null; Constants.Longitude = null;
                    //    if (data.Result.Advertisements != null && data.Result.Advertisements.Count > 0)
                    //    {


                    //        foreach (var item in data.Result.Advertisements)
                    //        {

                    //            Pin pinItem = new Pin()
                    //            {
                    //                Type = PinType.Place,
                    //                Icon = BitmapDescriptorFactory.FromView(new mapIconPage(item)),
                    //                //  Icon=default,
                    //                Label = item.Id.ToString(),
                    //               // ZIndex = item.ZIndex,
                    //                Address = "",
                    //                Position = new Position(item.Latitude ?? 30.033333, item.Longitude ?? 31.233334),
                    //                Tag = item.Id,
                    //            };

                    //            MyMap.Pins.Add(pinItem);

                    //        }


                    //        Constants.AdvertisementParamter = 0;
                    //        UserDialogs.Instance.HideLoading();

                    //    }
                    //    else
                    //    {
                    //        if (Constants.SearchPropetry == true)
                    //        {
                    //            App.Current.MainPage.DisplayAlert("", AppResources.Thereisnoadvertisement, AppResources.ok);
                    //            Constants.SearchPropetry = null;
                    //        }
                    //    }
                    //});
                }
              
            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Error", "Location permission is required", "OK");
            }
            finally { UserDialogs.Instance.HideLoading(); }
           
        }
   
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           // await PopupNavigation.Instance.PushAsync(new PropertyPage());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
    
        }

        private void arrowImage_Clicked(object sender, EventArgs e)
        {
          
                arrowImage.IsVisible=false;
                boxImage.IsVisible=true;
                stkCompany.IsVisible = false;
                upImage.IsVisible = true;
          
            
        }

        private void upImage_Clicked(object sender, EventArgs e)
        {
            arrowImage.IsVisible = true;
            boxImage.IsVisible = false;
            stkCompany.IsVisible = true;
            upImage.IsVisible = false;

        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            arrowImage.IsVisible = false;
            boxImage.IsVisible = true;
            stkCompany.IsVisible = false;
            upImage.IsVisible = true;
            topGps.IsVisible = false;
            downGps.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            arrowImage.IsVisible = true;
            boxImage.IsVisible = false;
            stkCompany.IsVisible = true;
            upImage.IsVisible = false;
            topGps.IsVisible = true;
            downGps.IsVisible = false;
        }


        private async void MyMap_PinClicked(object sender, PinClickedEventArgs e)
        {
            var data = sender;
            e.Handled = true;
            var lbl = e.Pin.Label;
            Constants.NavigationParamter = e.Pin.Tag;
            await PopupNavigation.Instance.PushAsync(new PropertyDetailsPopUp());

        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new SearchPropertyPage());
        }

        
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CurrentChoise != 0)
                {
                    var dataMap = (e.CurrentSelection.FirstOrDefault() as ButtonModel);
                    MyMap.Pins.Clear();
                    CancellationTokenSource cts;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var position = await Geolocation.GetLastKnownLocationAsync();

                        if (position == null)
                        {
                            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                            cts = new CancellationTokenSource();
                            position = await Geolocation.GetLocationAsync(request, cts.Token);
                        }
                        Constants.ArgmentStatus = dataMap.ArgumentId;
                        Constants.PropertyType = dataMap.PropertyId;
                        var data = await webService.GetAllAdvertisements(new Models.AdvertisementInputModel { Name = "", AgreementStatus = dataMap.ArgumentId, Type = dataMap.PropertyId,Latitude=CurrentLocationMap.Latitude,Longitude=CurrentLocationMap.Longitude });
                        ;
                        if (data.Result.Advertisements != null && data.Result.Advertisements.Count > 0)
                        {

                            foreach (var item in data.Result.Advertisements)
                            {
                                Pin pinItem = new Pin()
                                {
                                    Type = PinType.Place,
                                    Icon = BitmapDescriptorFactory.FromView(new mapIconPage(item)),
                                    // Icon = default,
                                    Label = "",
                                   // ZIndex = item.ZIndex,
                                    Address = "",
                                    Position = new Position(item.Latitude ?? 30.033333, item.Longitude ?? 31.233334),
                                    Tag = item.Id,
                                };

                                MyMap.Pins.Add(pinItem);
                            }
                            //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(EnterAddress.Latitude > 0 && EnterAddress.Longitude > 0 ? EnterAddress.Latitude : position.Latitude, EnterAddress.Latitude > 0 && EnterAddress.Longitude > 0 ? EnterAddress.Longitude : position.Longitude),
                            //                                        Distance.FromKilometers(2)).WithZoom(3));

                        }
                    });
                }
                CurrentChoise = 1;
            }
            catch (Exception ex)
            {

            }
            
        }
        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
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
                            EnterAddress = postions.First();
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

                                //MyMap.Pins.Remove(currentPin);
                                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Positionaddress.Latitude,
                                          Positionaddress.Longitude), Distance.FromMiles(0.8)));
                                Constants.Companylat= Positionaddress.Latitude;
                                Constants.Companylong = Positionaddress.Longitude;
                                CurrentLocationMap.Latitude = Positionaddress.Latitude;
                                CurrentLocationMap.Longitude = Positionaddress.Longitude;
                                UserDialogs.Instance.HideLoading();
                            });
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                UserDialogs.Instance.ShowError(AppResources.locationnotfount);
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

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new ProjectsPage());
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            getCurrentLocation(); 
        }

       
        private void MyMap_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var m = (Xamarin.Forms.GoogleMaps.Map)sender; 
            if (m.VisibleRegion != null) {
                Constants.Latitude = m.VisibleRegion.Center.Latitude.ToString();
                Constants.Latitude = m.VisibleRegion.Center.Latitude.ToString();
                //LoadAllDataInMap();
            }
        }

        private async void MyMap_CameraIdled(object sender, CameraIdledEventArgs e)
        {
            try
            {
                if (Count >= 0)
                {


                    AddModel data = new AddModel();
                    CameraPosition cameraPosition = e.Position;
                    double currentZoom = cameraPosition.Zoom;
                    var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(5000));
                    CurrentLocationMap = await Geolocation.GetLocationAsync(request);

                    double distance =
               calculateDistance(lat1: CurrentLocationMap.Latitude, lon1: CurrentLocationMap.Longitude, lat2: cameraPosition.Target.Latitude, lon2: cameraPosition.Target.Longitude);
                    if (distance >= 10)
                    {


                        var constat = Constants.PropertyType;
                        data = await webService.GetAllAdvertisements(new Models.AdvertisementInputModel { Name = "", AgreementStatus = Constants.ArgmentStatus, Type = Constants.PropertyType, CityId = Constants.CityId, Parking = Constants.Parking, Furnished = Constants.Furnished, Decoration = Constants.FinishedId, Rooms = Constants.Rooms, StreetOrCompund = Constants.Street, PriceFrom = Constants.PriceFrom, PriceTo = Constants.PriceTo, AreaFrom = Constants.AreaFrom, AreaTo = Constants.AreaTo, CompanyIdLocation = Constants.CompanyIdLocation, Latitude = cameraPosition.Target.Latitude, Longitude = cameraPosition.Target.Longitude });


                        // DisplayAlert("error", distance.ToString(), "ok");
                        //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(cameraPosition.Target.Latitude, cameraPosition.Target.Longitude),
                        //                 Distance.FromKilometers(2)).WithZoom(3));

                        Constants.ArgmentStatus = 0; Constants.PropertyType = 0; Constants.CityId = 0; Constants.Parking = null; Constants.Furnished = null; Constants.FinishedId = 0; Constants.Rooms = 0; Constants.Street = null; Constants.PriceFrom = 0; Constants.PriceTo = 0; Constants.AreaFrom = 0; Constants.AreaTo = 0; Constants.Latitude = null; Constants.Longitude = null;
                        if (data.Result.Advertisements != null && data.Result.Advertisements.Count > 0)
                        {

                            Device.BeginInvokeOnMainThread(async () =>
                            {

                                foreach (var item in data.Result.Advertisements)
                                {
                                    //  await Task.Delay(500);
                                    Pin pinItem = new Pin()
                                    {
                                        Type = PinType.Place,
                                        Icon = BitmapDescriptorFactory.FromView(new mapIconPage(item)),
                                        //  Icon=default,
                                        Label = "",
                                        // ZIndex = item.ZIndex,
                                        Address = "",
                                        Position = new Position(item.Latitude ?? 30.033333, item.Longitude ?? 31.233334),
                                        Tag = item.Id,
                                    };

                                    MyMap.Pins.Add(pinItem);
                                }

                            });



                            Constants.AdvertisementParamter = 0;
                            UserDialogs.Instance.HideLoading();
                        }
                        else
                        {
                            if (Constants.SearchPropetry == true)
                            {
                                App.Current.MainPage.DisplayAlert("", AppResources.Thereisnoadvertisement, AppResources.ok);
                                Constants.SearchPropetry = null;
                            }
                        }



                        if (cameraPosition.Target != null)
                        {
                            CurrentLocationMap.Latitude = cameraPosition.Target.Latitude;
                            CurrentLocationMap.Longitude = cameraPosition.Target.Longitude;
                        }

                    }
                    
                }
                Count++;
            }
            catch (Exception ex)
            {

            }
       
           

          
        }

        void callRequestForGetData( double lat1,double lon1, double lat2,double lon2) {
    double distance =
        calculateDistance(lat1: lat1, lon1: lon1, lat2: lat2, lon2: lon2);
    if (distance >= 10) {
     
    
    } else {
            //     DisplayAlert("error", "distance less than 10km","ok");
}
  }
        double calculateDistance(  double lat1,  double lon1, double lat2, double lon2) 
        {
            try
            {
                var p = 0.017453292519943295;
                var a = 0.5 -
                    Math.Cos((lat2 - lat1) * p) / 2 +
                    Math.Cos(lat1 * p) * Math.Cos(lat2 * p) * (1 - Math.Cos((lon2 - lon1) * p)) / 2;

                var result = 12742 * Math.Asin(Math.Sqrt(a));
                // DisplayAlert("",result.ToString(),"ok");
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
   

    }
    private void MyMap_CameraMoving(object sender, CameraMovingEventArgs e)
        {
            CameraPosition cameraPosition = e.Position;
        }

        private async void MyMap_SelectedPinChanged(object sender, SelectedPinChangedEventArgs e)
        {
            try
            {
              if (e.SelectedPin != null) 
                {
                    Constants.NavigationParamter = e.SelectedPin.Tag;
                    e.SelectedPin.Label = "";
                    e.SelectedPin.Address = "";
                    await PopupNavigation.Instance.PushAsync(new PropertyDetailsPopUp());
                }
               
                
            }
            catch (Exception ex)
            {

            }
           
        }
        protected  override bool OnBackButtonPressed()
        {
             PopupNavigation.Instance.PopAsync();
           // App.Current.MainPage = new AppShell();
            // true or false to disable or enable the action
            return base.OnBackButtonPressed();
        }
    }
}