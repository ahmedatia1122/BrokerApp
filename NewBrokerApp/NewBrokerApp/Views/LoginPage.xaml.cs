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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Views.PersonalDetailPage());
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (txtPassword.IsPassword == true)

                txtPassword.IsPassword = false;
            else
                txtPassword.IsPassword = true;

        }
    }
}