using NewBrokerApp.Helpers;
using NewBrokerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Company
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInPage : ContentPage
	{
        RegisterViewModel viewModel = new RegisterViewModel();
        public SignInPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel;
            viewModel.ShowMobile = Constants.ShowMobile;
            viewModel.ShowEmail = Constants.ShowEmail;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync ();

        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new CompanyDataPage());
        }
        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (txtPassword.IsPassword == true)

                txtPassword.IsPassword = false;
            else
                txtPassword.IsPassword = true;
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (txtConfirmPassword.IsPassword == true)

                txtConfirmPassword.IsPassword = false;
            else
                txtConfirmPassword.IsPassword = true;
        }
    }
}