using NewBrokerApp.Helpers;
using NewBrokerApp.Resources;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views;
using NewBrokerApp.Views.Common;
using NewBrokerApp.Views.Company;
using NewBrokerApp.Views.PropertiesAds;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NewBrokerApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
           // Shell myShell = (Shell)this.FindByName("Shell");
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Constants.LoginType = Application.Current.Properties.ContainsKey("LoginType") ? Convert.ToInt32(Application.Current.Properties["LoginType"]):0;
            if (Constants.LoginType == 3)
            {
                txdata.Text = AppResources.CompanyData;
                txtProject.IsVisible = true;
                txtWallet.IsVisible = true;
                //txtProject.IconImageSource = "Project.svg";
                //txtProject.@class.Clear(); txtProject.@class.Add("MenuItemLayoutStyle");
            }
          
            else
            {
                txdata.Text = AppResources.PersonalData;
                txtProject.IsVisible = false;
                txtWallet.IsVisible = false;
                //txtProject.Text = "";
                //txtProject.IconImageSource = "";
                //txtProject.IsEnabled= false;
                //var myShellSection = myShell.Items.FirstOrDefault()?.Items.FirstOrDefault();

                //// Find the MenuItem control you want to remove
                //var menuItemToRemove = myShellSection?.Items.FirstOrDefault()?.MenuItems.FirstOrDefault(m => m.Text == AppResources.Projects);

                //if (menuItemToRemove != null)
                //{
                //    // Remove the MenuItem control from the MenuItems collection
                //    myShellSection.Items.FirstOrDefault()?.MenuItems.Remove(menuItemToRemove);
                //}

                //txtProject.@class.Clear(); txtProject.@class.Add("MenuItemLayoutStyleHidden");
            }
            //SignOuttxt.
            //txtVersion.Text = VersionTracking.CurrentVersion;
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
           // this.FlyoutIsPresented = false;
            await PopupNavigation.Instance.PushAsync(new LanguagePopUp());
        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            //this.FlyoutIsPresented = false;
            await PopupNavigation.Instance.PushAsync(new RatePopUp());
        }

        private async void MenuItem_Clicked_2(object sender, EventArgs e)
        {
            this.FlyoutIsPresented = false;
            await Shell.Current.Navigation.PushAsync(new ContactUsPage());
        }

        private async void MenuItem_Clicked_3(object sender, EventArgs e)
        {
            this.FlyoutIsPresented = false;
            await Shell.Current.Navigation.PushAsync(new SponsorPage());
        }

        private async void MenuItem_Clicked_4(object sender, EventArgs e)
        {

            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                this.FlyoutIsPresented = false;
                await Shell.Current.Navigation.PushAsync(new ChangePasswordPage());
            }
            else
            {
                this.FlyoutIsPresented = false;
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            
        }

        private async void MenuItem_Clicked_5(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                this.FlyoutIsPresented = false;
                await PopupNavigation.Instance.PushAsync(new DeleteAccountPopUp());
            }
            else
            {
                this.FlyoutIsPresented = false;
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
           
        }

        private async void MenuItem_Clicked_6(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                this.FlyoutIsPresented = false;
                await PopupNavigation.Instance.PushAsync(new SignOutPopUp());
            }
            else
            {
                this.FlyoutIsPresented = false;
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }

            
        }

        private async void MenuItem_Clicked_7(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                if (Constants.LoginType == 3)
                {
                    this.FlyoutIsPresented = false;
                    await Shell.Current.Navigation.PushAsync(new CompanyDataPage());
                }
                else
                {
                    this.FlyoutIsPresented = false;
                    await Shell.Current.Navigation.PushAsync(new PersonalDetailPage());
                }
            }
            else
            {
                this.FlyoutIsPresented = false;
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            
           
        }

        private async void MenuItem_Clicked_8(object sender, EventArgs e)
        {
            this.FlyoutIsPresented = false;
            await Shell.Current.Navigation.PushAsync(new AddProjectPage());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                this.FlyoutIsPresented = false;
                await Shell.Current.Navigation.PushAsync(new UploadPhotoPage());
            }
            else
            {
                this.FlyoutIsPresented = false;
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
           
        }

        private async void MenuItem_Clicked_9(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                this.FlyoutIsPresented = false;
                await Shell.Current.Navigation.PushAsync(new BrokerPointPage());
            }
            else
            {
                this.FlyoutIsPresented = false;
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            
        }

        private async void MenuItem_Clicked_10(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                this.FlyoutIsPresented = false;
                await Shell.Current.Navigation.PushAsync(new WalletPage());
            }
            else
            {
                this.FlyoutIsPresented = false;
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }

        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
            {
                this.FlyoutIsPresented = false;
                await PopupNavigation.Instance.PushAsync(new SignOutPopUp());
            }
            else
            {
                this.FlyoutIsPresented = false;
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
        }
    }
}
