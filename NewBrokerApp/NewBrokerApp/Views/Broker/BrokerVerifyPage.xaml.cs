using NewBrokerApp.Helpers;
using NewBrokerApp.Resources;
using NewBrokerApp.Services;
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
	public partial class BrokerVerifyPage : ContentPage
	{
        private TimeSpan _countSeconds = new TimeSpan(0,5,0);
        public IWebService webService => DependencyService.Get<IWebService>();

        public BrokerVerifyPage ()
		{
			InitializeComponent ();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                _countSeconds -= TimeSpan.FromSeconds(1); ;
                counter.Text = _countSeconds.ToString();
                return Convert.ToBoolean(_countSeconds.TotalSeconds);
            });
            step1.Focus();
            step2.IsEnabled = false;
            step3.IsEnabled = false;
            step4.IsEnabled = false;
        }
        private void step1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1)
            {
                if (string.IsNullOrEmpty(step2.Text))
                {
                    step2.IsEnabled = true;
                    step2.Focus();
                }

            }
        }


        private void step2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1)
            {
                if (string.IsNullOrEmpty(step3.Text))
                {
                    step3.Focus();
                    step3.IsEnabled = true;
                }

            }

            if (e.NewTextValue.Length == 0)
            {
                step2.OnBackspace += EntryBackspaceEventHandler2;

            }
        }



        private void step3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1)
            {
                step4.Focus();
                step4.IsEnabled = true;


            }

            if (e.NewTextValue.Length == 0)
            {
                step3.OnBackspace += EntryBackspaceEventHandler3;

            }
        }

        private void step4_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (e.NewTextValue.Length == 0)
            {
                step4.OnBackspace += EntryBackspaceEventHandler4;

            }
        }


        public void EntryBackspaceEventHandler2(object sender, EventArgs e)
        {
            step1.Focus();
            step1.Text = string.Empty;
        }

        public void EntryBackspaceEventHandler3(object sender, EventArgs e)
        {
            step2.Focus();
            step2.Text = string.Empty;
        }

        public void EntryBackspaceEventHandler4(object sender, EventArgs e)
        {
            step3.Focus();
            step3.Text = string.Empty;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }



private async void Button_Clicked(object sender, EventArgs e)
        {
            if(step1.Text!=null&& step2.Text != null&& step3.Text != null&& step4.Text != null)
            {
                var check = CheckUserVerifyCode(step1.Text + step2.Text + step3.Text + step4.Text);
                if (check)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new BrokerSignInPage());
                }
                else
                {
                   await App.Current.MainPage.DisplayAlert("", AppResources.pleaseentervalidcode, AppResources.ok);

                }
            }
            else
            {
                
                await App.Current.MainPage.DisplayAlert("", AppResources.pleaseentervalidcode, AppResources.ok);

            }

        }
        public bool CheckUserVerifyCode(string code)
        {
            return Constants.UserVerifyCode== code?true:false;
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
           // counter.Text = "0";
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                _countSeconds -= TimeSpan.FromSeconds(1); ;
                counter.Text = _countSeconds.ToString();
                return Convert.ToBoolean(_countSeconds.TotalSeconds);
            });
            var result = await webService.CheckPhoneNumberOtp();
            if (result.Result.IsSuccess == true)
            {
               // await Application.Current.MainPage.Navigation.PushAsync(new Views.Owner.OwnerVerifyPage());
                Constants.UserVerifyCode = result.Result.Otp.ToString();

            }
            else
            {
                App.Current.MainPage.DisplayAlert(AppResources.Alert, result.Result.Message,AppResources.ok);
            }
        }
    }
}