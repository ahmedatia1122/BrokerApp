using NewBrokerApp.Helpers;
using NewBrokerApp.ViewModels;
using Rg.Plugins.Popup.Pages;
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
    public partial class ConfirmPaymentWalletPopUP : PopupPage
    {
        AccountViewModel viewModel;
        public ConfirmPaymentWalletPopUP()
        {
            InitializeComponent();
            BindingContext = viewModel = new AccountViewModel();
            Constants.BackToPaymentCompany = true;
            // viewModel.GetLatestAdvertiseIdCommand.Execute(null);
            viewModel.PersonDetailsCommand.Execute(true);

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

            await Shell.Current.Navigation.PushAsync(new AddsPage());
            //App.Current.MainPage=new AppShell();
        }
    }
}