using NewBrokerApp.Helpers;
using NewBrokerApp.Resources;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePopUp : PopupPage
    {
        public LanguagePopUp()
        {
            InitializeComponent();
        }
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
        private async void TappedChangedAr(object sender, EventArgs e)
        {
            if (Constants.SelectedIndex != 1)
            {

                Constants.SelectedIndex = 1;
                CultureInfo language = new CultureInfo("ar");
                Thread.CurrentThread.CurrentUICulture = language;
                AppResources.Culture = language;
                Application.Current.Properties["Lang"] = (int)AppLanguage.Arabic;
                await Application.Current.SavePropertiesAsync();
                var langService = DependencyService.Get<ILanguageManager>();
                await langService.ChangeLanguage(AppLanguage.Arabic);
                Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = new AppShell());
                await PopupNavigation.Instance.PopAsync();
            }
        }
        private async  void TappedChangedEn(object sender, EventArgs e)
        {
            if (Constants.SelectedIndex != 0)
            {
                Constants.SelectedIndex = 0;
                CultureInfo language = new CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = language;
                AppResources.Culture = language;
                Application.Current.Properties["Lang"] = (int)AppLanguage.English;
                await Application.Current.SavePropertiesAsync();
                var langService = DependencyService.Get<ILanguageManager>();
                await langService.ChangeLanguage(AppLanguage.English);
                Device.BeginInvokeOnMainThread(() => Application.Current.MainPage = new AppShell());
                await PopupNavigation.Instance.PopAsync();
            }
        }
    }
}