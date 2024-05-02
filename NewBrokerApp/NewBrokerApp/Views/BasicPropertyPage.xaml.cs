using NewBrokerApp.Helpers;
using NewBrokerApp.Views.Popup;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicPropertyPage : ContentPage
    {
        public BasicPropertyPage()
        {
            InitializeComponent();
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           // await PopupNavigation.Instance.PushAsync(new PropertyPage());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            //  await Shell.Current.Navigation.PushAsync(new PropertyAddressPage());
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = true;
            txtTitle.Text = "Property Address";
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

           // await PopupNavigation.Instance.PushAsync(new CityPage());
          txtCity.Text = Constants.NavigationParamter!=null? Constants.NavigationParamter.ToString():"";
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            txtTitle.Text = "Property Details";
            stkDetails.IsVisible = true;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            txtTitle.Text = "Property Photos";
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            txtTitle.Text = " Property Pricing";
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = true;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
            
        }


        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            txtTitle.Text = "Advertiser Data";
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;
            stkAdvertise.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new HomePage());
        }

        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new AddsPage());
        }

        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new PaymentPage());
        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            stkBasic.IsVisible = true;
            StkAddress.IsVisible = false;
            txtTitle.Text = "Basic Details";
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = true;
            txtTitle.Text = "Property Address";
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_12(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            txtTitle.Text = "Property Details";
            stkDetails.IsVisible = true;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_13(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            txtTitle.Text = "Property Photos";
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_14(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            txtTitle.Text = "Advertiser Data";
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;
            stkAdvertise.IsVisible = true;

        }

        private void TapGestureRecognizer_Tapped_15(object sender, EventArgs e)
        {
         
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            txtTitle.Text = "Contact Information";
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = true;
        }
        //private async Task<int> waitForCityToSubmit()
        //{
        //    var tcs = new TaskCompletionSource<int>();
        //    await Navigation.PushPopupAsync(new CityPage(tcs));
        //    return await tcs.Task;
        //}
    }
}