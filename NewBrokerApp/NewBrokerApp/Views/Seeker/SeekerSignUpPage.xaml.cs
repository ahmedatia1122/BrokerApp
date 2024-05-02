using NewBrokerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Seeker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SeekerSignUpPage : ContentPage
	{
        RegisterViewModel viewModel;
        public SeekerSignUpPage()
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