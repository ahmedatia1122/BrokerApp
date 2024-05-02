using NewBrokerApp.Helpers;
using NewBrokerApp.Resources;
using NewBrokerApp.Services;
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
    public partial class PersonalDetailPage : ContentPage
    {
        AccountViewModel viewModel;
        int  isFirstOpenCount=0;
        public IWebService webService => DependencyService.Get<IWebService>();
        public PersonalDetailPage()
        {
            InitializeComponent();
           
            // this.BindingContext = new OnBoardingViewModel();
            BindingContext = viewModel = new AccountViewModel();
            viewModel.PersonDetailsCommand.Execute(true);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new Views.VerifyCodePage());
        }

        private async void BorderlessEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isFirstOpenCount >0)
            {
                var entry = (BorderlessEntry)sender;
                try
                {
                    if (entry.Text.Length >= 11)
                    {
                        var result = await webService.CheckPhoneNumberOtpForUpdatePhone(entry.Text);
                        if (result.Result.IsSuccess == true)
                        {
                            Constants.UpdateMobile = false;
                            await Application.Current.MainPage.Navigation.PushAsync(new Views.VerifyMobileNumberPage("1"));

                            Constants.UserVerifyCode = result.Result.Otp.ToString();

                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert(AppResources.Alert, result.Result.Message, AppResources.ok);
                        }
                        

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught: {0}", ex);
                }
            }
            isFirstOpenCount++;
        }

        private void BorderlessEntry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
           
           
            try
            {
               
                if (e.OldTextValue != e.NewTextValue)
                {
                    var entry = (BorderlessEntry)sender;
                    Constants.VerifySecondMobile = false;
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
    
}