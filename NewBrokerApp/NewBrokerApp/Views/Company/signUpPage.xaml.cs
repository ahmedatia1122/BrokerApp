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
	public partial class signUpPage : ContentPage
	{
        RegisterViewModel viewModel;
        public signUpPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new RegisterViewModel();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
			await Navigation.PopAsync ();
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
			await App.Current.MainPage.Navigation.PushAsync(new VerifyPage());
        }
    }
}