using NewBrokerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Broker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BrokerSignUpPage : ContentPage
	{
        RegisterViewModel viewModel;
        public BrokerSignUpPage()
		{
			InitializeComponent ();
            BindingContext= viewModel=new RegisterViewModel();
		}

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
			await Navigation.PopAsync ();
        }

       
    }
}