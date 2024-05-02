using DevExpress.Utils.StructuredStorage.Internal;
using DevExpress.Utils.StructuredStorage.Internal.Writer;
using FFImageLoading.Svg.Forms;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.Services;
using NewBrokerApp.ViewModels;
using Polly.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using NewBrokerApp.Views.Common;
using Rg.Plugins.Popup.Services;
using System.Net.NetworkInformation;
using Plugin.Media.Abstractions;
using System.Net.Http;
using System.IO;

namespace NewBrokerApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentPage : ContentPage
	{
        public IWebService webService => DependencyService.Get<IWebService>();
        PaymentViewModel viewModel;
        DurationModel data { get; set; }
        public int  TotaPrice { get; set; }
        public int ApplyDiscount { get; set; }
        public PaymentPage ()
		{
			InitializeComponent ();
			BindingContext=viewModel=new PaymentViewModel ();
            ApplyDiscount = 0;
            data = new DurationModel();
            viewModel.LoadDurationCommand.Execute (true);
            (Constants.NavigationAdvertiserModel as AdvertisementModel).DurationId = 1;
            //FrmPublish.
          //  viewModel.Type = 9;
          //  viewModel.LoadFeatureCommand.Execute(true); ;

        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           
            var data = Constants.NavigationAdvertiserModel as AdvertisementModel;
            if(data.FeaturedAd == true && (data.DurationId == 0 || data.DurationId == null))
            {
                await App.Current.MainPage.DisplayAlert("", AppResources.pleaseChooseDuration, AppResources.ok);

            }
            else
            {
                if (data.FeaturedAd == true)
                {
                    frmPaid.IsEnabled = false;
                    if (Constants.PaymentStatus == 1)
                    {
                        await PopupNavigation.Instance.PushAsync(new PaymentPopUP());
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            var result = await webService.GetPaymentUrl(new PaymentInput { UserId = Convert.ToInt64(Constants.UserId), Amount = Constants.TotalPrice });
                            if (result.Result.IsSuccess == true)
                            {
                                await Shell.Current.Navigation.PushAsync(new PaymentMethodsPage(result.Result.Url));
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("", result.Result.Error, AppResources.ok);

                            }
                        });
                    }
                }
                else
                {
                    App.Current.MainPage = new AppShell();
                    // await Shell.Current.Navigation.PopAsync();
                    //  await Shell.Current.Navigation.PushAsync(new PaymentConfirmSucessPage());
                    // 
                    await PopupNavigation.Instance.PushAsync(new PaymentPopUP("normal"));
                    SaveAdvertiser();
                }
                
            }

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
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             data = e.CurrentSelection.FirstOrDefault() as DurationModel;
            (Constants.NavigationAdvertiserModel as AdvertisementModel).DurationId = data.Id;
            txtPrice.Text = string.Format(AppResources.monthstring, data.Amount, data.Period);
            var vat = Convert.ToInt32((data.Amount) * .14m);
            txtVat.Text = string.Format(AppResources.vatstring, vat); 
            var featurePresant = Convert.ToInt32(viewModel.FeatureModel.Name);
            var featurePrice = (data.Amount * featurePresant )/ 100;
            Constants.FeaturePrice = featurePrice;
            if (FeatureSwitch.IsToggled == true)
            {
            
                txtFeature.Text = string.Format(AppResources.featureadString, featurePrice);
                TotaPrice = Convert.ToInt32(data.Amount + vat + featurePrice);
                txtTotal.Text = Convert.ToInt32((data.Amount + vat + featurePrice)).ToString();
                txtTotal2.Text = string.Format(AppResources.EGPe, Convert.ToInt32((data.Amount + vat + featurePrice)).ToString()); 
                Constants.TotalPrice = TotaPrice;
            }
            else
            {
               
                
                TotaPrice =Convert.ToInt32( data.Amount + vat);
                txtTotal.Text = Convert.ToInt32((data.Amount + vat)).ToString();
                txtTotal2.Text = string.Format(AppResources.EGPe, Convert.ToInt32((data.Amount + vat)).ToString());
                Constants.TotalPrice = TotaPrice;
                txApply.IsEnabled = true;
            }
           
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {
                var data = Constants.NavigationAdvertiserModel as AdvertisementModel;
                if (data.FeaturedAd == true && (data.DurationId == 0 || data.DurationId == null))
                {
                    await App.Current.MainPage.DisplayAlert("", AppResources.pleaseChooseDuration, AppResources.ok);

                }
                else if (ApplyDiscount == 0)
                {


                    UserDialogs.Instance.ShowLoading();
                    Device.BeginInvokeOnMainThread(async () =>
                    {

                        var discount = await webService.GetDiscounts(txtDiscountCode.Text);

                        if (discount?.Result?.Success != true)
                        {
                            await App.Current.MainPage.DisplayAlert("", discount?.Result?.Error, AppResources.ok);
                        }
                        else if (discount?.Result?.Success == true)
                        {
                            var discountValue = discount.Result.Discount.Percentage != null ? (Constants.TotalPrice * discount.Result.Discount.Percentage / 100) : discount.Result.Discount.FixedAmount;
                            txtDiscount.Text = string.Format(AppResources.codestring, Convert.ToInt32(discountValue));
                            txtTotal.Text = Convert.ToInt32((Constants.TotalPrice - Convert.ToDecimal(discountValue))).ToString();
                            txtTotal2.Text = string.Format(AppResources.EGPe, Convert.ToInt32(Constants.TotalPrice - Convert.ToDecimal(discountValue))); ;
                            Constants.TotalPrice = Convert.ToInt32(Constants.TotalPrice - Convert.ToDecimal(discountValue));
                            ApplyDiscount++;
                        }
                        UserDialogs.Instance.HideLoading();
                    });
                }
              

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
            
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            try
            {
                var data =(Switch) sender;
                if (data.IsToggled == false)
                {
                    stk_duration.IsVisible = false;
                    stk_summery.IsVisible = false;
                    FrmPublish.IsVisible = true;
                    frmPaid.IsVisible = false;
                    txApply.IsEnabled = false;
                     (Constants.NavigationAdvertiserModel as AdvertisementModel).FeaturedAd = e.Value;
                    //txtFeature.Text = string.Format(AppResources.featureadString, 0); ;
                    //var total =Convert.ToInt32( TotaPrice - Convert.ToDecimal(Constants.FeaturePrice.ToString()));
                    //txtTotal.Text = total.ToString();
                    //txtTotal2.Text = string.Format(AppResources.EGPe, total); 
                    //Constants.TotalPrice = total;
                   
                    (Constants.NavigationAdvertiserModel as AdvertisementModel).DurationId = null;

                }

                else
                {
                    stk_duration.IsVisible = true;
                    stk_summery.IsVisible = true;
                    FrmPublish.IsVisible = false;
                    frmPaid.IsVisible = true;
                    txApply.IsEnabled = true;
                    (Constants.NavigationAdvertiserModel as AdvertisementModel).FeaturedAd = e.Value;
                   // var featurePrice = Convert.ToInt32( Constants.FeaturePrice);
                    //txtFeature.Text =string.Format(AppResources.featureadString, featurePrice);
                    //var total =Convert.ToInt32( TotaPrice + Convert.ToDecimal(Constants.FeaturePrice.ToString()));
                    //txtTotal.Text = total.ToString();
                    //txtTotal2.Text =string.Format(AppResources.EGPe, total);
                    //Constants.TotalPrice = total;
                 
                    
                   
                    (Constants.NavigationAdvertiserModel as AdvertisementModel).DurationId = 0;
                }
            }
            catch (Exception ex)
            {

            }
           
           
        }
        protected override bool OnBackButtonPressed()
        {
            (Constants.NavigationAdvertiserModel as AdvertisementModel).DurationId = 0;
            // true or false to disable or enable the action
            return base.OnBackButtonPressed();
        }
    }
}