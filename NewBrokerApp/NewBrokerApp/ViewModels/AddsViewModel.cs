using Acr.UserDialogs;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.Services;
using NewBrokerApp.Views;
using NewBrokerApp.Views.Common;
using NewBrokerApp.Views.Company;
using NewBrokerApp.Views.Popup;
using NewBrokerApp.Views.PropertiesAds;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.OpenWhatsApp;
using Map = Xamarin.Essentials.Map;

namespace NewBrokerApp.ViewModels
{
    public class AddsViewModel : BaseViewModel
    {
        public Command LoadPropertiesAddsCommand { get; }
        public Command LoadAddDetailsCommand { get; }
        public Command LoadAddDetailsPopupCommand { get; }
        
        public Command AddAddFavouriteCommand { get; }
        public Command DeleteAddCommand { get; }
        public Command OpenDeleteAddCommand { get; }
        public Command ChangeAddStatusCommand { get; }
        public Command OpenAdLocationCommand { get; }
        public Command OpenCompanyLocationCommand { get; }
        public Command OpenAddDetailsCommand { get; }
      
        public Command LoadFavouritesAddsCommand { get; }
        public Command OpenDetailsCommand { get; }
        public Command ClearAllAddsCommand { get; }
        public Command CreateAddViewerCommand { get; }
        public Command OpenAddDetailPopUpCommand { get; }
        public Command RefreshItemsCommand { get; set; }
        public Command DeleteFavoriteCommand { get; }
        public Command DeleteAdSameCommand { get; set; }
        public Command OpenAddChartCommand { get; set; }
        public Command OpenWhatsAppForAddCommand { get; set; }
        public Command OpenFaceBookCompanyCommand { get; set; }
        public Command OpenSnapchatCompanyCommand { get; set; }
        public Command OpenInstgramCompanyCommand { get; set; }
        public Command OpentokCompanyCommand { get; set; }
        public Command LoadCompanyAdsCommand { get; set; }
        public Command OpenCallForAddCommand { get; set; }
        public Command LoadDataChartCommand { get; set; }
        public Command OpenDetailsFromAdCommand { get; set; }
     
        public Command LoadAdvertismentPointsCommand { get; set; }
        public ICommand RefreshCommand => new Command(async () =>
        {
            AddsItems.Clear();
            IsRefreshing = true;
            // Make network call here
            IsRefreshing = false;
            LoadPropertiesAddsCommand.Execute(true);
        });
        public ObservableCollection<Advertisement> _addsItems;
        public ObservableCollection<Advertisement> AddsItems
        {
            get { return _addsItems; }
            set
            {

                _addsItems = value;
                OnPropertyChanged();
            }
            //set { SetProperty(ref _addsItems, value); }
        }
        public ObservableCollection<dataChart> _dataChartItems;
        public ObservableCollection<dataChart> DataChartItems
        {
            get { return _dataChartItems; }
            set
            {

                _dataChartItems = value;
                OnPropertyChanged();
            }
           
        }
        public PointsResult _advertisementPointItems;
        public PointsResult AdvertisementPointItems
        {
            get { return _advertisementPointItems; }
            set
            {

                _advertisementPointItems = value;
                OnPropertyChanged();
            }

        }
        private ObservableCollection<Favourite> _favouritesItems;
        public ObservableCollection<Favourite> FavouritesItems
        {
            get { return _favouritesItems; }
            set
            {
               
                _favouritesItems = value;
                OnPropertyChanged();
            }
            //set { SetProperty(ref _favouritesItems, value); }
        }
        private ObservableCollection<Facilite> _facilitiesItems;
        public ObservableCollection<Facilite> FacilitiesItems
        {
            get { return _facilitiesItems; }
            set
            {

                _facilitiesItems = value;
                OnPropertyChanged();
            }
            //set { SetProperty(ref _favouritesItems, value); }
        }
        private AddDetailsModel _addDetailsItem;
        public AddDetailsModel AddDetailsItem
        {
            get { return _addDetailsItem; }
            set { SetProperty(ref _addDetailsItem, value); }
        }
        private AddViewerModel _addViewerItem;
        public AddViewerModel AddViewerItem
        {
            get { return _addViewerItem; }
            set { SetProperty(ref _addViewerItem, value); }
        }
        private DeleteAddResult _deleteAddItem;
        public DeleteAddResult DeleteAddItem
        {
            get { return _deleteAddItem; }
            set { SetProperty(ref _deleteAddItem, value); }
        }
        int _itemTreshold = 1;
        public int ItemTreshold
        {
            get { return _itemTreshold; }
            set { SetProperty(ref _itemTreshold, value); }
        }
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        public long FavouriteId { get; set; }
        public int day = 2;
        public int total = 10;
        private DateTime? _selectedStartDate = DateTime.Today;
        public DateTime? SelectedStartDate
        {
            get => _selectedStartDate;
            set => SetProperty(ref _selectedStartDate, value);
        }
        private List<DateTime> _selectedDates;
        public List<DateTime> SelectedDates
        {
            get => _selectedDates;
            set => SetProperty(ref _selectedDates, value);
        }
        private List<DateTime> _nextSelectedDates;
        public List<DateTime> NextSelectedDates
        {
            get => _nextSelectedDates;
            set => SetProperty(ref _nextSelectedDates, value);
        }
        private string _location;
        public string Location
        {
            get
            {
                return _location;
            }
            set => SetProperty(ref _location, value);

        }
        private bool _showAdvertiser;
        public bool ShowAdvertiser
        {
            get
            {
                return _showAdvertiser;
            }
            set => SetProperty(ref _showAdvertiser, value);

        }
        public bool _showSellAndRent;
        public bool ShowSellAndRent
        {
            get { return _showSellAndRent; }
            set
            {

                _showSellAndRent = value;
                OnPropertyChanged();
            }

        }
        public string _showRentValue;
        public string ShowRentValue
        {
            get { return _showRentValue; }
            set
            {

                _showRentValue = value;
                OnPropertyChanged();
            }

        }
       public bool _showMonth;
        public bool ShowMonth
        {
            get { return _showMonth; }
             set
            {

                _showMonth = value;
                OnPropertyChanged();
            }

        }
        public string _showFav;
        public string ShowFav
        {
            get { return _showFav; }
            set
            {

                _showFav = value;
                OnPropertyChanged();
            }

        }
        public bool _showInstallment;
        public bool ShowInstallment
        {
            get { return _showInstallment; }
            set
            {

                _showInstallment = value;
                OnPropertyChanged();
            }

        }
        public bool _showGarden;
        public bool ShowGarden
        {
            get { return _showGarden; }
            set
            {

                _showGarden = value;
                OnPropertyChanged();
            }

        }
        public string _buildingDate;
        public string BuildingDate
        {
            get { return _buildingDate; }
            set
            {

                _buildingDate = value;
                OnPropertyChanged();
            }

        }
        public bool _noAds;
        public bool NoAds
        {
            get { return _noAds; }
            set
            {
                _noAds = value;
                OnPropertyChanged();
            }
        }
        public bool _noFavourite;
        public bool NoFavourite
        {
            get { return _noFavourite; }
            set{ _noFavourite = value;  OnPropertyChanged();}
        }
        public bool _showShop;
        public bool ShowShop
        {
            get { return _showShop; }
            set { _showShop = value; OnPropertyChanged(); }
        }
        public bool _showLand;
        public bool ShowLand
        {
            get { return _showLand; }
            set { _showLand = value; OnPropertyChanged(); }
        }
        public bool _showApparment;
        public bool ShowApparment
        {
            get { return _showApparment; }
            set { _showApparment = value; OnPropertyChanged(); }
        }
        public bool _showAdmin;
        public bool ShowAdmin
        {
            get { return _showAdmin; }
            set { _showAdmin = value; OnPropertyChanged(); }
        }

        public bool _showBuilding;
        public bool ShowBuilding
        {
            get { return _showBuilding; }
            set { _showBuilding = value; OnPropertyChanged(); }
        }

        public AddsViewModel()
        {
            ShowMonth = false;
            ShowBuilding = false;
            ShowAdmin = false;
            ShowLand = false;
            ShowShop = false;
            NoAds = false;
            NoFavourite = false;
            ShowInstallment = false;
            FacilitiesItems = new ObservableCollection<Facilite>();
            AdvertisementPointItems = new PointsResult();
            DataChartItems = new ObservableCollection<dataChart>();
            SelectedDates =new List<DateTime>();
            NextSelectedDates = new List<DateTime>();
            AddDetailsItem = new AddDetailsModel();
            AddViewerItem = new AddViewerModel();
            DeleteAddItem =new DeleteAddResult();
            AddsItems =new ObservableCollection<Advertisement>();
            FavouritesItems = new ObservableCollection<Favourite>();
           // RefreshCommand = new Command(() => ItemsTresholdReached());
            LoadPropertiesAddsCommand = new Command(async () => { await ExecuteAllAddsListCommand(); });
            DeleteAddCommand = new Command(ExecuteDeleteAddCommand);

            OpenDeleteAddCommand  = new Command<Advertisement>(async (item) =>await ExecuteOpenDeleteAddCommand(item));
            LoadAddDetailsCommand = new Command(async ()=> await ExecuteAddDetailsCommand());
            LoadAddDetailsPopupCommand = new Command(async () => await ExecuteAddDetailsPopupCommand());
            LoadCompanyAdsCommand = new Command(async () => await ExecuteLoadCompanyAdsCommand());
            ChangeAddStatusCommand = new Command<Advertisement>(async (item) => await ExecuteChangeAddStatusCommand(item));
            OpenAddDetailsCommand = new Command<Advertisement>(async (item) => await ExecuteOpenAddDetailCommand(item));
            OpenAdLocationCommand = new Command<Advertisement>(async (item) => await ExecuteOpenLocationPopupCommand(item));
            OpenDetailsFromAdCommand = new Command<Advertisement>(async (item) => await ExecuteOpenDetailFromAdsCommand(item));
            OpenCompanyLocationCommand = new Command(async () =>await ExecuteOpenCompanyLocationPopupCommand());

            AddAddFavouriteCommand = new Command(async () => await ExecuteFavouriteAddCommand());
            LoadFavouritesAddsCommand = new Command(async () => { await ExecuteAllFavouritesListCommand(); });
            OpenDetailsCommand = new Command<Favourite>(async (item) => await ExecuteOpenDetailCommand(item));
            ClearAllAddsCommand = new Command(async () => { await ExecuteClearAllAdsCommand(); });
            CreateAddViewerCommand = new Command(async () => { await ExecuteCreateAddViewerCommand(); });
            OpenAddDetailPopUpCommand = new Command(async () => { await ExecuteOpenAddDetailPopUpCommand(); });
            RefreshItemsCommand = new Command(() =>
            {
                ExecuteLoadItemsCommand();
                IsRefreshing = false;
            });
            DeleteFavoriteCommand=new Command(ExecuteDeleteFavoriteCommand);
            DeleteAdSameCommand = new Command(ExecuteDeleteAddNewCommand);
            OpenAddChartCommand= new Command<Advertisement>(async (item) => await ExecuteOpenChartCommand(item));
            OpenWhatsAppForAddCommand = new Command(async ()=>await ExecuteOpenWhatsAppForAddsCommand());
            OpenFaceBookCompanyCommand = new Command(async ()=>await ExecuteOpenFaceBookCompanyCommand());
            OpenSnapchatCompanyCommand = new Command(async ()=>await ExecuteOpenSnapchatCompanyCommand());
            OpenInstgramCompanyCommand = new Command(async ()=>await ExecuteInstgramCompanyCommand());
            OpentokCompanyCommand = new Command(async ()=>await ExecuteOpentokCompanyCommand());
        OpenCallForAddCommand = new Command(async () => await ExecuteOpenCallForAddsCommand());
            LoadDataChartCommand=new Command(async () => await ExecuteLoadDataChartsCommand());
            LoadAdvertismentPointsCommand= new Command(async () => await ExecuteLoadAdvertisementPointsCommand()); 
        }
        private async Task ExecuteLoadAdvertisementPointsCommand()
        {
            try
            {

                if (IsBusy) return;
                IsBusy = true;
                var data = await WebService.GetPoint();
                if (!data.Success)
                    await App.Current.MainPage.DisplayAlert("", AppResources.Alert, data?.Error);
                else if (data?.Result?.Success != true)
                {
                    await App.Current.MainPage.DisplayAlert("", AppResources.Alert, data?.Result?.Error);
                }
                else if (data?.Result?.Success == true)
                {
                    AdvertisementPointItems = data?.Result;
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task ExecuteLoadDataChartsCommand()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var data = await WebService.GetChart();
                if (!data.Success)
                    await App.Current.MainPage.DisplayAlert("", AppResources.Alert, data?.Error);
                else if (data?.Result?.Success != true)
                {
                    await App.Current.MainPage.DisplayAlert("", AppResources.Alert, data?.Result?.Error);
                }
                else if (data?.Result?.Success == true)
                {
                    foreach (var item in data.Result.Counts)
                    {
                        var x = new dataChart()
                        {
                            Day = day,
                            Value = Convert.ToInt32(item),
                        };
                        day += 2;
                        DataChartItems.Add(x);

                    }
                   
                    // chartViewLine.Chart = new LineChart { Entries = list, ValueLabelOrientation=Orientation.Horizontal};

                }
            });
        }
        private async Task ExecuteOpenCallForAddsCommand()
        {
            try
            {
                PhoneDialer.Open(AddDetailsItem.MobileNumber);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        
            private async Task ExecuteInstgramCompanyCommand()
        {
            try
            {
                await Browser.OpenAsync(AddDetailsItem.CompanyInstagram, BrowserLaunchMode.SystemPreferred);
            }
            catch
            {

            }
        }
        
            private async Task ExecuteOpentokCompanyCommand()
        {
            try
            {
                await Browser.OpenAsync(AddDetailsItem.CompanyTiktok, BrowserLaunchMode.SystemPreferred);
            }
            catch
            {

            }
        }
      private async Task ExecuteLoadCompanyAdsCommand()
        {
            Constants.CompanyIdLocation = AddDetailsItem.CompanyId;
            Constants.Companylat = AddDetailsItem.CompanyLatitude;
            Constants.Companylong = AddDetailsItem.CompanyLongitude;
            App.Current.MainPage = new AppShell();
        }

        private async Task ExecuteOpenSnapchatCompanyCommand()
        {
            try
            {
                await Browser.OpenAsync(AddDetailsItem.CompanySnapchat, BrowserLaunchMode.SystemPreferred);
            }
            catch
            {

            }
        }
        private async Task ExecuteOpenFaceBookCompanyCommand()
        {
            try
            {
                await Browser.OpenAsync(AddDetailsItem.CompanyFacebook, BrowserLaunchMode.SystemPreferred);
            }
            catch
            {

            }
        }
        private async Task ExecuteOpenWhatsAppForAddsCommand()
        {
            try
            {
                if (AddDetailsItem.WhatsApped==true)
                {
                    Chat.Open("+2"+AddDetailsItem.MobileNumber);
                }
                else
                {
                    var mobile = AddDetailsItem.SecondMobileNumber!=null ? AddDetailsItem.SecondMobileNumber: AddDetailsItem.MobileNumber;
                    Chat.Open("+2" + mobile, "");
                }
                //Chat.Open("+2"+AddDetailsItem.SecondMobileNumber ?? AddDetailsItem.MobileNumber, "");
              //  Device.OpenUri(new Uri("whatsapp://send?phone"+ AddDetailsItem.SecondMobileNumber ?? AddDetailsItem.MobileNumber));
               // await Browser.OpenAsync(AddDetailsItem.SecondMobileNumber?? AddDetailsItem.MobileNumber, BrowserLaunchMode.SystemPreferred);
            }
            catch
            {

            }
        }
        private async Task ExecuteOpenChartCommand(Advertisement item)
        {
            try 
            {
                Constants.NavigationParamter = item.Id;
                Constants.title = item.Title;
                await PopupNavigation.Instance.PushAsync(new ChartPopupPage());
            }
            catch
            {

            }
        }
        private async void ExecuteDeleteFavoriteCommand()
        {
            try 
            {
                var res = await WebService.DeleteFavourite(FavouriteId);
                if (!res.success)
                {
                    ShowMessege(AppResources.Alert, res?.error);
                }
                else if (res?.success == true)
                {
                    
                    LoadFavouritesAddsCommand.Execute(true);
                }
            } 
            catch
            {

            }
        }
        private async Task ExecuteClearAllAdsCommand()
        {

            try
            {

                var res = await WebService.ClearAllAdds();
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                 //   await PopupNavigation.Instance.PopAsync();
                    LoadPropertiesAddsCommand.Execute(true);
                }





            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
        private async Task ExecuteOpenAddDetailCommand(Advertisement item)
        {
            Constants.NavigationParamter = item.Id;
            Constants.AdvertisementParamter = item;
            Constants.NavigationProject = null;
            Constants.PackageId = null;
            Constants.Balance = null;
            if (Constants.LoginType == 3)
            {

                switch (item.TypeId)
                {
                    case 1:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditApartmentDetailsPage());
                        break;
                    case 2:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditVillaDetailsPage());
                        break;
                    case 3:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditChaletDetailsPage());
                        break;
                    case 4:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditBuildingDetailsPage());
                        break;
                    case 5:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditAdminOfficeDetailsPage());
                        break;
                    case 6:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditShopDetailsPage());
                        break;
                    case 7:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditLandDetailsPage());
                        break;
                }
            }
            else
            {
                switch (item.TypeId)
                {
                    case 1:
                        await Shell.Current.Navigation.PushAsync(new EditApartmentDetailsPage());
                    break;
                    case 2:
                        await Shell.Current.Navigation.PushAsync(new EditVillaDetailsPage());
                    break;
                    case 3:
                        await Shell.Current.Navigation.PushAsync(new EditChaletDetailsPage());
                    break;
                    case 4:
                        await Shell.Current.Navigation.PushAsync(new EditBuildingDetailsPage());
                    break;
                    case 5:
                        await Shell.Current.Navigation.PushAsync(new EditAdminOfficeDetailsPage());
                    break;
                    case 6:
                        await Shell.Current.Navigation.PushAsync(new EditShopDetailsPage());
                    break;
                    case 7:
                        await Shell.Current.Navigation.PushAsync(new EditLandDetailsPage());
                    break;

                }
              

            }
            //AddViewerItem.AdvertisementId = item.Id;
            //AddViewerItem.UserId = Convert.ToInt64(Constants.UserId) ;
            //CreateAddViewerCommand.Execute(true);
        }
        private async Task ExecuteOpenAddDetailPopUpCommand()
        {
            await Shell.Current.Navigation.PushAsync(new PropertyDetails());
            await PopupNavigation.Instance.PopAsync();
            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                AddViewerItem.AdvertisementId = Convert.ToInt32(Constants.NavigationParamter);
                AddViewerItem.UserId = Convert.ToInt64(Constants.UserId);
                CreateAddViewerCommand.Execute(true);
            }
        }
        private async Task ExecuteOpenLocationPopupCommand(Advertisement item)
        {
            await PopupNavigation.Instance.PushAsync(new LocationPage(item.Latitude,item.Longitude));
           
        }
        private async Task ExecuteOpenCompanyLocationPopupCommand()
        {
            await Map.OpenAsync(Convert.ToDouble(AddDetailsItem.CompanyLatitude ?? 30.6730758), Convert.ToDouble(AddDetailsItem.CompanyLongitude ?? 31.7197933), new MapLaunchOptions { NavigationMode = NavigationMode.None });

        }
        
        private async Task ExecuteOpenDetailFromAdsCommand(Advertisement item)
        {
            Constants.NavigationParamter = item.Id;
            await Shell.Current.Navigation.PushAsync(new PropertyDetails());
        }
        private async Task ExecuteOpenDetailCommand(Favourite item)
        {
            Constants.NavigationParamter = item.Id;
            await Shell.Current.Navigation.PushAsync(new PropertyDetails());
        }
        private async Task ExecuteAllAddsListCommand()
        {
            
                try
            {
                if (IsBusy) return;
                IsBusy = true;
                ListLength = 15;
                ItemTreshold = 1;
                if (PageIndex == 0)
                {
                    AddsItems.Clear();
                }

                var res = await WebService.GetAllAdds(new AddInputModel { });
                if (!res.Success)
                ShowMessege(AppResources.Alert, AppResources.AnErrorOccurredWhileExecutingYourRequest);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, AppResources.AnErrorOccurredWhileExecutingYourRequest);
                }
                else if (res?.Result?.Success == true)
                {
                    foreach (var item in res.Result.Advertisements)
                    {
                        item.IsplayImage = item.IsPublish == true ? "play" : "playy";
                        item.IsStopImage = item.IsPublish == false ? "pause" : "stop";
                        item.StatusPublish = item.IsPublish == true ? AppResources.Active :AppResources.inActive;
                        item.ImageStatusPublish = item.IsPublish == true ? "time" : "clockGray";
                        item.StatusApproved = item.IsApproved ==true? AppResources.Approved : AppResources.Pending;
                        AddsItems.Add(item);

                    }
                    NoAds = AddsItems.Count > 0 ? false : true;
                }
                if (res.Result.Advertisements.Count < ListLength)
                {
                    ItemTreshold = -1;
                    return;
                }
                PageIndex++;

            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
         
        }

        private async Task ExecuteAllFavouritesListCommand()
        {

            try
            {
                if (IsBusy) return;
                IsBusy = true;
                ListLength = 15;
                ItemTreshold = 1;
                if (PageIndex == 0)
                {
                    FavouritesItems.Clear();
                }

                var res = await WebService.GetAllFavourites(new FavouritesInputModel {UserId=Convert.ToInt32(Constants.UserId) });
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    foreach (var item in res.Result.Favorites)
                    {
                       
                        FavouritesItems.Add(item);
                    }
                    NoFavourite = FavouritesItems.Count > 0 ? false : true;
                }
                if (res.Result.Favorites.Count < ListLength)
                {
                    ItemTreshold = -1;
                    return;
                }
                PageIndex++;

            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
        private async Task ExecuteAddDetailsPopupCommand()
        {

            try
            {
                if (IsBusy) return;
                IsBusy = true;
                var res = await WebService.GetAddDetails(Convert.ToInt32(Constants.NavigationParamter.ToString()));
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    ShowFav = AddDetailsItem.IsFavourite == true ? "favoriteFill.svg" : "FavoriteEmpty.svg";
                    AddDetailsItem = res.Result.Details;
                    ShowSellAndRent = AddDetailsItem.AgreementStatusId == 2 ? true : false;
                    ShowRentValue = AddDetailsItem.AgreementStatusId == 2 && AddDetailsItem.ChaletRentType!=null ? GetRentValue(AddDetailsItem.ChaletRentType??0) : GetRentValueName(AddDetailsItem.Rent??0);
                }



            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
        private string GetRentValueName(int value)
        {
            string result = "";
            switch (value)
            {
                case 1:
                    result = AppResources.monthly;
                    break;
                case 2:
                    result = AppResources.midterm;
                    break;
                case 3:
                    result = AppResources.annual;
                    break;
                default:
                    result = "";
                    break;
            }

            return result;
        }
        private string GetRentValue(int value)
        {
            string result="";
            switch (value)
            {
                case 1:
                    result = AppResources.Day;
                        break;
                    case 2:
                    result = AppResources.Week;
                    break;
            }
                
            return result;
        }
        private void GetPropertyType(int value)
        {
            
            switch (value)
            {
                case 4:
                    ShowBuilding = true;
                    break;
                case 5:
                    ShowAdmin =true;
                    break;
                case 6:
                    ShowShop = true;
                    break;
                case 7:
                    ShowLand = true;
                    break;

                default:
                    ShowApparment = true;
                    break;
            }

           
        }
        private async Task ExecuteAddDetailsCommand()
        {

            try
            {
                if (IsBusy) return;
                IsBusy = true;
                var res = await WebService.GetAddDetails(Convert.ToInt32(Constants.NavigationParamter.ToString()));       
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    AddDetailsItem = res.Result.Details;
                    ShowMonth = AddDetailsItem.numOfMonths == 2 ? true : false;
                    ShowFav = AddDetailsItem.IsFavourite == true ? "favoriteFill.svg" : "FavoriteEmpty.svg";
                    
                    AddDetailsItem.ShowSellOrRent = AddDetailsItem.AgreementStatusId == 2 ? true : false;
                    ShowSellAndRent = AddDetailsItem.AgreementStatusId == 2 ? true : false;
                    ShowInstallment = AddDetailsItem.AgreementStatusId == 1 && AddDetailsItem.IsCompany == true ? true : false;
                    ShowGarden = AddDetailsItem.GardenArea != null ? true : false;
                    BuildingDate = AddDetailsItem.BuildingDate != null ? AddDetailsItem.BuildingDate.Value.ToString("dd-MM-yyyy") : "";
                     ShowRentValue = AddDetailsItem.AgreementStatusId == 2 &&AddDetailsItem.ChaletRentType!=null? GetRentValue(AddDetailsItem.ChaletRentType??0) : GetRentValueName(AddDetailsItem.Rent ?? 0);
                    GetPropertyType(AddDetailsItem.Type);
                    await GetLocation( AddDetailsItem.Latitude?? 30.033333, AddDetailsItem.Longitude?? 31.233334);
                    if(AddDetailsItem.IsCompany == true)
                    {
                        ShowAdvertiser = false;
                    }
                    if (AddDetailsItem.AdvertisementBookings.Count > 0)
                    {
                        int currentMonth = DateTime.Now.Month;
                        SelectedDates = AddDetailsItem.AdvertisementBookings.Where(d => d.Month == currentMonth).ToList();
                        NextSelectedDates = AddDetailsItem.AdvertisementBookings.Where(d => d.Month != currentMonth).ToList();
                    }
                    var list = new ObservableCollection<Facilite>();
                    foreach (var item in AddDetailsItem.Facilites)
                    {
                        if (item.Avatar.Contains("water")) 
                        {
                            item.AvatarSvg = "blueWater.svg";
                            list.Add(item);
                        }
                        else if (item.Avatar.Contains("electry"))
                        {
                            item.AvatarSvg = "blueElectriy.svg";
                            list.Add(item);
                        }
                        else if (item.Avatar.Contains("internet"))
                        {
                            item.AvatarSvg = "blueInternet.svg";
                            list.Add(item);
                        }
                        else if (item.Avatar.Contains("phone"))
                        {
                            item.AvatarSvg = "bluePhone.svg";
                            list.Add(item);
                        }
                        else if (item.Avatar.Contains("gas"))
                        {
                            item.AvatarSvg = "blueGas.svg";
                            list.Add(item);
                        }

                    }
                    //AddDetailsItem.NewFacilites= list;
                    FacilitiesItems = list;
                    // AddDetailsItem.ShowChalet= AddDetailsItem.Type==3 ? true: false;
                }
               
           

            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
        
        private async Task ExecuteOpenDeleteAddCommand(Advertisement item)
        {
            Constants.NavigationParamter = item.Id;
            //await Shell.Current.Navigation.PushPopupAsync(new DeleteAdPopup());
            try
            {

                var res = await WebService.DeleteAdd(Convert.ToInt64(Constants.NavigationParamter.ToString()));
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    //await PopupNavigation.Instance.PopAsync();
                    await ExecuteAllAddsListCommand();
                    LoadPropertiesAddsCommand.Execute(true);
                    //IsRefreshing = true;
                    //RefreshCommand.Execute(true);
                }





            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void ExecuteDeleteAddNewCommand()
        {
            
           
            try
            {

                var res = await WebService.DeleteAdd(Convert.ToInt64(Constants.NavigationParamter.ToString()));
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    //await PopupNavigation.Instance.PopAsync();
                    await ExecuteAllAddsListCommand();
                    LoadPropertiesAddsCommand.Execute(true);
                    //IsRefreshing = true;
                    //RefreshCommand.Execute(true);
                }





            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void ExecuteDeleteAddCommand()
        {

            try
            {
         
                    var res = await WebService.DeleteAdd(Convert.ToInt64(Constants.NavigationParamter.ToString()));
                    if (!res.Success)
                        ShowMessege(AppResources.Alert, res?.Error);
                    else if (res?.Result?.Success != true)
                    {
                        ShowMessege(AppResources.Alert, res?.Result?.Error);
                    }
                    else if (res?.Result?.Success == true)
                    {
                        await PopupNavigation.Instance.PopAsync();
                await    ExecuteAllAddsListCommand();
                    LoadPropertiesAddsCommand.Execute(true);
                       //IsRefreshing = true;
                       //RefreshCommand.Execute(true);
                    }


         
          

            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
        private async Task ExecuteFavouriteAddCommand()
        {

            try
            {
                if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
                {
                    if (ShowFav.Contains("FavoriteEmpty"))
                    {


                        var res = await WebService.CreateFavourite(new CreateFavouriteInput()
                        {
                            AdvertisementId = Convert.ToInt64(Constants.NavigationParamter.ToString()),
                            UserId = Convert.ToInt64(Constants.UserId)
                        });
                        if (!res.Success)
                            ShowMessege(AppResources.Alert, res?.Error);
                        else if (res?.Result?.Success != true)
                        {
                            ShowMessege(AppResources.Alert, res?.Result?.Error);
                        }
                        else if (res?.Result?.Success == true)
                        {
                            // await ExecuteAddDetailsCommand();
                            Constants.IsFavourite = true;
                            ShowFav = "favoriteFill.svg";
                           // ShowMessege(AppResources.Alert, AppResources.PropertyAddSucessfully);


                        }
                    }
                    else
                    {
                        var res = await WebService.DeleteFavouriteByAdvertiserId(Convert.ToInt64(Constants.NavigationParamter.ToString()));
                        if (!res.success)
                        {
                            ShowMessege(AppResources.Alert, res?.error);
                        }
                        else if (res?.success == true)
                        {

                            Constants.IsFavourite = false;
                            ShowFav = "FavoriteEmpty.svg";
                        }

                    }
                }
                else
                {
                    await Application.Current.MainPage.Navigation.PopPopupAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }




            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
        private async Task ExecuteChangeAddStatusCommand(Advertisement item)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                Constants.PaymentStatus = 0;
                var res = await WebService.ChangeAddStatus(item.Id);
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var advertise = await WebService.GetAdvertiseForEdit(item.Id);
                        if (!advertise.Success)
                            ShowMessege(AppResources.Alert, advertise?.Error);
                        else if (advertise?.Result?.Success != true)
                        {
                            ShowMessege(AppResources.Alert, advertise?.Result?.Error);
                        }
                        else if (advertise?.Result?.Success == true)
                        {
                            Constants.NavigationAdvertiserModel = advertise.Result.Advertisement;
                            Constants.NavigationParamter = new DefinitionModel { Id = advertise.Result.Advertisement.Type };
                            if(Constants.LoginType == 3)
                            await Shell.Current.Navigation.PushAsync(new PaymentCompanyPage());
                            else
                                await Shell.Current.Navigation.PushAsync(new PaymentPage());

                        }
                    });

                    // await PopupNavigation.Instance.PopAsync();
                    UserDialogs.Instance.HideLoading();
                }
                else if (res?.Result?.Success == true)
                {
                        LoadPropertiesAddsCommand.Execute(true);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                IsBusy = false;
                Debug.WriteLine(ex);

            }
            finally
            {
                UserDialogs.Instance.HideLoading();
                IsBusy = false;
            }
        }
        private async Task ExecuteCreateAddViewerCommand()
        {

            try
            {
                var res = await WebService.CreateAddViewer(AddViewerItem);
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                if (AddsItems.Count == 0)
                    AddsItems.Clear();

                var res = await WebService.GetAllAdds(new AddInputModel { });

                foreach (var item in res.Result.Advertisements)
                {
                    item.IsplayImage = item.IsPublish == true ? "" : "";
                    item.IsStopImage = item.IsPublish == false ? "" : "";
                    AddsItems.Add(item);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        void ItemsTresholdReached()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            Task.Run(async () =>
            {
                try
                {

                    if (AddsItems.Count == 0)
                        AddsItems.Clear();

                    var res = await WebService.GetAllAdds(new AddInputModel { });

                    foreach (var item in res.Result.Advertisements)
                    {
                        AddsItems.Add(item);
                    }
                    IsBusy = false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }
        public async Task GetLocation(double latitude, double longitude)
        {
            Geocoder geoCoder = new Geocoder();
            var address = await geoCoder.GetAddressesForPositionAsync(new Position(latitude,longitude));
            string alladdString = "";
            Location location = new Location(latitude,longitude);
            var placemark = await Geocoding.GetPlacemarksAsync(location);
            var dd = address.FirstOrDefault();
            var lists = dd.Split(',');
            var allString = lists.FirstOrDefault();
            var allasddString = allString.Split(',');
            alladdString = allasddString.FirstOrDefault();
            var Province = placemark.ToList();
            var Provsince = Province[0];
            // الحصول على اسم البلد
            var Country = Provsince.CountryName;
            var Locality = Provsince.Locality;
            // الحصول على اسم المحافظة
            var Provinces = Provsince.AdminArea.Replace(" Governorate", "");
            // الحصول على اسم المدينة
            var City = Provsince.SubAdminArea;
            // الحصول على اسم الشارع
            if (Provsince.Thoroughfare == null)
            {
                alladdString = alladdString;
            }
            else
            {
                alladdString = Provsince.Thoroughfare;
            }
            Location =  City + "," + Provinces;
        }

    }
}
