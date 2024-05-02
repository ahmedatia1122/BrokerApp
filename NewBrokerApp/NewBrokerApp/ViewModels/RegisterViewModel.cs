using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.Views;
using NewBrokerApp.Views.Broker;
using NewBrokerApp.Views.Company;
using NewBrokerApp.Views.Owner;
using NewBrokerApp.Views.Seeker;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace NewBrokerApp.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        private string mail;
        public string UserMail
        {
            get { return mail; }
            set => SetProperty(ref mail, value);
        }
        private string mobileNumber;
        public string UserMobileNumber
        {
            get{ return mobileNumber; }
            set => SetProperty(ref mobileNumber, value);
        }
        public Command OpenSignUpPageCommand { get; }
        public Command OpenBrokerVerifyPageCommand { get; }
        public Command OpenSeekerVerifyPageCommand { get; }
        public Command OpenOwnerVerifyPageCommand { get; }
        public Command OpenCompanyVerifyPageCommand { get; }
        private RegisterModel model;
        public RegisterModel Model
        {
            get{   return model; }
            set => SetProperty(ref model, value);
        }
        public Command RegisterBrokerCommand { get; }
        public Command RegisterSeekerCommand { get; }
        public Command RegisterOwnerCommand { get; }
        public Command RegisterCompanyCommand { get; }
        private LoginModel Loginmodel;
        public LoginModel LoginModel
        {
            get
            {
                return Loginmodel;
            }
            set => SetProperty(ref Loginmodel, value);
        }
        bool _showMobile;
        public bool ShowMobile
        {
            get { return _showMobile; }
            set { SetProperty(ref _showMobile, value); }
        }
        bool _showEmail;
        public bool ShowEmail
        {
            get { return _showEmail; }
            set { SetProperty(ref _showEmail, value); }
        }
        public static bool IsValidEmails(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        public RegisterViewModel()
        {
            Loginmodel = new LoginModel();
            Model = new RegisterModel();
            OpenSignUpPageCommand = new Command(OpenSignUpPage);

            OpenBrokerVerifyPageCommand = new Command(OpenBrokerVerifyPage);
            OpenSeekerVerifyPageCommand = new Command(OpenSeekerVerifyPage);
            OpenOwnerVerifyPageCommand = new Command(OpenOwnerVerifyPage);
            OpenCompanyVerifyPageCommand = new Command(OpenCompanyVerifyPage);

            RegisterBrokerCommand = new Command(SaveBrokerCommandClicked);
            RegisterSeekerCommand = new Command(SaveSeekerCommandClicked);
            RegisterOwnerCommand = new Command(SaveOwnerCommandClicked);
            RegisterCompanyCommand = new Command(SaveCompanyCommandClicked);

        }
        private async void OpenSignUpPage()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Views.SignUpPage());
        }
        private async void OpenBrokerVerifyPage()
        {
            try
            {
                Constants.UserMobileNumber = UserMobileNumber;
                Constants.UserEmail = UserMail;
                if (!string.IsNullOrEmpty(Constants.UserMobileNumber) && !string.IsNullOrEmpty(Constants.UserEmail))
                {
                    ShowMessege(AppResources.Alert, AppResources.PleaseEnterofMobilephoneorEmail);
                }
                else
                {
                    if (!string.IsNullOrEmpty(Constants.UserMobileNumber) || !string.IsNullOrEmpty(Constants.UserEmail))
                    {
                        if (!string.IsNullOrEmpty(Constants.UserMobileNumber))
                        {

                            if (!string.IsNullOrEmpty(Constants.UserMobileNumber) && (Constants.UserMobileNumber.Length != 11 || !Constants.UserMobileNumber.StartsWith("01")))
                            {
                                ShowMessege(AppResources.Alert, AppResources.phoneNumberformat);

                            }
                            else
                            {
                                if (await CheckPhoneOrEmail(Constants.UserMobileNumber ?? Constants.UserEmail) == false)
                                {
                                    Constants.ShowMobile = false;
                                    Constants.ShowEmail = true;

                                    var result = await WebService.CheckPhoneNumberOtp();
                                    if (result.Result.IsSuccess == true)
                                    {
                                        await Application.Current.MainPage.Navigation.PushAsync(new Views.Broker.BrokerVerifyPage());
                                        Constants.UserVerifyCode = result.Result.Otp.ToString();

                                    }
                                    else
                                    {
                                        ShowMessege(AppResources.Alert, result.Result.Message);
                                    }
                                }
                                else
                                {
                                    ShowMessege(AppResources.Alert, Constants.UserMobileNumber != null ? AppResources.phoneNumberalreadyExist : AppResources.emailalreadyExist);
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(Constants.UserEmail))
                        {
                            if (await CheckPhoneOrEmail(Constants.UserMobileNumber ?? Constants.UserEmail) == false)
                            {
                                if (!IsValidEmails(Constants.UserEmail))
                                {
                                    ShowMessege(AppResources.Alert, AppResources.EmailNotValid);
                                }
                                else
                                {
                                    Constants.ShowEmail = false;
                                    Constants.ShowMobile = true;
                                    var result = await WebService.CheckPhoneNumberOtp();
                                    if (result.Result.IsSuccess == true)
                                    {
                                        await Application.Current.MainPage.Navigation.PushAsync(new Views.Broker.BrokerVerifyPage());
                                        Constants.UserVerifyCode = result.Result.Otp.ToString();

                                    }
                                    else
                                    {
                                        ShowMessege(AppResources.Alert, result.Result.Message);
                                    }
                                }
                            }
                            else
                            {
                                ShowMessege(AppResources.Alert, Constants.UserMobileNumber != null ? AppResources.phoneNumberalreadyExist : AppResources.emailalreadyExist);
                            }
                        }
                    }
                    else
                    {
                        ShowMessege(AppResources.Alert, AppResources.pleaseEnterValueofphoneorpassword);
                    }
                }

            }
            catch (Exception ex)
            {

            }


        }
        private async Task<bool> CheckPhoneOrEmail(string name)
        {
            bool exist = false;
            var res = await WebService.CheckIsEmailOrPhoneExist(name);
            if (!res.Success)
                ShowMessege(AppResources.Alert, res?.Error);
            else
            {
                exist= res.Result.Exist;
            }
            return exist;
        }

        private async void OpenSeekerVerifyPage()
        {
            Constants.UserMobileNumber = UserMobileNumber;
            Constants.UserEmail = UserMail;
            if (!string.IsNullOrEmpty(Constants.UserMobileNumber) && !string.IsNullOrEmpty(Constants.UserEmail))
            {
                ShowMessege(AppResources.Alert, AppResources.PleaseEnterofMobilephoneorEmail);
            }
            else
            {
                if (!string.IsNullOrEmpty(Constants.UserMobileNumber) || !string.IsNullOrEmpty(Constants.UserEmail))
                {
                    if (!string.IsNullOrEmpty(Constants.UserMobileNumber))
                    {
                        
                        if (!string.IsNullOrEmpty(Constants.UserMobileNumber) && (Constants.UserMobileNumber.Length != 11 || !Constants.UserMobileNumber.StartsWith("01")))
                        {
                            ShowMessege(AppResources.Alert, AppResources.phoneNumberformat);

                        }
                        else
                        {
                            if (await CheckPhoneOrEmail(Constants.UserMobileNumber ?? Constants.UserEmail) == false)
                            {
                                Constants.ShowMobile = false;
                                Constants.ShowEmail = true;
                                var result = await WebService.CheckPhoneNumberOtp();
                                if (result.Result.IsSuccess == true)
                                {
                                    await Application.Current.MainPage.Navigation.PushAsync(new Views.Seeker.SeekerVerifyPage());
                                    Constants.UserVerifyCode = result.Result.Otp.ToString();

                                }
                                else
                                {
                                    ShowMessege(AppResources.Alert, result.Result.Message);
                                }
                                
       
                            }
                            else
                            {
                                ShowMessege(AppResources.Alert, Constants.UserMobileNumber != null ? AppResources.phoneNumberalreadyExist : AppResources.emailalreadyExist);
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(Constants.UserEmail))
                    {
                        if (await CheckPhoneOrEmail(Constants.UserMobileNumber ?? Constants.UserEmail) == false)
                        {
                            if (!IsValidEmails(Constants.UserEmail))
                            {
                                ShowMessege(AppResources.Alert, AppResources.EmailNotValid);
                            }
                            else
                            {
                                Constants.ShowEmail = false;
                                Constants.ShowMobile = true;
                                var result = await WebService.CheckPhoneNumberOtp();
                                if (result.Result.IsSuccess == true)
                                {
                                    await Application.Current.MainPage.Navigation.PushAsync(new Views.Broker.BrokerVerifyPage());
                                    Constants.UserVerifyCode = result.Result.Otp.ToString();

                                }
                                else
                                {
                                    ShowMessege(AppResources.Alert, result.Result.Message);
                                }
                            }
                        }
                        else
                        {
                            ShowMessege(AppResources.Alert, Constants.UserMobileNumber != null ? AppResources.phoneNumberalreadyExist : AppResources.emailalreadyExist);
                        }
                    }
                }
                else
                {
                    ShowMessege(AppResources.Alert, AppResources.pleaseEnterValueofphoneorpassword);
                }
            }
        }
        private async void OpenOwnerVerifyPage()
        {
            
            Constants.UserMobileNumber = UserMobileNumber;
            Constants.UserEmail = UserMail;
            if (!string.IsNullOrEmpty(Constants.UserMobileNumber) && !string.IsNullOrEmpty(Constants.UserEmail))
            {
                ShowMessege(AppResources.Alert, AppResources.PleaseEnterofMobilephoneorEmail);
            }
            else
            {
                if (!string.IsNullOrEmpty(Constants.UserMobileNumber) || !string.IsNullOrEmpty(Constants.UserEmail))
                {
                    if (!string.IsNullOrEmpty(Constants.UserMobileNumber))
                    {

                        if (!string.IsNullOrEmpty(Constants.UserMobileNumber) && (Constants.UserMobileNumber.Length != 11 || !Constants.UserMobileNumber.StartsWith("01")))
                        {
                            ShowMessege(AppResources.Alert, AppResources.phoneNumberformat);

                        }
                        else
                        {
                            if (await CheckPhoneOrEmail(Constants.UserMobileNumber ?? Constants.UserEmail) == false)
                            {
                                Constants.ShowMobile = false;
                                Constants.ShowEmail = true;
                                var result = await WebService.CheckPhoneNumberOtp();
                                if (result.Result.IsSuccess == true)
                                {
                                    await Application.Current.MainPage.Navigation.PushAsync(new Views.Owner.OwnerVerifyPage());
                                    Constants.UserVerifyCode = result.Result.Otp.ToString();

                                }
                                else
                                {
                                    ShowMessege(AppResources.Alert, result.Result.Message);
                                }
                            }
                            else
                            {
                                ShowMessege(AppResources.Alert, Constants.UserMobileNumber != null ? AppResources.phoneNumberalreadyExist : AppResources.emailalreadyExist);
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(Constants.UserEmail))
                    {
                        if (await CheckPhoneOrEmail(Constants.UserMobileNumber ?? Constants.UserEmail) == false)
                        {
                            if (!IsValidEmails(Constants.UserEmail))
                            {
                                ShowMessege(AppResources.Alert, AppResources.EmailNotValid);
                            }
                            else
                            {
                                Constants.ShowEmail = false;
                                Constants.ShowMobile = true;
                                var result = await WebService.CheckPhoneNumberOtp();
                                if (result.Result.IsSuccess == true)
                                {
                                    await Application.Current.MainPage.Navigation.PushAsync(new Views.Owner.OwnerVerifyPage());
                                    Constants.UserVerifyCode = result.Result.Otp.ToString();

                                }
                                else
                                {
                                    ShowMessege(AppResources.Alert, result.Result.Message);
                                }
                            }
                        }
                        else
                        {
                            ShowMessege(AppResources.Alert, Constants.UserMobileNumber != null ? AppResources.phoneNumberalreadyExist : AppResources.emailalreadyExist);
                        }
                    }
                }
                else
                {
                    ShowMessege(AppResources.Alert, AppResources.pleaseEnterValueofphoneorpassword);
                }
            }
           

        }

        private async void OpenCompanyVerifyPage()
        {

            Constants.UserMobileNumber = UserMobileNumber;
            Constants.UserEmail = UserMail;
            if (!string.IsNullOrEmpty(Constants.UserMobileNumber) && !string.IsNullOrEmpty(Constants.UserEmail))
            {
                ShowMessege(AppResources.Alert, AppResources.PleaseEnterofMobilephoneorEmail);
            }
            else
            {
                if (!string.IsNullOrEmpty(Constants.UserMobileNumber) || !string.IsNullOrEmpty(Constants.UserEmail))
                {
                    if (!string.IsNullOrEmpty(Constants.UserMobileNumber))
                    {

                        if (!string.IsNullOrEmpty(Constants.UserMobileNumber) && (Constants.UserMobileNumber.Length != 11 || !Constants.UserMobileNumber.StartsWith("01")))
                        {
                            ShowMessege(AppResources.Alert, AppResources.phoneNumberformat);

                        }
                        else
                        {
                            if (await CheckPhoneOrEmail(Constants.UserMobileNumber ?? Constants.UserEmail) == false)
                            {
                                Constants.ShowMobile = false;
                                Constants.ShowEmail = true;
                                var result = await WebService.CheckPhoneNumberOtp();
                                if (result.Result.IsSuccess == true)
                                {
                                    await Application.Current.MainPage.Navigation.PushAsync(new Views.Company.VerifyPage());
                                    Constants.UserVerifyCode = result.Result.Otp.ToString();

                                }
                                else
                                {
                                    ShowMessege(AppResources.Alert, result.Result.Message);
                                }

                            }
                            else
                            {
                                ShowMessege(AppResources.Alert, Constants.UserMobileNumber != null ? AppResources.phoneNumberalreadyExist : AppResources.emailalreadyExist);
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(Constants.UserEmail))
                    {
                        if (await CheckPhoneOrEmail(Constants.UserMobileNumber ?? Constants.UserEmail) == false)
                        {
                            if (!IsValidEmails(Constants.UserEmail))
                            {
                                ShowMessege(AppResources.Alert, AppResources.EmailNotValid);
                            }
                            else
                            {
                                Constants.ShowEmail = false;
                                Constants.ShowMobile = true;
                                var result = await WebService.CheckPhoneNumberOtp();
                                if (result.Result.IsSuccess == true)
                                {
                                await App.Current.MainPage.Navigation.PushAsync(new Views.Company.VerifyPage());
                                    Constants.UserVerifyCode = result.Result.Otp.ToString();

                                }
                                else
                                {
                                    ShowMessege(AppResources.Alert, result.Result.Message);
                                }
                            }
                        }
                        else
                        {
                            ShowMessege(AppResources.Alert, Constants.UserMobileNumber != null ? AppResources.phoneNumberalreadyExist : AppResources.emailalreadyExist);
                        }
                    }
                }
                else
                {
                    ShowMessege(AppResources.Alert, AppResources.pleaseEnterValueofphoneorpassword);
                }
            }
            //if (!string.IsNullOrEmpty(Constants.UserMobileNumber) || !string.IsNullOrEmpty(Constants.UserEmail))
            //{
            //    if (!string.IsNullOrEmpty(Constants.UserMobileNumber) && (Constants.UserMobileNumber.Length != 11 || !Constants.UserMobileNumber.StartsWith("01")))
            //    {
            //        ShowMessege(AppResources.Alert, AppResources.phoneNumberformat);
            //        return;
            //    }
            //    else
            //    {
            //        if (await CheckPhoneOrEmail(Constants.UserMobileNumber ?? Constants.UserEmail) == false)
            //        {

            //            Constants.UserVerifyCode = GetVerifyCode();
            //            await Application.Current.MainPage.Navigation.PushAsync(new Views.Company.VerifyPage());
            //        }
            //        else
            //        {
            //            ShowMessege(AppResources.Alert, Constants.UserMobileNumber != null ? AppResources.phoneNumberalreadyExist : AppResources.emailalreadyExist);
            //        }
            //    }

            //}
            //else
            //{
            //    ShowMessege(AppResources.Alert, AppResources.pleaseEnterValueofphoneorpassword);
            //}
           
            }
        public string GetVerifyCode()
        {
            return "1234";
        }
        private async void SaveBrokerCommandClicked(object obj)
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                Model.UserSurname = model.UserName;
                Model.UserPhoneNumber = Model.UserPhoneNumber ?? Constants.UserMobileNumber;
                Model.UserEmailAddress = Model.UserEmailAddress ?? Constants.UserEmail;
                Model.UserId = 0;
                if (!IsValid())
                {
                    return;
                }
                // Model.Gender = IsMale ? 1 : 2;
              
                var res = await WebService.RegisterBroker(Model);
                if (!res.success)
                    ShowMessege(AppResources.Alert, res?.error?.message);
                else if (res?.result?.success != true)
                {
                    ShowMessege(AppResources.Alert, res?.result?.error);
                }
                else if (res?.result?.success == true)
                {
                    Loginmodel.UserNameOrEmailAddress = model.UserEmailAddress;
                    Loginmodel.Password = model.UserPassword;
                    Loginmodel.RememberClient = true;
                    var resd = await WebService.Login(Loginmodel);
                    if (!resd.success)
                        ShowMessege(AppResources.Alert, res?.error.details);
                    //else if (res?.result?.success != true)
                    //{
                    //    ShowMessege(AppResources.Alert, res?.result?.error);
                    //}
                    else if (resd?.success == true)
                    {
                        Application.Current.Properties["LoginType"] = resd.result.LoginType;
                        Constants.LoginType = Convert.ToInt32(Application.Current.Properties["LoginType"]);
                        Application.Current.Properties["TokenAccess"] = Constants.TokenH;
                        Application.Current.Properties["UserId"] = resd.result.userId;
                        Constants.UserId = Application.Current.Properties["UserId"].ToString();
                        await Application.Current.SavePropertiesAsync();
                        Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = new AppShell());
                    }
                    //    ShowMessege(AppResources.Alert, AppResources.RegisteredSuccessfully);
                    //await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    // await Shell.Current.Navigation.PopAsync();
                }
                IsBusy = false;
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
        private async void SaveSeekerCommandClicked(object obj)
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                Model.UserSurname = model.UserName;
                Model.UserPhoneNumber = Model.UserPhoneNumber ?? Constants.UserMobileNumber;
                Model.UserEmailAddress = Model.UserEmailAddress ?? Constants.UserEmail;
                Model.UserId = 0;
                if (!IsValid())
                {
                    return;
                }
                // Model.Gender = IsMale ? 1 : 2;

                var res = await WebService.RegisterSeeker(Model);
                if (!res.success)
                    ShowMessege(AppResources.Alert, res?.error?.message);
                else if (res?.result?.success != true)
                {
                    ShowMessege(AppResources.Alert, res?.result?.error);
                }
                else if (res?.result?.success == true)
                {
                    Loginmodel.UserNameOrEmailAddress = model.UserEmailAddress;
                    Loginmodel.Password = model.UserPassword;
                    Loginmodel.RememberClient = true;
                    var resd = await WebService.Login(Loginmodel);
                    if (!resd.success)
                        ShowMessege(AppResources.Alert, res?.error.details);
                    //else if (res?.result?.success != true)
                    //{
                    //    ShowMessege(AppResources.Alert, res?.result?.error);
                    //}
                    else if (resd?.success == true)
                    {
                        Application.Current.Properties["LoginType"] = resd.result.LoginType;
                        Constants.LoginType = Convert.ToInt32(Application.Current.Properties["LoginType"]);
                        Application.Current.Properties["TokenAccess"] = Constants.TokenH;
                        Application.Current.Properties["UserId"] = resd.result.userId;
                        Constants.UserId = Application.Current.Properties["UserId"].ToString();
                        await Application.Current.SavePropertiesAsync();
                        Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = new AppShell());
                    }
                    //    ShowMessege(AppResources.Alert, AppResources.RegisteredSuccessfully);
                    //await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    // await Shell.Current.Navigation.PopAsync();
                }
                IsBusy = false;
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
        private async void SaveOwnerCommandClicked(object obj)
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                Model.UserSurname = model.UserName;
                Model.UserPhoneNumber = Model.UserPhoneNumber ?? Constants.UserMobileNumber;
                Model.UserEmailAddress = Model.UserEmailAddress ?? Constants.UserEmail;
                Model.UserId = 0;
                if (!IsValid())
                {
                    return;
                }
                // Model.Gender = IsMale ? 1 : 2;

                var res = await WebService.RegisterOwner(Model);
                if (!res.success)
                    ShowMessege(AppResources.Alert, res?.error?.message);
                else if (res?.result?.success != true)
                {
                    ShowMessege(AppResources.Alert, res?.result?.error);
                }
                else if (res?.result?.success == true)
                {
                    Loginmodel.UserNameOrEmailAddress = model.UserEmailAddress;
                    Loginmodel.Password = model.UserPassword;
                    Loginmodel.RememberClient = true;
                    var resd = await WebService.Login(Loginmodel);
                    if (!resd.success)
                        ShowMessege(AppResources.Alert, res?.error.details);
                    //else if (res?.result?.success != true)
                    //{
                    //    ShowMessege(AppResources.Alert, res?.result?.error);
                    //}
                    else if (resd?.success == true)
                    {
                        Application.Current.Properties["LoginType"] = resd.result.LoginType;
                        Constants.LoginType = Convert.ToInt32(Application.Current.Properties["LoginType"]);
                        Application.Current.Properties["TokenAccess"] = Constants.TokenH;
                        Application.Current.Properties["UserId"] = resd.result.userId;
                        Constants.UserId = Application.Current.Properties["UserId"].ToString();
                        await Application.Current.SavePropertiesAsync();
                        Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = new AppShell());
                    }
                    //    ShowMessege(AppResources.Alert, AppResources.RegisteredSuccessfully);
                    //await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    // await Shell.Current.Navigation.PopAsync();
                }
                IsBusy = false;
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
        private async void SaveCompanyCommandClicked(object obj)
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                Model.UserSurname = model.UserName;
                Model.UserPhoneNumber = Model.UserPhoneNumber ?? Constants.UserMobileNumber;
                Model.UserEmailAddress = Model.UserEmailAddress ?? Constants.UserEmail;
                Model.UserId = 0;
                if (!IsValid())
                {
                    return;
                }
                // Model.Gender = IsMale ? 1 : 2;

                var res = await WebService.RegisterCompany(Model);
                if (!res.success)
                    ShowMessege(AppResources.Alert, res?.error?.message);
                else if (res?.result?.success != true)
                {
                    ShowMessege(AppResources.Alert, res?.result?.error);
                }
                else if (res?.result?.success == true)
                {
                    Loginmodel.UserNameOrEmailAddress = model.UserEmailAddress;
                    Loginmodel.Password = model.UserPassword;
                    Loginmodel.RememberClient = true;
                    var resd = await WebService.Login(Loginmodel);
                    if (!resd.success)
                        ShowMessege(AppResources.Alert, res?.error.details);
                    //else if (res?.result?.success != true)
                    //{
                    //    ShowMessege(AppResources.Alert, res?.result?.error);
                    //}
                    else if (resd?.success == true)
                    {
                        Application.Current.Properties["LoginType"] = resd.result.LoginType;
                        Constants.LoginType = Convert.ToInt32(Application.Current.Properties["LoginType"]);
                        Application.Current.Properties["TokenAccess"] = Constants.TokenH;
                        Application.Current.Properties["UserId"] = resd.result.userId;
                        Constants.UserId = Application.Current.Properties["UserId"].ToString();
                        await Application.Current.SavePropertiesAsync();
                        Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = new AppShell());
                    }
                    //    ShowMessege(AppResources.Alert, AppResources.RegisteredSuccessfully);
                    //await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    // await Shell.Current.Navigation.PopAsync();
                }
                IsBusy = false;
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
            if (string.IsNullOrEmpty(Model.UserName)|| IsValidName(Model.UserName))
            {
                ShowMessege(AppResources.Alert, AppResources.InvalidUserName);
                return false;
            }
            if (string.IsNullOrEmpty(Model.UserPassword))
            {
                ShowMessege(AppResources.Alert, AppResources.InvalidPassword);
                return false;
            }
            if (string.IsNullOrEmpty(Model.ConfirmUserPassword))
            {
                ShowMessege(AppResources.Alert, AppResources.InvalidConfirmPassword);
                return false;
            }
            if (string.IsNullOrEmpty(Model.UserPhoneNumber))
            {
                ShowMessege(AppResources.Alert, AppResources.InvalidPhone);
                return false;
            }

            if (!IsValidEmails(Model.UserEmailAddress))
            {
                ShowMessege(AppResources.Alert, AppResources.invalidEmailAddres);
                return false;
            }
            if (Model.UserPassword != Model.ConfirmUserPassword)
            {
                ShowMessege(AppResources.Alert, AppResources.PasswordNotMatch);
                return false;
            }

            return true;
        }
        bool IsValidName(string name)
        {
            string pattern = "^[0-9]+$";
            return  Regex.IsMatch(name, pattern);
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
    }
}

