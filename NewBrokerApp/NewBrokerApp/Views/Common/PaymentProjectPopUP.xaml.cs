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
    public partial class PaymentProjectPopUP : PopupPage
    {
        ProjectViewModel viewModel;
        public PaymentProjectPopUP()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProjectViewModel();
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