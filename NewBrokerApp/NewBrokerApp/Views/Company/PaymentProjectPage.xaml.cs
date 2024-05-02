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

namespace NewBrokerApp.Views.Company
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentProjectPage : ContentPage
    {
        public IWebService webService => DependencyService.Get<IWebService>();
        PaymentViewModel viewModel;
        DurationModel data { get; set; }
        public int TotaPrice { get; set; }
        public int Count { get; set; }
        public int FeatPrice { get; set; }
        public bool GoToPaymentProject { get; set; }
        public PaymentProjectPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PaymentViewModel();
            data = new DurationModel();
            viewModel.LoadDurationProjectCommand.Execute(true);
            viewModel.LoadGetCompanyPackageDetailsCommand.Execute(true);
     

        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
          
            var data = Constants.NavigationProject as ProjectModel;
            if (data.DurationId == 0 || data.DurationId == null)
            {

                await App.Current.MainPage.DisplayAlert("", AppResources.pleaseChooseDuration, AppResources.ok);
            }
            else
            {
                frmPaid.IsEnabled = false;
                if (Constants.PaymentStatus == 1)
                {
                    await PopupNavigation.Instance.PushAsync(new PaymentPopUPAdminConfirmProject());
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await webService.GetPaymentUrl(new PaymentInput { UserId = Convert.ToInt64(Constants.UserId), Amount = Constants.TotalPrice });
                        if (result.Result.IsSuccess == true)
                        {
                            await Shell.Current.Navigation.PushAsync(new PaymentMethodProjectPage(result.Result.Url));
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("", result.Result.Error, AppResources.ok);

                        }
                    });
                }
               

            }

        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            data = e.CurrentSelection.FirstOrDefault() as DurationModel;
            (Constants.NavigationProject as ProjectModel).DurationId = data.Id;
            Count = (Constants.NavigationProject as ProjectModel).Advertisements.Count();
            // txtPrice.Text = $"{Convert.ToInt32(data.Amount)} EGP ({data.Period} month)";
            var vat = 0/*Convert.ToInt32((data.Amount) * .14m)*/;
           // txtVat.Text = $"+{vat}(vat 14 %)";
            var featurePresant = Convert.ToInt32(viewModel.FeatureModel.Name);
            var featurePrice = (data.Amount * featurePresant) / 100;
            Constants.FeaturePrice = featurePrice;
            if (FeatureSwitch.IsToggled == true)
            {

                //txtFeature.Text = $"{featurePrice} EGP (Features Ad)";
                TotaPrice = Convert.ToInt32(Count * ((data.Amount + vat + featurePrice)));
                //txtTotal.Text = Convert.ToInt32((data.Amount + vat + featurePrice)).ToString();
                txtTotal2.Text = $"{Convert.ToInt32(Count * ((data.Amount + vat + featurePrice))).ToString()} EGP";
                Constants.TotalPrice = TotaPrice;
                
            }
            else
            {


                TotaPrice = Convert.ToInt32(Count * ((data.Amount + vat)));
                //txtTotal.Text = Convert.ToInt32((data.Amount + vat)).ToString();
                txtTotal2.Text = $"{Convert.ToInt32(Count * ((data.Amount + vat))).ToString()} EGP";
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
                        var discountValue = discount.Result.Discount.Percentage != null ? (data.Amount * discount.Result.Discount.Percentage / 100) : discount.Result.Discount.FixedAmount;
                        //txtDiscount.Text = $"-{Convert.ToInt32(discountValue)} EGP (Discount Code)";
                       // txtTotal.Text = Convert.ToInt32((TotaPrice - Convert.ToDecimal(discountValue))).ToString();
                        txtTotal2.Text = $"{Convert.ToInt32(TotaPrice -(Count * Convert.ToDecimal(discountValue)) )} EGP";
                        Constants.TotalPrice = Convert.ToInt32(TotaPrice -(Count * Convert.ToDecimal(discountValue)) );

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

                    (Constants.NavigationProject as ProjectModel).FeaturedAd = e.Value;
                    // txtFeature.Text = $"0 EGP (Features Ad)";
                    var total = Convert.ToInt32(TotaPrice - Convert.ToDecimal(FeatPrice.ToString()));
                    //txtTotal.Text = total.ToString();
                    txtTotal2.Text = $"{total} EGP";
                    Constants.TotalPrice = total;
                    TotaPrice = total;
                }

                else
                {
                    (Constants.NavigationProject as ProjectModel).FeaturedAd = e.Value;
                    var featurePrice = Count * Convert.ToInt32(Constants.FeaturePrice);
                   // txtFeature.Text = $"{featurePrice} EGP (Features Ad)";
                    var total = Convert.ToInt32(TotaPrice + Convert.ToDecimal(featurePrice.ToString()));
                    //txtTotal.Text = total.ToString();
                    txtTotal2.Text = $"{total} EGP";
                    Constants.TotalPrice = total;
                    FeatPrice = featurePrice;
                    TotaPrice = total;
                }
            }
            catch (Exception ex)
            {

            }


        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
                 //GoToPaymentProject = false;
                 await Shell.Current.Navigation.PushAsync(new RechargeWalletPage());
              
        }
    }
}