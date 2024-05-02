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
	public partial class ChangePasswordPage : ContentPage
	{
        AccountViewModel viewModel;
        public ChangePasswordPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new AccountViewModel();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (txtCurrentPassword.IsPassword == true)

                txtCurrentPassword.IsPassword = false;
            else
                txtCurrentPassword.IsPassword = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (txtNewPassword.IsPassword == true)

                txtNewPassword.IsPassword = false;
            else
                txtNewPassword.IsPassword = true;
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (txtConfirmNewPassword.IsPassword == true)

                txtConfirmNewPassword.IsPassword = false;
            else
                txtConfirmNewPassword.IsPassword = true;
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {

        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new AppShell();
            // true or false to disable or enable the action
            return base.OnBackButtonPressed();
        }
    }
}