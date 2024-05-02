using Acr.UserDialogs;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.Views;
using NewBrokerApp.Views.Company;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;


namespace NewBrokerApp.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public Command UpdateAccountCommand { get; }
        public Command UpdateCompanyAccountCommand { get; }
        public Command UpdateCompanyWalletCommand { get; }
        public Command DeleteAccountCommand { get; }
        public Command PersonDetailsCommand { get; }
        public Command LoadChangePasswordCommand { get; set; }
        public Command OpenVerifyMobileNumberPageCommand { get; }
        public Command OpenCompanyVerifyMobileNumberPageCommand { get; }
        public Command OpenPersonalDataPageCommand { get; }
        public Command LoadAllPackagesCommand { get; }
        public Command LoadGetCompanyPackageDetailsCommand { get; }
        public Command LoadGetWalletCompanyPackageDetailsCommand { get; }
        public Command SendOtpMobileCommand { get; }
        public Command LoadPaymentUrlPage { get; }
        public Command LoadAllNotification { get; }
        public ObservableCollection<NotificationModel> _notificationItems;
        public ObservableCollection<NotificationModel> NotificationItems
        {
            get
            {
                return _notificationItems;
            }
            set => SetProperty(ref _notificationItems, value);

        }
        private PersonDetailsModel _personDetailsItem;
        public PersonDetailsModel PersonDetailsItem
        {
            get
            {
                return _personDetailsItem;
            }
            set => SetProperty(ref _personDetailsItem, value);

        } 
        private PackageModel _packageDetailsItem;
        public PackageModel PackageDetailsItem
        {
            get
            {
                return _packageDetailsItem;
            }
            set => SetProperty(ref _packageDetailsItem, value);

        }
        private PackageHistoryDetails _walletPackageDetailsItem;
        public PackageHistoryDetails WalletPackageDetailsItem
        {
            get{return _walletPackageDetailsItem;}
            set => SetProperty(ref _walletPackageDetailsItem, value);
        }
      
        public ObservableCollection<PackagesHistory> _packagesHistoryItems;
        public ObservableCollection<PackagesHistory> PackagesHistoryItems
        {
            get
            {
                return _packagesHistoryItems;
            }
            set
            {
                _packagesHistoryItems = value;
                OnPropertyChanged(nameof(PackagesHistoryItems));
            }

        }
        

        private DeleteAccountResponse _deleteAccountItem;
        public DeleteAccountResponse DeleteAccountItem
        {
            get
            {
                return _deleteAccountItem;
            }
            set => SetProperty(ref _deleteAccountItem, value);

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
        public PersonDetailsInput _updatPersonDetailsItem;
        public PersonDetailsInput UpdatPersonDetailsItem
        {
            get
            {
                return _updatPersonDetailsItem;
            }
            set => SetProperty(ref _updatPersonDetailsItem, value);

        }
        public CompanyDetailsModel _companyDetailsItem;
        public CompanyDetailsModel CompanyDetailsItem
        {
            get
            {
                return _companyDetailsItem;
            }
            set => SetProperty(ref _companyDetailsItem, value);

        }
        public string _commericalAvatarItem;
        public string CommericalAvatarItem
        {
            get
            {
                return _commericalAvatarItem;
            }
            set => SetProperty(ref _commericalAvatarItem, value);

        } 
        public string _bwLogoItem;
        public string BwLogoItem
        {
            get
            {
                return _bwLogoItem;
            }
            set => SetProperty(ref _bwLogoItem, value);

        }
        public string _logoItem;
        public string LogoItem
        {
            get
            {
                return _logoItem;
            }
            set => SetProperty(ref _logoItem, value);

        }
        public bool _showProfilePictureCompeny;
        public bool ShowProfilePictureCompeny
        {
            get
            {
                return _showProfilePictureCompeny;
            }
            set => SetProperty(ref _showProfilePictureCompeny, value);

        }
        public bool _showProfilePicture;
        public bool ShowProfilePicture
        {
            get
            {
                return _showProfilePicture;
            }
            set => SetProperty(ref _showProfilePicture, value);

        }
        public int _heightRequest;
        public int HeightRequest
        {
            get { return _heightRequest; }
            set
            {
                SetProperty(ref _heightRequest, value);
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
        public UpdateUserPasswordModel _changePassword;
        public UpdateUserPasswordModel ChangePassword
        {
            get { return _changePassword; }
            set { SetProperty(ref _changePassword, value); }
        }
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        public ObservableCollection<PackageModel> _packageItems;
        public ObservableCollection<PackageModel> PackageItems
        {
            get { return _packageItems; }
            set { SetProperty(ref _packageItems, value); }
        }
        private bool _noNotification;
        public bool NoNotification
        {
            get { return _noNotification; }
            set
            {
                _noNotification = value;
                OnPropertyChanged(nameof(NoNotification));
            }
        }
        private int _walletHeight;
        public int WalletHeight
        {
            get { return _walletHeight; }
            set
            {
                _walletHeight = value;
                OnPropertyChanged(nameof(_walletHeight));
            }
        }
        private bool _updateMobile;
        public bool UpdateMobile
        {
            get { return _updateMobile; }
            set
            {
                _updateMobile = value;
                OnPropertyChanged(nameof(_updateMobile));
            }
        }
        public AccountViewModel()
        {
            UpdateMobile = false;
            WalletHeight = 200;
            WalletPackageDetailsItem = new PackageHistoryDetails();
            PackagesHistoryItems = new ObservableCollection<PackagesHistory>();
            NoNotification = false;
            NotificationItems = new ObservableCollection<NotificationModel>();
            PackageItems = new ObservableCollection<PackageModel>();
            PersonDetailsItem = new PersonDetailsModel();
            UpdatCompanyDetailsItem = new CompanyDetailsInput();
            CompanyDetailsItem = new CompanyDetailsModel();
            UpdatPersonDetailsItem = new PersonDetailsInput();
            PersonDetailsCommand = new Command(async () => await GetSettings());
            UpdateAccountCommand = new Command(async () => { await ExecutUpdateAccountCommand(); });
            UpdateCompanyAccountCommand = new Command(async () => { await ExecutUpdateCompanyAccountCommand(); });
            UpdateCompanyWalletCommand = new Command(async () => { await ExecutUpdateCompanyWalletCommand(); });

            LoadChangePasswordCommand = new Command(async () => await LoadPrepareChangePassword());
            DeleteAccountCommand = new Command(async () => await ExecuteDeleteAccountCommand());
            DeleteAccountItem = new DeleteAccountResponse();
            ChangePassword = new UpdateUserPasswordModel();
            OpenVerifyMobileNumberPageCommand = new Command(OpenVerifyMobileNumberPage);
            OpenCompanyVerifyMobileNumberPageCommand = new Command(OpenComoanyVerifyMobileNumberPage);
            OpenPersonalDataPageCommand = new Command(OpenPersonalDataPage);
            LoadAllPackagesCommand = new Command(async () => { await ExecuteGetAllPackagesCommand(); });
            LoadGetCompanyPackageDetailsCommand = new Command(async () => { await ExecuteGetCompanyPackageDetailsCommand(); });
            SendOtpMobileCommand = new Command(async () => { await ExecuteSendOtpMobileCommand(); });
         //   LoadPaymentUrlPage = new Command(async () => { await ExecuteLoadPaymentUrl(); });
       LoadAllNotification = new Command(async () => { await ExecuteLoadNotificationCommand(); });
            LoadGetWalletCompanyPackageDetailsCommand = new Command(async () => { await ExecuteGetCompanyWalletDetailsCommand(); });
        }
       private async Task ExecuteLoadNotificationCommand()
        {
            try
            {
                var result = await WebService.GetAllNotification();
                if (result.Success == true)
                {
                    foreach (var item in result.Result.Notifications)
                    {
                        NotificationItems.Add(item);
                    }
                    NoNotification = NotificationItems.Count > 0 ? false : true;
                }
                else
                {
                    ShowMessege(AppResources.Alert, result.Result.Error);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private async Task ExecuteSendOtpMobileCommand()
        {
            try
            {
                var result = await WebService.CheckPhoneNumberOtp();
                if (result.Result.IsSuccess == true)
                {
                    Constants.UserVerifyCode = result.Result.Otp.ToString();

                }
                else
                {
                    ShowMessege(AppResources.Alert, result.Result.Message);
                }

            }
            catch (Exception)
            {

                throw;
            }
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
                            PersonDetailsItem = result.Result.Details;
                            ShowProfilePictureCompeny = false;
                            ShowProfilePicture = true;
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
                            PersonDetailsItem = result.Result.Details;
                            ShowProfilePictureCompeny = false;
                            ShowProfilePicture = true;
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
                            PersonDetailsItem = result.Result.Details;
                            ShowProfilePictureCompeny = false;
                            ShowProfilePicture = true;
                        }
                        break;
                    case 3:
                        resultCompany = await WebService.GetCompanySettings(Convert.ToInt64(Constants.UserId));
                        if (resultCompany?.Result?.Success != true && !string.IsNullOrEmpty(result?.Result?.Error))
                        {
                            IsLogin = false;
                        }
                        else if (resultCompany?.Result?.Success == true)
                        {
                            Constants.CompanyId = resultCompany.Result.Details.Id;
                            LogoItem = resultCompany.Result.Details.Avatar.Contains("notFound") ? "PictureStar.png" : resultCompany.Result.Details.Avatar;
                            BwLogoItem = resultCompany.Result.Details.BwLogo.Contains("notFound") ? "PictureStar.png" : resultCompany.Result.Details.BwLogo;
                            CommericalAvatarItem = resultCompany.Result.Details.CommericalAvatar.Contains("notFound") ? "PictureStar.png" : resultCompany.Result.Details.CommericalAvatar;
                            CompanyDetailsItem = resultCompany.Result.Details;
                            await GetLocation(CompanyDetailsItem.Latitude, CompanyDetailsItem.Longitude);
                            ShowProfilePictureCompeny = true;
                            ShowProfilePicture = false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async Task GetLocation(string latitude,string longitude)
        {
            Geocoder geoCoder = new Geocoder();
            var address = await geoCoder.GetAddressesForPositionAsync(new Position(Convert.ToDouble(latitude), Convert.ToDouble(longitude)));
            string alladdString = "";
            Location location = new Location(Convert.ToDouble(latitude), Convert.ToDouble(longitude));
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
            Location = Locality + "," + City + "," + Provinces;
        }
        private async Task ExecutUpdateAccountCommand()
        {

            try
            {
                UpdatPersonDetailsItem.Id = PersonDetailsItem.Id;
                UpdatPersonDetailsItem.UserName = PersonDetailsItem.Name;
                UpdatPersonDetailsItem.UserEmailAddress = PersonDetailsItem.EmailAddress;
                UpdatPersonDetailsItem.UserPhoneNumber = PersonDetailsItem.PhoneNumber;
                UpdatPersonDetailsItem.Avatar= PersonDetailsItem.PrfilAvatar != null ? await uploadFile(PersonDetailsItem.PrfilAvatar) : PersonDetailsItem.Avatar.Replace("https://brokerapi.nahrdev.website/Resources/UploadFiles/", "");
                UpdatPersonDetailsItem.IsWhatsApp = PersonDetailsItem.IsWhatsApped;
                UpdatPersonDetailsItem.SecondMobile = PersonDetailsItem.SecondMobile;
                if (string.IsNullOrEmpty(UpdatPersonDetailsItem.UserPhoneNumber))
                {
                    ShowMessege(AppResources.Alert, AppResources.InvalidPhone);
                }
                else if(!string.IsNullOrEmpty(UpdatPersonDetailsItem.UserPhoneNumber) && (UpdatPersonDetailsItem.UserPhoneNumber.Length != 11 || !UpdatPersonDetailsItem.UserPhoneNumber.StartsWith("01")))
                {
                  ShowMessege(AppResources.Alert, AppResources.phoneNumberformat);
                        
                }
                else if(string.IsNullOrEmpty(UpdatPersonDetailsItem.UserName))
                {
                    ShowMessege(AppResources.Alert, AppResources.InvalidUserName);
                }
                else if(!IsValidEmail(UpdatPersonDetailsItem.UserEmailAddress))
                {
                    ShowMessege(AppResources.Alert, AppResources.EmailNotValid);
                }
                else if (Constants.UpdateMobile==false)
                {
                    ShowMessege(AppResources.Alert, AppResources.PleaseValidYourPhonenumber);
                }
                else if (Constants.VerifySecondMobile == false)
                {
                    if (UpdatPersonDetailsItem.SecondMobile.Length != 11 || !UpdatPersonDetailsItem.SecondMobile.StartsWith("01"))
                    {
                        ShowMessege(AppResources.Alert, AppResources.secondPhoneNumberformat);
                    }
                    else
                    {
                        ShowMessege(AppResources.Alert, AppResources.PleaseValidYourSecondPhonenumber);

                    }
                }
                else
                { 
                    
                    switch (Constants.LoginType)
                    {
                        case 0:
                            var seeker = await WebService.UpdateSeekerDetail(UpdatPersonDetailsItem);

                            if (!seeker.success)
                                ShowMessege(AppResources.Alert, seeker?.error);
                            else if (seeker?.result?.success != true)
                            {
                                ShowMessege(AppResources.Alert, seeker?.result?.error);
                            }
                            else if (seeker?.result?.success == true)
                            {
                                ShowMessege(AppResources.Alert, AppResources.SucessfullyUpdate);
                                Application.Current.MainPage = new AppShell();
                            }
                            break;
                        case 1:
                            var owner = await WebService.UpdateOwnerDetail(UpdatPersonDetailsItem);

                            if (!owner.success)
                                ShowMessege(AppResources.Alert, owner?.error);
                            else if (owner?.result?.success != true)
                            {
                                ShowMessege(AppResources.Alert, owner?.result?.error);
                            }
                            else if (owner?.result?.success == true)
                            {
                                ShowMessege(AppResources.Alert, AppResources.SucessfullyUpdate);
                                await PopupNavigation.Instance.PopAsync();
                                Application.Current.MainPage = new AppShell();
                            }
                            break;
                        case 2:
                            var broker = await WebService.UpdateBrokerDetail(UpdatPersonDetailsItem);

                            if (!broker.success)
                                ShowMessege(AppResources.Alert, broker?.error);
                            else if (broker?.result?.success != true)
                            {
                                ShowMessege(AppResources.Alert, broker?.result?.error);
                            }
                            else if (broker?.result?.success == true)
                            {
                                ShowMessege(AppResources.Alert, AppResources.SucessfullyUpdate);
                                Application.Current.MainPage = new AppShell();
                            }
                            break;
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
        private async Task ExecutUpdateCompanyAccountCommand()
        {

            try
            {
                CompanyDetailsItem.PackageId = Constants.PackageId; 
                CompanyDetailsItem.Balance = Constants.Balance; 
                CompanyDetailsItem.Logo = CompanyDetailsItem.PictureLogo != null ? await uploadFile(CompanyDetailsItem.PictureLogo) : CompanyDetailsItem.Avatar.Replace("https://brokerapi.nahrdev.website/Resources/UploadFiles/", "");
                CompanyDetailsItem.BwLogo = CompanyDetailsItem.PictureBwLogo != null ? await uploadFile(CompanyDetailsItem.PictureBwLogo) : CompanyDetailsItem.BwLogo.Replace("https://brokerapi.nahrdev.website/Resources/UploadFiles/", "");
                CompanyDetailsItem.CommericalAvatar = CompanyDetailsItem.PictureCommericalAvatar != null ? await uploadFile(CompanyDetailsItem.PictureCommericalAvatar) : CompanyDetailsItem.CommericalAvatar.Replace("https://brokerapi.nahrdev.website/Resources/UploadFiles/", "");
                
                if (!IsValid())
                {
                    return;
                }
                else
                {
                            var company = await WebService.UpdateCompanyDetail(CompanyDetailsItem);
                            if (!company.success)
                                ShowMessege(AppResources.Alert, company?.error);
                            else if (company?.result?.success != true)
                            {
                                ShowMessege(AppResources.Alert, company?.result?.error);
                            }
                            else if (company?.result?.success == true)
                            {
                                
                        if (Constants.PackageId == null || Constants.PackageId == 0)
                        {
                            ShowMessege(AppResources.Alert, AppResources.SucessfullyUpdate);
                            Application.Current.MainPage = new AppShell();
                        }
                        else {
                            await Shell.Current.Navigation.PopPopupAsync();
                            await Shell.Current.Navigation.PushAsync(new WalletPage());
                            Constants.PackageId = null;
                            Constants.Balance = null;
                        }
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
        private async Task ExecutUpdateCompanyWalletCommand()
        {

            try
            {
                CompanyDetailsItem.PackageId = Constants.PackageId;
                CompanyDetailsItem.Balance = Constants.Balance;
                CompanyDetailsItem.Logo = CompanyDetailsItem.PictureLogo != null ? await uploadFile(CompanyDetailsItem.PictureLogo) : CompanyDetailsItem.Avatar.Replace("https://brokerapi.nahrdev.website/Resources/UploadFiles/", "");
                CompanyDetailsItem.BwLogo = CompanyDetailsItem.PictureBwLogo != null ? await uploadFile(CompanyDetailsItem.PictureBwLogo) : CompanyDetailsItem.BwLogo.Replace("https://brokerapi.nahrdev.website/Resources/UploadFiles/", "");
                CompanyDetailsItem.CommericalAvatar = CompanyDetailsItem.PictureCommericalAvatar != null ? await uploadFile(CompanyDetailsItem.PictureCommericalAvatar) : CompanyDetailsItem.CommericalAvatar.Replace("https://brokerapi.nahrdev.website/Resources/UploadFiles/", "");
                CompanyDetailsItem.IsPackageRenwed = true;
                 var company = await WebService.UpdateCompanyDetail(CompanyDetailsItem);
                    if (!company.success)
                        ShowMessege(AppResources.Alert, company?.error);
                    else if (company?.result?.success != true)
                    {
                        ShowMessege(AppResources.Alert, company?.result?.error);
                    }
                    else if (company?.result?.success == true)
                    {
                    if (Constants.BackToPaymentCompany == true)
                    {
                        await Shell.Current.Navigation.PopPopupAsync(); 
                        await Shell.Current.Navigation.PopAsync();
                      //  await Shell.Current.Navigation.PopAsync();
                        // await Shell.Current.Navigation.PushAsync(new WalletPage());
                    }
                    else
                    {
                        await Shell.Current.Navigation.PopPopupAsync();
                        await Shell.Current.Navigation.PushAsync(new WalletPage());
                        Constants.PackageId = null;
                        Constants.Balance = null;
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
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(CompanyDetailsItem.PhoneNumber))
            {
                ShowMessege(AppResources.Alert, AppResources.InvalidPhone);
                return false;
            }
             if (!string.IsNullOrEmpty(CompanyDetailsItem.PhoneNumber) && (CompanyDetailsItem.PhoneNumber.Length != 11 || !CompanyDetailsItem.PhoneNumber.StartsWith("01")))
            {
                ShowMessege(AppResources.Alert, AppResources.phoneNumberformat);
                return false;

            }
             if (string.IsNullOrEmpty(CompanyDetailsItem.Name))
            {
                ShowMessege(AppResources.Alert, AppResources.InvalidUserName);
                return false;
            }
             if (!IsValidEmail(CompanyDetailsItem.EmailAddress))
            {
                ShowMessege(AppResources.Alert, AppResources.EmailNotValid);
                return false;
            }
            if (string.IsNullOrEmpty(CompanyDetailsItem.About))
            {
                ShowMessege(AppResources.Alert, AppResources.PleaseEnterAboutCompany);
                return false;
            }
            if (string.IsNullOrEmpty(CompanyDetailsItem.Latitude) && string.IsNullOrEmpty(CompanyDetailsItem.Longitude))
            {
                ShowMessege(AppResources.Alert, AppResources.pleaseEnterCompanyLocation);
                return false;
            }
            if (string.IsNullOrEmpty(CompanyDetailsItem.Facebook))
            {
                ShowMessege(AppResources.Alert, AppResources.pleaseEnterCompanyFacebookLink);
                return false;
            }
            if (string.IsNullOrEmpty(CompanyDetailsItem.Instagram))
            {
                ShowMessege(AppResources.Alert, AppResources.pleaseEnterCompanyinstagramLink);
                return false;
            }
            if (string.IsNullOrEmpty(CompanyDetailsItem.Snapchat))
            {
                ShowMessege(AppResources.Alert, AppResources.pleaseEnterCompanySnapchatLink);
                return false;
            }
            if (string.IsNullOrEmpty(CompanyDetailsItem.Website))
            {
                ShowMessege(AppResources.Alert, AppResources.pleaseEnterCompanyWebsiteLink);
                return false;
            }
            if (string.IsNullOrEmpty(CompanyDetailsItem.Tiktok))
            {
                ShowMessege(AppResources.Alert, AppResources.pleaseEnterCompanyTiktokLink);
                return false;
            }

            return true;

        }
        private async Task<bool> CheckPhoneOrEmail(string name)
        {
            bool exist = false;
            var res = await WebService.CheckIsEmailOrPhoneExist(name);
            if (!res.Success)
                ShowMessege(AppResources.Alert, res?.Error);
            else
            {
                exist = res.Result.Exist;
            }
            return exist;
        }
        private async Task LoadPrepareChangePassword()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                if (string.IsNullOrEmpty(ChangePassword.CurrentPassword))
                {
                    ShowMessege(AppResources.Alert, AppResources.EnterCurrentPassword);
                    return;
                }
                if (string.IsNullOrEmpty(ChangePassword.NewPassword))
                {
                    ShowMessege(AppResources.Alert, AppResources.EnterNewPassword);
                    return;
                }

                if (ChangePassword.NewPassword != ChangePassword.ConfirmNewPassword)
                {
                    ShowMessege(AppResources.Alert, AppResources.PasswordNotMatch);
                    return;
                }
                var Statuschanged = await WebService.ChangePassword(ChangePassword);

                if (string.IsNullOrEmpty(Statuschanged.Result.Error))
                {
                    Device.BeginInvokeOnMainThread(async () => {
                        ShowMessege(AppResources.Alert, AppResources.PasswordSuccessFullyChanged);
                        Application.Current.MainPage = new AppShell();


                    });
                }
                else
                {
                        ShowMessege(AppResources.Alert, (Statuschanged.Result.Msg));
                }
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
        private async Task ExecuteDeleteAccountCommand()
        {

            try
            {

                var res = await WebService.DeleteAccount();
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    ShowMessege(AppResources.Alert, AppResources.RemovedAccount);
                   // Application.Current.MainPage = new LoginPage();
                    Shell.Current.FlyoutIsPresented = false;
                    Constants.TokenH = null;
                    Application.Current.Properties["TokenAccess"] = null;
                    Application.Current.Properties.Remove("TokenAccess");
                    await PopupNavigation.Instance.PopAsync();
                    await Application.Current.SavePropertiesAsync();
                    Device.BeginInvokeOnMainThread(async () => {
                        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    });
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
        private async void OpenVerifyMobileNumberPage()
        {
            UpdatPersonDetailsItem.SecondMobile = PersonDetailsItem.SecondMobile;
            if (string.IsNullOrEmpty(PersonDetailsItem.SecondMobile))
            {
                ShowMessege(AppResources.Alert, AppResources.InvalidPhone);
            }
            else if (!string.IsNullOrEmpty(PersonDetailsItem.SecondMobile) && (PersonDetailsItem.SecondMobile.Length != 11 || !PersonDetailsItem.SecondMobile.StartsWith("01")))
            {
                ShowMessege(AppResources.Alert, AppResources.phoneNumberformat);

            }
            else
            {
                var result = await WebService.CheckPhoneNumberOtp(PersonDetailsItem.SecondMobile);
                if (result.Result.IsSuccess == true)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new Views.VerifyMobileNumberPage("secondMobile"));

                    Constants.UserVerifyCode = result.Result.Otp.ToString();

                }
                else
                {
                    ShowMessege(AppResources.Alert, result.Result.Message);
                }

            }
        }
        private async void OpenComoanyVerifyMobileNumberPage()
        {
            UpdatCompanyDetailsItem.SecondMobile = CompanyDetailsItem.SecondMobile;
            if (string.IsNullOrEmpty(UpdatCompanyDetailsItem.SecondMobile))
            {
                ShowMessege(AppResources.Alert, AppResources.InvalidPhone);
            }
            else if (!string.IsNullOrEmpty(UpdatCompanyDetailsItem.SecondMobile) && (UpdatCompanyDetailsItem.SecondMobile.Length != 11 || !UpdatCompanyDetailsItem.SecondMobile.StartsWith("01")))
            {
                ShowMessege(AppResources.Alert, AppResources.phoneNumberformat);

            }
            else
            {
                var result = await WebService.CheckPhoneNumberOtp();
                if (result.Result.IsSuccess == true)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new Views.VerifyMobileNumberPage());
                    Constants.UserVerifyCode = result.Result.Otp.ToString();

                }
                else
                {
                    ShowMessege(AppResources.Alert, result.Result.Message);
                }

            }
        }
        private async void OpenPersonalDataPage()
        {
         
            var result = await WebService.CheckPhoneNumberOtp();
            if (result.Result.IsSuccess == true)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.VerifyMobileNumberPage());
                Constants.UserVerifyCode = result.Result.Otp.ToString();

            }
            else
            {
                ShowMessege(AppResources.Alert, result.Result.Message);
            }
            await Shell.Current.Navigation.PopAsync();
        }
        public string GetVerifyCode()
        {
            return "1234";
        }
        private async Task ExecuteGetAllPackagesCommand()
        {
            try
            {
                var res = await WebService.GetAllPackages();
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    foreach (var item in res.Result.Packages)
                    {


                        PackageItems.Add(item);
                    }

                    if (res.Result.Packages.Count == 0)
                        HeightRequest = 0;
                    else
                        HeightRequest = (res.Result.Packages.Count * 170) + 5;
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
        private async Task ExecuteGetCompanyPackageDetailsCommand()
        {
            try
            {
                var res = await WebService.GetCompanyPackageDetails(Convert.ToInt64(Constants.UserId));
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    PackageDetailsItem = res.Result.Details;
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
        private async Task ExecuteGetCompanyWalletDetailsCommand()
        {
            try
            {
                Device.BeginInvokeOnMainThread(async() =>
                {


                    var res = await WebService.GetCompanyWalletPackageDetails(Convert.ToInt64(Constants.UserId));
                    if (!res.Success)
                        ShowMessege(AppResources.Alert, res?.Error);
                    else if (res?.Result?.Success != true)
                    {
                        ShowMessege(AppResources.Alert, res?.Result?.Error);
                    }
                    else if (res?.Result?.Success == true)
                    {
                        foreach (var item in res.Result.PackagesHistory)
                        {
                            PackagesHistoryItems.Add(item);
                        }
                        WalletHeight = PackagesHistoryItems.Count * 150;
                        WalletPackageDetailsItem = res.Result.Details;

                    }
                });
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
