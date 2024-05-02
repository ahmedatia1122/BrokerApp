using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewBrokerApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public Command InitCommand { get; }
        public Command PersonDetailsCommand { get; }
        public Command LoadAllAdvertisementsCommand { get; }
        public Command SponsorsCommand { get; }

        private ObservableCollection<Advertisement> _addsItems;
        public ObservableCollection<Advertisement> AddsItems
        {
            get { return _addsItems; }
            set { SetProperty(ref _addsItems, value); }
        }
        public int? AgreementStatus { get; set; }
        private ObservableCollection<SponsorModel> _sponsorsItem;
        public ObservableCollection<SponsorModel> SponsorsItem
        {
            get { return _sponsorsItem; }
            set
            {
                _sponsorsItem = value;
                OnPropertyChanged();
            }
        }
        private List<ButtonModel> buttons;

        public List<ButtonModel> Buttons
        {
            get { return buttons; }
            set
            {
                if (buttons != value)
                {
                    buttons = value;
                    OnPropertyChanged("Buttons");
                }
            }
        }
        private ButtonModel _selectAll;

        public ButtonModel SelectAll
        {
            get { return _selectAll; }
            set
            {
                if (_selectAll != value)
                {
                    _selectAll = value;
                   
                }
            }
        }
        
        public CompanyDetailsInput _updatCompanyDetailsItem;
        public CompanyDetailsInput UpdatCompanyDetailsItem
        {
            get
            {
                return _updatCompanyDetailsItem;
            }
            set => SetProperty(ref _updatCompanyDetailsItem, value);

        }
        public HomeViewModel()
        {
            UpdatCompanyDetailsItem = new CompanyDetailsInput();
            Buttons = new List<ButtonModel>()
        {
            new ButtonModel() {ButtonText = AppResources.All, PropertyId = 0, ArgumentId = 0},
            new ButtonModel() {ButtonText = AppResources.ApartmentsforRent,PropertyId=1,ArgumentId=2 },
            new ButtonModel() {ButtonText = AppResources.ApartmentsforSale, PropertyId=1,ArgumentId=1 },
            new ButtonModel() {ButtonText = AppResources.VillasforRent, PropertyId=2,ArgumentId=2  },
            new ButtonModel() {ButtonText = AppResources.VillasforSale, PropertyId=2,ArgumentId=1},
            new ButtonModel() {ButtonText = AppResources.SummerChaletsforRent , PropertyId=3,ArgumentId=2},
            new ButtonModel() {ButtonText = AppResources.SummerChaletsforSale , PropertyId=3,ArgumentId=1},
            new ButtonModel() {ButtonText = AppResources.BuildingsforRent, PropertyId = 4, ArgumentId = 2},
            new ButtonModel() {ButtonText = AppResources.BuildingsforSale , PropertyId = 4, ArgumentId = 1},
            new ButtonModel() {ButtonText = AppResources.AdminOfficesforRent, PropertyId = 5, ArgumentId = 2},
            new ButtonModel() {ButtonText = AppResources.AdminOfficesforSale , PropertyId = 5, ArgumentId = 1},
            new ButtonModel() {ButtonText = AppResources.ShopsforRent, PropertyId = 6, ArgumentId = 2},
            new ButtonModel() {ButtonText = AppResources.ShopsforSale, PropertyId = 6, ArgumentId = 1},
            new ButtonModel() {ButtonText = AppResources.lands , PropertyId = 7, ArgumentId = 1}
        };

            InitCommand = new Command(InitCommandClicked);
                PersonDetailsCommand = new Command(async () => await GetSettings());

            SponsorsItem = new ObservableCollection<SponsorModel>();
            SponsorsCommand = new Command(async () => await ExecuteSponsorsCommand());
            AddsItems =new ObservableCollection<Advertisement>();
            //LoadAllAdvertisementsCommand = new Command(async () => { await ExecuteAllAdvertisementsListCommand(); });
            SelectAll = Buttons.FirstOrDefault();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async Task GetSettings()
        {
            try
            {
                PersonDetailsResponseModel result = new PersonDetailsResponseModel();
                CompanyDetailsResponseModel resultCompany = new CompanyDetailsResponseModel();

                switch (Constants.LoginType)
                {
                    case 0:
                        result = await WebService.GetSeekerSettings(Convert.ToInt64(Constants.UserId));
                        if (result?.Result?.Success != true && !string.IsNullOrEmpty(result?.Result?.Error))
                        {
                            IsLogin = false;
                        }
                        else if (result?.Result?.Success == true)
                        {
                            Constants.SeekerId = result.Result.Details.Id;
                            UserName = result.Result.Details.Name;
                            Email = result.Result.Details.EmailAddress;
                            Avatar = result.Result.Details.Avatar;
                            PhoneNumber = result.Result.Details.PhoneNumber;
                            IsWhatsApp = result.Result.Details.IsWhatsApped;
                            SecondMobile = result.Result.Details.SecondMobile;
                            Constants.MobileNumber = result.Result.Details.PhoneNumber;
                        }
                        break;
                    case 1:
                        result = await WebService.GetOwnerSettings(Convert.ToInt64(Constants.UserId));
                        if (result?.Result?.Success != true && !string.IsNullOrEmpty(result?.Result?.Error))
                        {
                            IsLogin = false;
                        }
                        else if (result?.Result?.Success == true)
                        {
                            Constants.OwnerId = result.Result.Details.Id;
                            UserName = result.Result.Details.Name;
                            Email = result.Result.Details.EmailAddress;
                            Avatar = result.Result.Details.Avatar;
                            PhoneNumber = result.Result.Details.PhoneNumber;
                            IsWhatsApp = result.Result.Details.IsWhatsApped;
                            SecondMobile = result.Result.Details.SecondMobile;
                            Constants.MobileNumber = result.Result.Details.PhoneNumber;
                        }
                        break;
                    case 2:
                        result = await WebService.GetBrokerSettings(Convert.ToInt64(Constants.UserId));
                        if (result?.Result?.Success != true && !string.IsNullOrEmpty(result?.Result?.Error))
                        {
                            IsLogin = false;
                        }
                        else if (result?.Result?.Success == true)
                        {
                            Constants.BrokerId = result.Result.Details.Id;
                            UserName = result.Result.Details.Name;
                            Email = result.Result.Details.EmailAddress;
                            Avatar = result.Result.Details.Avatar;
                            PhoneNumber = result.Result.Details.PhoneNumber;
                            IsWhatsApp = result.Result.Details.IsWhatsApped;
                            SecondMobile = result.Result.Details.SecondMobile;
                            Constants.MobileNumber = result.Result.Details.PhoneNumber;
                        }
                        break;
                    case 3:
                        resultCompany = await WebService.GetCompanySettings(Convert.ToInt64(Constants.UserId));
                        if (resultCompany?.Result?.Success != true && !string.IsNullOrEmpty(resultCompany?.Result?.Error))
                        {
                            IsLogin = false;
                        }
                        else if (resultCompany?.Result?.Success == true)
                        {
                            IsCompanyLogin = true;
                            Constants.CompanyId = resultCompany.Result.Details.Id;
                            UpdatCompanyDetailsItem.SecondMobile = resultCompany.Result.Details.SecondMobile;
                            UpdatCompanyDetailsItem.Logo = resultCompany.Result.Details.Avatar;
                            UpdatCompanyDetailsItem.BwLogo = resultCompany.Result.Details.BwLogo;
                            UpdatCompanyDetailsItem.CommericalAvatar = resultCompany.Result.Details.CommericalAvatar;
                            UpdatCompanyDetailsItem.About = resultCompany.Result.Details.About;
                            UpdatCompanyDetailsItem.Latitude = resultCompany.Result.Details.Latitude;
                            UpdatCompanyDetailsItem.Longitude = resultCompany.Result.Details.Longitude;
                            UpdatCompanyDetailsItem.Facebook = resultCompany.Result.Details.Facebook;
                            UpdatCompanyDetailsItem.Instagram = resultCompany.Result.Details.Instagram;
                            UpdatCompanyDetailsItem.Snapchat = resultCompany.Result.Details.Snapchat;
                            UpdatCompanyDetailsItem.Tiktok = resultCompany.Result.Details.Tiktok;
                            UpdatCompanyDetailsItem.Website = resultCompany.Result.Details.Website;
                            //UpdatCompanyDetailsItem.UserName = resultCompany.Result.Details.UserName;
                            UpdatCompanyDetailsItem.UserSurname = resultCompany.Result.Details.Name;
                            UpdatCompanyDetailsItem.UserEmailAddress = resultCompany.Result.Details.EmailAddress;
                            UpdatCompanyDetailsItem.UserPhoneNumber = resultCompany.Result.Details.PhoneNumber;
                            //UpdatCompanyDetailsItem.PackageId = resultCompany.Result.Details.PackageId;
                            UserName = resultCompany.Result.Details.Name;
                            Email = resultCompany.Result.Details.EmailAddress;
                            Avatar = resultCompany.Result.Details.Avatar;
                            Constants.CompanyBalance = resultCompany.Result.Details.Balance??0;
                            Constants.MobileNumber = resultCompany.Result.Details.PhoneNumber;

                        }
                        break;

                }



            }
            catch (Exception ex)
            {

            }
        }
        private async void InitCommandClicked(object obj)
        {
            try
            {
                Shell.Current.BindingContext = this;
                if (Application.Current.Properties.ContainsKey("TokenAccess"))
                {
                    if (Application.Current.Properties["TokenAccess"] != null)
                    {
                        Constants.TokenH = Application.Current.Properties["TokenAccess"].ToString();
                        Constants.LoginType = Convert.ToInt32(Application.Current.Properties["LoginType"].ToString());
                        Constants.UserId = Application.Current.Properties["UserId"].ToString();
                        IsLogin = true;
                        GetSettings();
                    }
                    if (Application.Current.Properties.ContainsKey("Lang") && Application.Current.Properties["Lang"] != null )
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            
                            Constants.SelectedIndex = Convert.ToInt32(Application.Current.Properties["Lang"]);
                            var lang = Constants.SelectedIndex == 1 ? "ar" : "en";
                            CultureInfo language = new CultureInfo(lang);
                            Thread.CurrentThread.CurrentUICulture = language;
                            AppResources.Culture = language;
                            var langService = DependencyService.Get<ILanguageManager>();
                            langService.ChangeLanguage((AppLanguage)Constants.SelectedIndex);
                            //Application.Current.MainPage = new AppShell();
                        });
                    }
                }
                else
                {
                   
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        private async Task ExecuteAllAdvertisementsListCommand()
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

                var res = await WebService.GetAllAdvertisements(new AdvertisementInputModel {Name="",AgreementStatus= AgreementStatus });
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    foreach (var item in res.Result.Advertisements)
                    {
                      
                        AddsItems.Add(item);
                    }
                  
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
        private async Task ExecuteSponsorsCommand()
        {

            try
            {
                
                if (IsBusy) return;
                SponsorsItem.Clear();
                var res = await WebService.GetAllSponsors();
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    foreach (var item in res.Result.Sponsors)
                    {

                        SponsorsItem.Add(item);
                    }
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

    }
}
