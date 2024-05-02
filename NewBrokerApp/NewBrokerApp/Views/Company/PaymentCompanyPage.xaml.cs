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
using Plugin.Media.Abstractions;
using System.Net.Http;
using System.IO;

namespace NewBrokerApp.Views.Company
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentCompanyPage : ContentPage
    {
        public IWebService webService => DependencyService.Get<IWebService>();
        PaymentViewModel viewModel;
        DurationModel data { get; set; }
        public int TotaPrice { get; set; }
        public bool GoToPaymentCompany { get; set; }
        AdvertisementModel Advertisementdata;
        public PaymentCompanyPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PaymentViewModel();
            data = new DurationModel();
            Advertisementdata = new AdvertisementModel();
            viewModel.LoadDurationProjectCommand.Execute(true);
            viewModel.LoadGetCompanyPackageDetailsCommand.Execute(true);
         

        }
        protected override void OnAppearing()
        {
            Advertisementdata = new AdvertisementModel();
            base.OnAppearing();
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            Advertisementdata = Constants.NavigationAdvertiserModel as AdvertisementModel;
            if (Advertisementdata.DurationId == 0 || Advertisementdata.DurationId == null)
            {

                await App.Current.MainPage.DisplayAlert("", AppResources.pleaseChooseDuration, AppResources.ok);
            }
            else
            {
                frmPaid.IsEnabled = false;
                if (Constants.PaymentStatus == 1)
                {
                    Constants.IsPaidWithWallet = true;
                    await PopupNavigation.Instance.PushAsync(new PaymentPopUP());
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        if(Constants.CompanyBalance>= Constants.TotalPrice)
                        {
                            var data = await webService.UpdateCompanyBalanceRival(Constants.TotalPrice);
                            if (data.Success != true)
                            {
                                await App.Current.MainPage.DisplayAlert("", data.Result.Error, AppResources.ok);
                            }
                            else
                            {
                                Constants.IsPaidWithWallet = true;
                                await PopupNavigation.Instance.PushAsync(new PaymentPopUP());
                                SaveAdvertiser();
                            }
                        }
                        else
                        {
                            var result = await webService.GetPaymentUrl(new PaymentInput { UserId = Convert.ToInt64(Constants.UserId), Amount = Constants.TotalPrice });
                            if (result.Result.IsSuccess == true)
                            {
                                await Shell.Current.Navigation.PushAsync(new PaymentMethodCompanyPage(result.Result.Url));
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("", result.Result.Error, AppResources.ok);

                            }
                        }
                        
                    });
                }
                //Device.BeginInvokeOnMainThread(async () =>
                //{
                //    await Shell.Current.Navigation.PushAsync(new PaymentMethodCompanyPage());
                //});
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
            // txtPrice.Text = $"{Convert.ToInt32(data.Amount)} EGP ({data.Period} month)";
            var vat = 0/*Convert.ToInt32((data.Amount) * .14m)*/;
            // txtVat.Text = $"+{vat}(vat 14 %)";
            var featurePresant = Convert.ToInt32(viewModel.FeatureModel.Name);
            var featurePrice = (data.Amount * featurePresant) / 100;
            Constants.FeaturePrice = featurePrice;
            if (FeatureSwitch.IsToggled == true)
            {

                //txtFeature.Text = $"{featurePrice} EGP (Features Ad)";
                TotaPrice = Convert.ToInt32(data.Amount + vat + featurePrice);
                //txtTotal.Text = Convert.ToInt32((data.Amount + vat + featurePrice)).ToString();
                txtTotal2.Text = $"{Convert.ToInt32((data.Amount + vat + featurePrice)).ToString()} EGP";
                Constants.TotalPrice = TotaPrice;
            }
            else
            {


                TotaPrice = Convert.ToInt32(data.Amount + vat);
                //txtTotal.Text = Convert.ToInt32((data.Amount + vat)).ToString();
                txtTotal2.Text = $"{Convert.ToInt32((data.Amount + vat)).ToString()} EGP";
                Constants.TotalPrice = TotaPrice;
                txApply.IsEnabled = true;
            }

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
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
                        await App.Current.MainPage.DisplayAlert("", AppResources.discountApply, AppResources.ok);
                        var discountValue = discount.Result.Discount.Percentage != null ? (Constants.TotalPrice * discount.Result.Discount.Percentage / 100) : discount.Result.Discount.FixedAmount;
                        //txtDiscount.Text = $"-{Convert.ToInt32(discountValue)} EGP (Discount Code)";
                        // txtTotal.Text = Convert.ToInt32((TotaPrice - Convert.ToDecimal(discountValue))).ToString();
                        txtTotal2.Text = $"{Convert.ToInt32(TotaPrice - Convert.ToDecimal(discountValue))} EGP";
                        Constants.TotalPrice = Convert.ToInt32(TotaPrice - Convert.ToDecimal(discountValue));

                    }
                    UserDialogs.Instance.HideLoading();
                });

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
                var data = (Switch)sender;
                if (data.IsToggled == false)
                {

                    (Constants.NavigationAdvertiserModel as AdvertisementModel).FeaturedAd = e.Value;
                    // txtFeature.Text = $"0 EGP (Features Ad)";
                    var total = Convert.ToInt32(TotaPrice - Convert.ToDecimal(Constants.FeaturePrice.ToString()));
                    //txtTotal.Text = total.ToString();
                    txtTotal2.Text = $"{total} EGP";
                    Constants.TotalPrice = total;
                    TotaPrice= total;
                }

                else
                {
                    (Constants.NavigationAdvertiserModel as AdvertisementModel).FeaturedAd = e.Value;
                    var featurePrice = Convert.ToInt32(Constants.FeaturePrice);
                    // txtFeature.Text = $"{featurePrice} EGP (Features Ad)";
                    var total = Convert.ToInt32(TotaPrice + Convert.ToDecimal(Constants.FeaturePrice.ToString()));
                    //txtTotal.Text = total.ToString();
                    txtTotal2.Text = $"{total} EGP";
                    Constants.TotalPrice = total;
                    TotaPrice = total;
                }
            }
            catch (Exception ex)
            {

            }


        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            //GoToPaymentCompany = true;           
            await Shell.Current.Navigation.PushAsync(new RechargeWalletPage());
                   
        }
        protected override bool OnBackButtonPressed()
        {
            (Constants.NavigationAdvertiserModel as AdvertisementModel).DurationId = 0;
            // true or false to disable or enable the action
            return base.OnBackButtonPressed();
        }
    }
}