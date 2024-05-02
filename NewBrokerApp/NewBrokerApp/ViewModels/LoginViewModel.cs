using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NewBrokerApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }
        public Command ForgetPasswordCommand { get; }
        public Command OpenForgetPasswordCommand { get; }
        private LoginModel model;
        public LoginModel Model
        {
            get
            {
                return model;
            }
            set => SetProperty(ref model, value);
        }
        public LoginViewModel()
        {
            Model = new LoginModel();
            LoginCommand = new Command(OnLoginClicked);
            SignUpCommand = new Command(OnSignUpClicked);
            ForgetPasswordCommand = new Command(OnForgetPasswordClicked);
            OpenForgetPasswordCommand = new Command(OnForgetPasswordClicked);
        }
        private async void OpenForgetPassword()
        {
           await App.Current.MainPage.Navigation.PushAsync(new ForgetPasswordPage());

        }
        private async void OnForgetPasswordClicked(object obj) 
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                if (string.IsNullOrEmpty(model.UserNameOrEmailAddress))
                {
                    ShowMessege(AppResources.Alert, AppResources.PleaseEnterofMobilephoneorEmail);
                }
                else
                {
                    var res = await WebService.ForgetPassword(new ForgetPasswordInput { UserNameOrEmailAddress = model.UserNameOrEmailAddress });
                    if (!res.Success)
                        ShowMessege(AppResources.Alert, res?.Error?.Message);
                    else if (res?.Success != true)
                    {
                        ShowMessege(AppResources.Alert, res?.Error?.Message);
                    }
                    else if (res?.Success == true)
                    {
                        UserName = "";
                        Avatar = "";
                        //await App.Current.MainPage.Navigation.PopAsync();
                        App.Current.MainPage = new AppShell();
                        ShowMessege(AppResources.Alert, AppResources.pleaseCheckEmail);
                        IsBusy = false;
                    }
                }
            }
            catch (Exception e)
            {
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void OnLoginClicked(object obj)
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                if (!IsValid())
                {
                    return;
                }
                model.RememberClient = true;
                model.RegistrationDevice = Constants.DeviceToken != null ? Constants.DeviceToken: "";
                var res = await WebService.Login(Model);
                if (!res.success)
                    ShowMessege(AppResources.Alert, res?.error.details);
                else if (res?.success != true)
                {
                    ShowMessege(AppResources.Alert, res?.result?.error);
                }
                else if (res?.success == true)
                {
                   
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        Application.Current.Properties["LoginType"] = res.result.LoginType;
                        Application.Current.Properties["UserId"] = res.result.userId;
                        Constants.LoginType = Convert.ToInt32(Application.Current.Properties["LoginType"]);
                        Constants.UserId = Application.Current.Properties["UserId"].ToString();
                        //ShowMessege(AppResources.Alert, AppResources.loginSuccessfully);
                        Application.Current.Properties["TokenAccess"] = Constants.TokenH;
                        await Application.Current.SavePropertiesAsync();
                        // GetSettings();
                        Application.Current.MainPage = new AppShell();


                        IsBusy = false;
                    });

                }
            }
            catch (Exception e)
            {
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private bool IsValid()
        {

            if(string.IsNullOrEmpty(Model.UserNameOrEmailAddress)&& string.IsNullOrEmpty(Model.Password))
            {
                ShowMessege(AppResources.Alert, AppResources.invalidEmailAndPassword);
                return false;
            }
            if (string.IsNullOrEmpty(Model.UserNameOrEmailAddress))
            {
                ShowMessege(AppResources.Alert, AppResources.invalidEmail);
                return false;
            }

            if (string.IsNullOrEmpty(Model.Password))
            {
                ShowMessege(AppResources.Alert, AppResources.InvalidPassword);
                return false;
            }



            return true;
        }
        bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        //private async void OnLoginClicked(object obj)
        //{
        //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        //    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        //}
        private async void OnSignUpClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            // await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            await Application.Current.MainPage.Navigation.PushAsync(new Views.ChooseSignUpPage());

        }
    }
}
