using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.Services;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Common;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentMethodsPage : ContentPage
	{
        PropertyViewModel viewModel;
        public IWebService webService => DependencyService.Get<IWebService>();
        public PaymentMethodsPage (string url)
		{
			InitializeComponent ();
            BindingContext=viewModel=new PropertyViewModel ();
            wv.Source = url;
            // txtTotal.Text = $"Pay {Constants.TotalPrice} EGP";
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PaymentPopUP());
        }
        private async void wv_Navigated(object sender, WebNavigatedEventArgs e)
        {
            var webView = sender as WebView;
            if (!string.IsNullOrEmpty(e.Url) && e.Url.Contains("ConfirmPaymentAccept") && e.Url.Contains("success=true"))
            {
                Constants.PaymentStatus = 1;
                App.Current.MainPage = new AppShell();
               // await Shell.Current.Navigation.PopAsync();
              //  await Shell.Current.Navigation.PushAsync(new PaymentConfirmSucessPage());
              // 
                await PopupNavigation.Instance.PushAsync(new PaymentPopUP());
                SaveAdvertiser();


            }
            else if(!string.IsNullOrEmpty(e.Url) && e.Url.Contains("ConfirmPaymentAccept") && e.Url.Contains("success=false"))
            {
                Constants.PaymentStatus = 2;
                await Shell.Current.Navigation.PopAsync();
                await App.Current.MainPage.DisplayAlert("", AppResources.PaymentFailed, AppResources.ok);
            }
            void SaveAdvertiser()
            {
                Task.Run(async () =>
                {
                    AdvertisementModel model = new AdvertisementModel();
                    model = Constants.NavigationAdvertiserModel as AdvertisementModel;
                    model.IsPublish = true;
                    foreach (var item in model.MediaFiles)
                    {
                        model.PhotosList.Add(await uploadFile(item));
                    }
                    var res = await webService.ManageAdvertisement(model);

                });
      
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
    }
}