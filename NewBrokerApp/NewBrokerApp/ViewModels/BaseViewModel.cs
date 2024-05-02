using NewBrokerApp.Helpers;
using NewBrokerApp.Models;

using NewBrokerApp.Services;
using NewBrokerApp.Views;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Services;
using NewBrokerApp.Views.Common;
using NewBrokerApp;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using NewBrokerApp.Resources;
using Plugin.Media.Abstractions;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Essentials;

namespace NewBrokerApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public IWebService WebService => DependencyService.Get<IWebService>();
        //   public IOAuth2Service _oAuth2Service => DependencyService.Get<IOAuth2Service>();
        int _RemainingItemsThreshold;
        public int RemainingItemsThreshold
        {
            get { return _RemainingItemsThreshold; }
            set { SetProperty(ref _RemainingItemsThreshold, value); }
        }
        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set => SetProperty(ref userName, value);
        }
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set => SetProperty(ref email, value);
        }
        private string avatar;
        public string Avatar
        {
            get
            {
                return avatar;
            }
            set => SetProperty(ref avatar, value);
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set => SetProperty(ref phoneNumber, value);
        }
        private string _versionNumber;
        public string VersionNumber
        {
            get
            {
                return _versionNumber;
            }
            set => SetProperty(ref _versionNumber, value);
        }
        private string secondMobile;
        public string SecondMobile
        {
            get
            {
                return secondMobile;
            }
            set => SetProperty(ref secondMobile, value);
        }
        private bool isWhatsApp;
        public bool IsWhatsApp
        {
            get
            {
                return isWhatsApp;
            }
            set => SetProperty(ref isWhatsApp, value);
        }
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        bool isOwner = false;
        public bool IsOwner
        {
            get { return isOwner; }
            set { SetProperty(ref isOwner, value); }
        }
        int pageIndex = 0;
        public int PageIndex
        {
            get { return pageIndex; }
            set { SetProperty(ref pageIndex, value); }
        }
        int _listLength = 10;
        public int ListLength
        {
            get { return _listLength; }
            set { SetProperty(ref _listLength, value); }
        }
        int _itemTreshold = 1;
        public int ItemTreshold
        {
            get { return _itemTreshold; }
            set { SetProperty(ref _itemTreshold, value); }
        }
        bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }
        bool hasSettings = false;
        public bool HasSettings
        {
            get { return hasSettings; }
            set { SetProperty(ref hasSettings, value); }
        }
        private bool isLogin;
        public bool IsLogin
        {
            get
            {
                return isLogin;
            }
            set => SetProperty(ref isLogin, value);
        }
        private bool isLoginNot;
        public bool IsLoginNot
        {
            get
            {
                return isLoginNot;
            }
            set => SetProperty(ref isLoginNot, value);
        }
        bool hasUnReadNotification = false;
        public bool HasUnReadNotification
        {
            get { return hasUnReadNotification; }
            set { SetProperty(ref hasUnReadNotification, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        private bool _isCompanyLogin=false;
        public bool IsCompanyLogin
        {
            get
            {
                return _isCompanyLogin;
            }
            set => SetProperty(ref _isCompanyLogin, value);
        }
        bool isEnabled = false;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }


        FlowDirection flowDirection = FlowDirection.LeftToRight;
        public FlowDirection FlowDirec
        {
            get { return flowDirection; }
            set { SetProperty(ref flowDirection, value); }
        }
        int rotation;
        public int Rotation
        {
            get { return rotation; }
            set { SetProperty(ref rotation, value); }
        }
        void SetDirection()
        {
            FlowDirec = Constants.SelectedIndex == 0 ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
        }
        public BaseViewModel()
        {
            try
            {
                VersionNumber = AppResources.version + " " + VersionTracking.CurrentVersion;
                FlowDirec = Constants.SelectedIndex == 0 ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
                if (Application.Current != null)
                    Application.Current.MainPage.FlowDirection = FlowDirec;
                if (Shell.Current != null)
                    Shell.Current.FlowDirection = FlowDirec;
                Rotation = Constants.SelectedIndex == 0 ? 0 : 180;
            }
            catch (Exception ex)
            {
            }
        }
        public async Task<string> uploadFile(MediaFile _mediaFile)
        {

            if (_mediaFile == null)
            {
                //await Application.Current.MainPage.DisplayAlert("Error", "There was an error when trying to get your image.", "OK");
                return null;
            }
            else
            {
                var uri = $"{Constants.ApiURL}/api/Upload/UploadMobile";
                var content = new MultipartFormDataContent();

                content.Add(new StreamContent(_mediaFile.GetStream()),
                    "\"file\"",
                    $"\"{_mediaFile.Path}\"");

                var httpClient = new HttpClient();
                var httpResponseMessage = await httpClient.PostAsync(uri, content);
                if (httpResponseMessage.IsSuccessStatusCode == true)
                {
                    return Path.GetFileName(_mediaFile.Path);
                }
                else
                {
                    return null;
                }

            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        string conn;
        public string Conn
        {
            get { return conn; }
            set { SetProperty(ref conn, value); }
        }
        public void CheckWifiOnStart()
        {
            //if (!CrossConnectivity.Current.IsConnected)
            //    Application.Current.MainPage.DisplayAlert("Network Error", "Please check Internet connection", "ok");
            //Conn = !CrossConnectivity.Current.IsConnected ? "Please check Internet connection" : "";
        }

        public void CheckWifiContinuously()
        {
            //CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            //{
            //    Conn = !args.IsConnected ? "Please check Internet connection" : "";
            //    if (!args.IsConnected)
            //        Application.Current.MainPage.DisplayAlert("Network Error", "Please check Internet connection", "ok");
            //};
        }
        public async void ShowMessege(string title, string message)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, AppResources.ok);
        }
        public Command BackUpCommand => new Command(async () => await Shell.Current.Navigation.PopAsync());
        public Command BackCommand => new Command(() => Application.Current.MainPage = new AppShell());
        public Command OpenMenu => new Command(() => Shell.Current.FlyoutIsPresented = true);
        public Command OpenLanguage => new Command(() => Shell.Current.FlyoutIsPresented = true);
        public Command BackPopupCommand => new Command(async () => await Shell.Current.Navigation.PopPopupAsync());
        private Command langPopup;
        public Command LangPopupCommand
        {
            get
            {
                return langPopup ?? (langPopup = new Command(async () =>
                {
                    if (IsBusy)
                        return;
                    await PopupNavigation.Instance.PushAsync(new LanguagePopUp());
                }));
            }
        }

        public Command OpenWhatsapp => new Command(() =>
        {
            try
            {
                //  Xamarin.Forms.OpenWhatsApp.Chat.Open("+965503688307");
            }
            catch (Exception x)
            {
            }
        });
        //public Func<string, ICollection<string>, ICollection<string>> SortingAlgorithm { get; } = (text, values) => (ICollection<string>)values.Where(x => x.Contains(text)).OrderBy(x => x).ToList();

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public class BindableViewModel : INotifyPropertyChanged
    {

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
