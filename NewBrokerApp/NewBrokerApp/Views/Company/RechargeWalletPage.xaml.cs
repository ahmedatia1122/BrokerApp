using Plugin.Media.Abstractions;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Resources;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Services;
using NewBrokerApp.Views.Common;
using Rg.Plugins.Popup.Services;

namespace NewBrokerApp.Views.Company
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RechargeWalletPage : ContentPage
    {
        AccountViewModel viewModel;
        public IWebService webService => DependencyService.Get<IWebService>();
        public long? PackageId { get; set; }
       //public bool GoToPayment { get; set; }
        public RechargeWalletPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AccountViewModel();
            viewModel.LoadAllPackagesCommand.Execute(true);
            //GoToPayment = GoToPaymentCompany;        
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopAsync();
        }
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (PackageId == null || PackageId == 0)
            {

                await App.Current.MainPage.DisplayAlert("", AppResources.pleaseChoosePackage, AppResources.ok);
            }
            else
            {
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
                            await Shell.Current.Navigation.PushAsync(new PaymentMethodCompanyPage(result.Result.Url,true));
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
           var data = e.CurrentSelection.FirstOrDefault() as PackageModel;
                PackageId = data.Id;
                Constants.PackageId = data.Id;
                Constants.Balance = Convert.ToInt32(data.Price);
                txtTotal2.Text = $"{Convert.ToInt32((data.Price)).ToString()} EGP";
                Constants.TotalPrice = Convert.ToInt32(data.Price);
        }

    }
}