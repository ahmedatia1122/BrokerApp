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

namespace NewBrokerApp.Views.Company
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletPage : ContentPage
    {
        AccountViewModel viewModel;
        public long? PackageId { get; set; }
        public WalletPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AccountViewModel();
            //viewModel.PersonDetailsCommand.Execute(true);
            // viewModel.LoadGetCompanyPackageDetailsCommand.Execute(true);
            Device.BeginInvokeOnMainThread(() => {
                viewModel.LoadGetWalletCompanyPackageDetailsCommand.Execute(true);

            });
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
             await Shell.Current.Navigation.PushAsync(new RechargeWalletPage());
        }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as PackageModel;
            //PackageId = data.Id;
            //txtTotal2.Text = $"{Convert.ToInt32((data.Price)).ToString()} EGP";
            //Constants.TotalPrice = Convert.ToInt32(data.Price);
        }

    }
}