using NewBrokerApp.Helpers;
using NewBrokerApp.Resources;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Common;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Company
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentMethodProjectPage : ContentPage
    {
        ProjectViewModel viewModel;
        public PaymentMethodProjectPage(string url)
        {
            InitializeComponent();
            BindingContext = viewModel = new ProjectViewModel();
            wv.Source = url;
            //txtTotal.Text = $"Pay {Constants.TotalPrice} EGP";
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PaymentPopUPAdminConfirmProject());
        }
        private async void wv_Navigated(object sender, WebNavigatedEventArgs e)
        {
            var webView = sender as WebView;
           

            if (!string.IsNullOrEmpty(e.Url) && e.Url.Contains("ConfirmPaymentAccept") && e.Url.Contains("success=true"))
            {
                Constants.PaymentStatus = 1;
                App.Current.MainPage = new AppShell();
               // await Shell.Current.Navigation.PushAsync(new PaymentConfirmSucessPage());
                await PopupNavigation.Instance.PushAsync(new PaymentPopUPAdminConfirmProject());

            }
            else if (!string.IsNullOrEmpty(e.Url) && e.Url.Contains("ConfirmPaymentAccept") && e.Url.Contains("success=false"))
            {
                Constants.PaymentStatus = 2;
                await Shell.Current.Navigation.PopAsync();
                await App.Current.MainPage.DisplayAlert("", AppResources.PaymentFailed, AppResources.ok);
            }
        }

    }
}