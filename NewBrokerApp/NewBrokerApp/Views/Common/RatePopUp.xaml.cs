using NewBrokerApp.ViewModels;
using Rg.Plugins.Popup.Extensions;
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
    public partial class RatePopUp : PopupPage
    {
        RateUsViewModel viewModel;
        public RatePopUp()
        {
            InitializeComponent();
            BindingContext = viewModel = new RateUsViewModel();

        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}