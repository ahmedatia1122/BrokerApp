using NewBrokerApp.Helpers;
using NewBrokerApp.ViewModels;
using RatingBarControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoInternetPage : ContentPage
    {
      //  public ILanguageService _languageService => DependencyService.Get<ILanguageService>();

        BaseViewModel _viewModel;

        public NoInternetPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new BaseViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Constants.NoInternet = true;
            _viewModel.IsEnabled = true;
        }

        public async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                _viewModel.IsBusy = true;
                _viewModel.IsEnabled = false;

                // await _languageService.GetListAsync();
                Constants.NoInternet = false;
                if (Application.Current.Properties.ContainsKey("TokenAccess") && Application.Current.Properties["TokenAccess"] != null)
                {
                   // App.Current.MainPage.Navigation.PopAsync();
                    App.Current.MainPage =  new AppShell();
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() => {
                        App.Current.MainPage.Navigation.PopAsync();
                       // Shell.Current.Navigation.PopAsync();
                        App.Current.MainPage.Navigation.PushAsync(new IntroductionPage());

                    });
                  
                }

            }
        }
        Boolean blnShouldStay = true;
        protected override bool OnBackButtonPressed()
        {
            if (blnShouldStay)
            {
                // Yes, we want to stay.
                return true;
            }
            else
            {
                // It's okay, we can leave.
                base.OnBackButtonPressed();
                return false;
            }
        }
       
    }
}