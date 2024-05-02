using NewBrokerApp.ViewModels;
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
	public partial class CompanySignUp2Page : ContentPage
	{
		public CompanySignUp2Page ()
		{
			InitializeComponent ();
            this.BindingContext = new OnBoardingViewModel();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}