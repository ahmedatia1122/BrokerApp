using NewBrokerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Owner
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OwnerSignUpPage : ContentPage
	{
        RegisterViewModel viewModel;
        public OwnerSignUpPage()
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