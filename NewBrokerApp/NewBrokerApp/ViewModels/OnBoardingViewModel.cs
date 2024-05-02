using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.Views;
using NewBrokerApp.Views.Company;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewBrokerApp.ViewModels
{
    public class OnBoardingViewModel : BaseViewModel
    {
        public Command OpenLoginPageCommand { get; }
        public Command OpenCompanySignUpPageCommand { get; }
        public Command OpenPersonSignUpPageCommand { get; }
        public Command OpenVerifyPageCommand { get; }
        public Command OpenPersonalDataPageCommand { get; }
        public Command OpenPersonalDetailPageCommand { get; }
        public Command OpenHomePageCommand { get; }
        public Command OpenChooseAccountCommand { get; }
        public Command OpenBrokerSignUpPageCommand { get; }
        public Command OpenOwnerSignUpPageCommand { get; }
        public Command OpenSeekerSignUpPageCommand { get; }
        public ICommand InitCommand { get; }
        public OnBoardingViewModel()
        {

            InitCommand = new Command(InitCommandClicked);
            OpenLoginPageCommand = new Command(OpenLoginPage);
            OpenCompanySignUpPageCommand = new Command(OpenCompanySignUpPage);
            OpenVerifyPageCommand = new Command(OpenVerifyPage);
            OpenPersonalDataPageCommand= new Command(OpenPersonalDataPage);
            OpenPersonalDetailPageCommand = new Command(OpenPersonalDetailsPage);
            OpenHomePageCommand = new Command(OpenHomePage);
            OpenChooseAccountCommand = new Command(OpenChooseAccount);
            OpenPersonSignUpPageCommand = new Command(OpenPersonSignUpPage);
            OpenBrokerSignUpPageCommand = new Command(OpenBrokerSignUpPage);
            OpenSeekerSignUpPageCommand = new Command(OpenSeekerSignUpPage);
            OpenOwnerSignUpPageCommand = new Command(OpenOwnerSignUpPage);

        }
        //private async void GetSettings()
        //{
        //    try
        //    {
        //        SettingsResponse result = new SettingsResponse();               
    
        //        switch (Constants.LoginType)
        //        {
        //            case 0:
        //                result =await WebService.GetSeekerSettings(Convert.ToInt64(Constants.UserId));
        //                if (result?.result?.success != true && !string.IsNullOrEmpty(result?.result?.error))
        //                {
        //                    IsLogin = false;
        //                }
        //                else if (result?.result?.success == true)
        //                {
        //                    Constants.SeekerId = result.result.setting.Id;
        //                }
        //                break;
        //            case 1:
        //                result =await WebService.GetOwnerSettings(Convert.ToInt64(Constants.UserId));
        //                if (result?.result?.success != true && !string.IsNullOrEmpty(result?.result?.error))
        //                {
        //                    IsLogin = false;
        //                }
        //                else if (result?.result?.success == true)
        //                {
        //                    Constants.OwnerId = result.result.setting.Id;
        //                }
        //                break;
        //            case 2:
        //                result  =await WebService.GetBrokerSettings(Convert.ToInt64(Constants.UserId));
        //                if (result?.result?.success != true && !string.IsNullOrEmpty(result?.result?.error))
        //                {
        //                    IsLogin = false;
        //                }
        //                else if (result?.result?.success == true)
        //                {
        //                    Constants.BrokerId = result.result.setting.Id;
        //                }
        //                break;
        //            case 3:
        //                result = await WebService.GetCompanySettings(Convert.ToInt64(Constants.UserId));
        //                if (result?.result?.success != true && !string.IsNullOrEmpty(result?.result?.error))
        //                {
        //                    IsLogin = false;
        //                }
        //                else if (result?.result?.success == true)
        //                {
        //                    Constants.CompanyId = result.result.setting.Id;
        //                }
        //                break;

        //        }
               
                

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        private async void InitCommandClicked(object obj)
        {
            try
            {
                IsLoading = true;
                if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
                {
                    Constants.TokenH = Application.Current.Properties["TokenAccess"].ToString();
                  

                    IsLogin = true;
                    //  GetSettings();
                    if (Application.Current.Properties.ContainsKey("Lang") && Application.Current.Properties["Lang"] != null)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                    {

                        Constants.SelectedIndex = Convert.ToInt32(Application.Current.Properties["Lang"]);
                        var lang = Constants.SelectedIndex == 1 ? "ar" : "en";
                        CultureInfo language = new CultureInfo(lang);
                        Thread.CurrentThread.CurrentUICulture = language;
                        AppResources.Culture = language;
                        var langService = DependencyService.Get<ILanguageManager>();
                        await langService.ChangeLanguage((AppLanguage)Constants.SelectedIndex);
                        Application.Current.MainPage = new AppShell();
                        IsLoading = false;

                    });
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            
                            Constants.SelectedIndex = 0;
                            var lang = Constants.SelectedIndex == 1 ? "ar" : "en";
                            CultureInfo language = new CultureInfo(lang);
                            Thread.CurrentThread.CurrentUICulture = language;
                            AppResources.Culture = language;
                            var langService = DependencyService.Get<ILanguageManager>();
                            await langService.ChangeLanguage((AppLanguage)Constants.SelectedIndex);
                            Application.Current.MainPage = new AppShell();

                            IsLogin = false;
                            IsLoading = false;
                        });
                    }
                }
                else
                {
                    
                    
                        IsLogin = false;

                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            Constants.SelectedIndex = 0;
                            var lang = Constants.SelectedIndex == 1 ? "ar" : "en";
                            CultureInfo language = new CultureInfo(lang);
                            Thread.CurrentThread.CurrentUICulture = language;
                            AppResources.Culture = language;
                            var langService = DependencyService.Get<ILanguageManager>();
                            await langService.ChangeLanguage((AppLanguage)Constants.SelectedIndex);
                            Application.Current.MainPage = new NavigationPage(new IntroductionPage());

                        }
                   );
                
                }

            
            }
            catch (System.Exception ex)
            {
                IsLoading = false;
            }
            finally
            {
                IsLoading = false;
            }
        }
        bool iLoading = false;
        public bool IsLoading
        {
            get { return iLoading; }
            set { SetProperty(ref iLoading, value); }
        }
        private async void OpenBrokerSignUpPage()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Views.Broker.BrokerSignUpPage());
        }
        private async void OpenSeekerSignUpPage()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Views.Seeker.SeekerSignUpPage());
        }
        private async void OpenOwnerSignUpPage()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Views.Owner.OwnerSignUpPage());
        }
        private async void OpenLoginPage()
        {
          
            await Application.Current.MainPage.Navigation.PushAsync(new Views.LoginPage());
        }
        private async void OpenVerifyPage()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Views.VerifyCodePage());
        }
        private async void OpenPersonSignUpPage()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Views.SignUpPage());
        }
        private async void OpenCompanySignUpPage()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new signUpPage());
        }
        private async void OpenPersonalDataPage()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Views.CompanySignUp2Page());
        }
        private async void OpenPersonalDetailsPage()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new Views.PersonalDetailPage());
        }
        private async void OpenHomePage()
        {

             Application.Current.MainPage=new  AppShell();
        }
        private async void OpenChooseAccount(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            // await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            await Application.Current.MainPage.Navigation.PushAsync(new Views.ChooseSignUpPage());

        }
    }
}
