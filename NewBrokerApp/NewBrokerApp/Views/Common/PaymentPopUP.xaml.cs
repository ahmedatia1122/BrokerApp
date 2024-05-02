using NewBrokerApp.Resources;
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
    public partial class PaymentPopUP : PopupPage
    {
        PropertyViewModel viewModel;
        public PaymentPopUP(string fromNormaladd = null)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(fromNormaladd))
            {
                txtTitle.Text = AppResources.Done;
            }
            BindingContext = viewModel = new PropertyViewModel();
            viewModel.GetLatestAdvertiseIdCommand.Execute(null);
        }
        
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

            await Shell.Current.Navigation.PushAsync(new AddsPage());
            //App.Current.MainPage=new AppShell();
        }
    }
}