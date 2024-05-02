using NewBrokerApp.Helpers;
using NewBrokerApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class PaymentPopUPAdminConfirm : PopupPage
    {
        PropertyViewModel viewModel;
        public PaymentPopUPAdminConfirm()
        {
            InitializeComponent();
           
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Constants.PackageId == null || Constants.PackageId == 0)
            {
                await PopupNavigation.Instance.PopAsync();
                await PopupNavigation.Instance.PushAsync(new PaymentPopUP());
            }
            else
            {
                await PopupNavigation.Instance.PopAsync();
                await PopupNavigation.Instance.PushAsync(new PaymentWalletPopUP());
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (Constants.PackageId == null || Constants.PackageId == 0)
            {
                await PopupNavigation.Instance.PopAsync();
                await PopupNavigation.Instance.PushAsync(new PaymentPopUP());
            }
            else
            {
                await PopupNavigation.Instance.PopAsync();
                await PopupNavigation.Instance.PushAsync(new PaymentWalletPopUP());
            }
        }
    }
}