using NewBrokerApp.Helpers;
using NewBrokerApp.Views.PropertiesAds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Footer : ContentView
	{
        public static string selectedPage;
        
        public object index;
        public Page rootPage;
        public static INavigation navigation;
        public Footer (string selectedPage2, Page root)
		{
			InitializeComponent ();
            selectedPage = selectedPage2;
            rootPage = root;
            if (selectedPage == "home")
            {
                txtHome.TextColor = Color.FromHex("#475569");
                imgHome.Source = "boldHome.svg";
                pankeHome.BackgroundColor = Color.FromHex("#E2E8F0");
            }
            else if (selectedPage == "ads")
            {
                txtads.TextColor = Color.FromHex("#475569");
                imgads.Source = "lightAds.svg";
                pankeAds.BackgroundColor = Color.FromHex("#E2E8F0");

            }
            else if (selectedPage == "favourite")
            {
                txtfav.TextColor = Color.FromHex("#475569");
                imgfav.Source = "boldfavorite.svg";
                pankeFavourite.BackgroundColor = Color.FromHex("#E2E8F0");
            }
            else if (selectedPage == "chats")
            {
                txtChat.TextColor = Color.FromHex("#475569");
                imgchat.Source = "boldNotification.svg";
                pankeNotification.BackgroundColor = Color.FromHex("#E2E8F0");
            }
            else if (selectedPage == "notification")
            {
                txtChat.TextColor = Color.FromHex("#475569");
                imgchat.Source = "boldNotification.svg";
                pankeNotification.BackgroundColor = Color.FromHex("#E2E8F0");
            }
            else if (selectedPage == "addProperty")
            {
              //  txtadd.TextColor = Color.FromHex("#034C82");
                imgadd.Source = "boldAddFooter.svg";
            }
        }

        private async  void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                if (selectedPage != "ads")
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.Navigation.PushAsync(new AddsPage());
                    }); 
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
           
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                if (selectedPage != "favourite")
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.Navigation.PushAsync(new FavouritePage());
                    });
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
          
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                if (selectedPage != "chats")
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.Navigation.PushAsync(new NotificationPage());
                    });
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
             if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                if (selectedPage != "addProperty")
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        Constants.NavigationProject = null;
                        await Shell.Current.Navigation.PushAsync(new PropertyTypesPage());
                    });
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
          
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            if (selectedPage != "home")
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Application.Current.MainPage = new AppShell();
                });
        }
        // private int _countSeconds = 5;

        //public MainPage()
        //{
        //    InitializeComponent();

        //    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        //    {
        //        _countSeconds--;
        //        CountLabel.Text = _countSeconds.ToString();
        //        return Convert.ToBoolean(_countSeconds);
        //    });
        //}
    }
}