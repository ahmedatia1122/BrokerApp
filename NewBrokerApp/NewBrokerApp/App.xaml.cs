using Acr.UserDialogs;
using DLToolkit.Forms.Controls;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.Services;
using NewBrokerApp.Views;
using Plugin.Connectivity;
using Plugin.FirebasePushNotification;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.PlatformConfiguration;
namespace NewBrokerApp
{
    public partial class App : Application
    {
        NetworkService networkService;
       // WifiService wifiService;
        public App()
        {
            InitializeComponent();
           // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk2MDA5N0AzMjMzMmUzMDJlMzBWd285Skhuc0NaQWJUbVcvdjg1Z2J1ZWZZeEJEV0NMcHRDUHVuNVNUZSs4PQ==");
            DevExpress.XamarinForms.Editors.Initializer.Init();
            DevExpress.XamarinForms.Charts.Initializer.Init();
            DevExpress.XamarinForms.Popup.Initializer.Init();
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<WebService>();
            FlowListView.Init();
            Application.Current.UserAppTheme = OSAppTheme.Light;
            //MainPage = new NavigationPage(new IntroductionPage());
            var tcs = new TaskCompletionSource<AdvertisementModel>();
            //   MainPage = new NavigationPage(new ComboPage());
            var seconds = TimeSpan.FromSeconds(1);
            var current = Connectivity.NetworkAccess;
           
            if (Application.Current.Properties.ContainsKey("Lang") && Application.Current.Properties["Lang"] != null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Constants.SelectedIndex = Convert.ToInt32(Application.Current.Properties["Lang"]);
                    var lang = Constants.SelectedIndex == 1 ? "ar" : "en";
                    CultureInfo language = new CultureInfo(lang);
                    Thread.CurrentThread.CurrentUICulture = language;
                    AppResources.Culture = language;
                    var langService = DependencyService.Get<ILanguageManager>();
                    await langService.ChangeLanguage((AppLanguage)Constants.SelectedIndex);
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Constants.SelectedIndex = 0;
                    var lang = Constants.SelectedIndex == 1 ? "ar" : "en";
                    CultureInfo language = new CultureInfo(lang);
                    Thread.CurrentThread.CurrentUICulture = language;
                    AppResources.Culture = language;
                    var langService = DependencyService.Get<ILanguageManager>();
                    await langService.ChangeLanguage((AppLanguage)Constants.SelectedIndex);
                });}
            if (current == NetworkAccess.Internet)
            {
                   MainPage = new LoadingPage();
                //MainPage = new NavigationPage(new ContactUsPage());
            }
            else
            {
                Constants.NoInternet = true;
                MainPage = new NoInternetPage();
            }
            CrossFirebasePushNotification.Current.Subscribe("all");
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
            CrossFirebasePushNotification.Current.OnNotificationOpened += Current_OnNotificationOpened;

            //Device.StartTimer(seconds, (Func<bool>)(() =>
            //{
            //    CheckConnection();
            //    return true;
            //}));
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            // Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            //networkService = new NetworkService();
           

            //networkService.InternetConnectivityChanged += OnInternetConnectivityChanged;
          

            //// Start monitoring Wi-Fi and internet connectivity
          
        }
        async void OnInternetConnectivityChanged(object sender, bool isConnected)
        {
            // Handle internet connectivity changes
            if (isConnected)
            {
                // Device is connected to the internet
             Application.Current.MainPage.DisplayAlert("Internet", "Device is connected to the internet", "OK");
            }
            else
            {
                // Device is not connected to the internet
                Application.Current.MainPage.DisplayAlert("Internet", "Device is not connected to the internet", "OK");
            }
        }
      async  void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.ConstrainedInternet)
                await App.Current.MainPage.DisplayAlert("", "Internet access is available but is limited.", "Ok");

            else if (e.NetworkAccess != NetworkAccess.Internet)
                await App.Current.MainPage.DisplayAlert("", "Internet access has been lost.", "OK");

            // Log each active connection
            //Console.Write("Connections active: ");

            foreach (var item in e.ConnectionProfiles)
            {
                switch (item)
                {
                    //case ConnectionProfile.Bluetooth:
                    //    Console.Write("Bluetooth");
                    //    break;
                    //case ConnectionProfile.Cellular:
                    //    Console.Write("Cell");
                    //    break;
                    case ConnectionProfile.Ethernet:
                        Console.Write("Ethernet");
                        break;
                    case ConnectionProfile.WiFi:
                        Console.Write("WiFi");
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine();
        }
        //private void CheckConnection()
        //{
        //    var current = Connectivity.NetworkAccess;

        //    if (current != NetworkAccess.Internet && !Constants.NoInternet)
        //    {
        //        App.Current.MainPage.Navigation.PushAsync(new NoInternetPage());
        //        // Shell.Current.GoToAsync($"{nameof(NoInternetPage)}");
        //    }
        //}
        private async void CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected && !Constants.NoInternet)
               await App.Current.MainPage.Navigation.PushAsync(new NoInternetPage());
            else
                return;
        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }

        }
        private async void Current_OnNotificationOpened(object source, FirebasePushNotificationResponseEventArgs message)
        {
            try
            {
                if (!string.IsNullOrEmpty(message.Identifier))
                    await UserDialogs.Instance.AlertAsync(message.Identifier, AppResources.Alert, AppResources.ok);
                Constants.SeekerId = message.Data.ContainsKey("seekerId") ? Convert.ToInt32(message.Data["seekerId"].ToString()) : 0;
                Constants.OwnerId = message.Data.ContainsKey("ownerId") ? Convert.ToInt32(message.Data["ownerId"].ToString()) : 0;
                Constants.BrokerId = message.Data.ContainsKey("brokerId") ? Convert.ToInt32(message.Data["brokerId"].ToString()) : 0;
                Constants.CompanyId = message.Data.ContainsKey("companyId") ? Convert.ToInt32(message.Data["companyId"].ToString()) : 0;
                Device.BeginInvokeOnMainThread(async () =>
                    {
                        //  Application.Current.MainPage = new AppShell();
                        await Shell.Current.Navigation.PushModalAsync(new Views.AddsPage());
                        // await Shell.Current.Navigation.PushAsync(new Views.AddsPage());
                        // await Shell.Current.Navigation.PushAsync(new Views.Doctors.CustomersDetailsPage(Convert.ToInt32(Constants.NavigationParamter.ToString())));

                    });


            }
            catch (Exception ex)
            {

            }

        }
        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            if (uri.Host == "broker.nahrdev.website")
            {
                // Handle the link based on its path and query parameters
                if (uri.AbsolutePath == "/page1")
                {
                    string data = uri.Query.Replace("?data=", "");
                    Application.Current.MainPage.DisplayAlert("", data,"OK");

                    // Navigate to Page1 with the specified data
                }
            }
        }
        //protected override void OnAppLinkRequestReceived(Uri uri)
        //{
        //    if (uri != null)
        //    {
        //        //string text = uri.AbsolutePath.Substring(1); // skip the leading '/'
        //        //HandleDeepLinkText(text);
        //        string pageName = uri.AbsolutePath.Substring(0);
        //        string pageName1 = uri.Scheme.Substring(0);
        //        string pageName2 = uri.Segments[0];


        //        // skip the leading '/'
        //        NavigateToPage(pageName, pageName1, pageName2);
        //    }
        //}
        private void NavigateToPage(string pageName, string pageName1, string pageName2)
        {
            Application.Current.MainPage.DisplayAlert(pageName, pageName1, pageName);
            //switch (pageName)
            //{
            //    case "Page1":
            //        Application.Current.MainPage.Navigation.PushAsync(new ComboPage());
            //        break;
            //    case "Page2":
            //        Application.Current.MainPage.Navigation.PushAsync(new ComboPage());
            //        break;
            //    // add more cases for other pages
            //    default:
            //        break;
            //}
        }


        private void HandleDeepLinkText(string text)
        {
            // Handle the deep link text here
        }



        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
            //var current = Connectivity.NetworkAccess;
            //if (current == NetworkAccess.Internet)
            //{
            //    MainPage = new LoadingPage();
            //}
            //else
            //{
            //    Constants.NoInternet = true;
            //    MainPage = new NoInternetPage();
            //}
}
    }
}
