using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Popup;

using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace NewBrokerApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PropertyDetails : ContentPage
	{
		AddsViewModel viewModel;
		public PropertyDetails ()
		{
			InitializeComponent ();
            DateTime dt = DateTime.Now;
            var month = dt.ToString("MMMM");
            var nextMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            var monthStart = new DateTime(dt.Year, dt.Month, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1).ToString("MMMM dd yyyy");
            var nextMonthEnd = monthStart.AddMonths(2).AddDays(-1).ToString("MMMM dd yyyy");
           // txtMonth.Text = $"from 1st {month} to {monthEnd}";
           // txtnextMonth.Text = $"from 1st {nextMonth} to {nextMonth} {nextMonthEnd}";
            //calendar.Locale = new System.Globalization.CultureInfo("en-US");
           // calendarNext.Locale = new System.Globalization.CultureInfo("en-US");
           // calendar.MoveToDate = new DateTime(dt.Year, dt.Month, 1);
            var nextMonths = DateTime.Now.AddMonths(1);
           // calendarNext.MoveToDate = new DateTime(dt.Year, nextMonths.Month, 1);
            BindingContext =viewModel=new AddsViewModel ();
			viewModel.LoadAddDetailsCommand.Execute (this);
		}

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
			await Shell.Current.Navigation.PopAsync();
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Map.OpenAsync(Convert.ToDouble(viewModel.AddDetailsItem.Latitude?? 30.6730758), Convert.ToDouble(viewModel.AddDetailsItem.Longitude ?? 31.7197933), new MapLaunchOptions { NavigationMode = NavigationMode.None });
          //  await PopupNavigation.Instance.PushAsync(new LocationPage(viewModel.AddDetailsItem.Longitude, viewModel.AddDetailsItem.Latitude));
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
          // await CrossShare.Current.ShareLink("");
            var deep = "https://broker.nahrdev.website/page1?data=" + viewModel.AddDetailsItem.Id;

            await Share.RequestAsync(new ShareTextRequest
            {
               // Text = viewModel.AddDetailsItem.Id.ToString(),
                Title = viewModel.AddDetailsItem.Title,
                Uri = new Uri(deep).ToString(),
            }) ;
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