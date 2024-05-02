using NewBrokerApp.Helpers;
using NewBrokerApp.Resources;
using NewBrokerApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignOutPopUp : PopupPage
    {
        BaseViewModel viewModel=new BaseViewModel();
        public SignOutPopUp()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {

                Shell.Current.FlyoutIsPresented = false;
                Constants.TokenH = null;
                Application.Current.Properties["TokenAccess"] = null;
                Application.Current.Properties.Remove("TokenAccess");
                viewModel.UserName = "";
                viewModel.Avatar = "";
                 await PopupNavigation.Instance.PopAsync();
                //IsLogin = false;
                await Application.Current.SavePropertiesAsync();

                Device.BeginInvokeOnMainThread(async () => {
                    await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                   // await  Application.Current.MainPage.DisplayAlert(AppResources.Alert, AppResources.LogOutSuccessfully,AppResources.ok);
                });

            }
            catch (System.Exception ex)
            {
            }
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}