using FFImageLoading.Forms;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Common;
using NewBrokerApp.Views.Controls;
using NewBrokerApp.Views.Popup;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
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
	public partial class AddsPage : ContentPage
	{
		AddsViewModel viewModel = new AddsViewModel();
		public AddsPage ()
		{
			InitializeComponent ();
			BindingContext= viewModel;
		
			stkFooter.Children.Add(new Footer("ads", this));
		}
        protected override void OnAppearing()
        {
            if (viewModel.AddsItems.Count == 0)
                viewModel.LoadPropertiesAddsCommand.Execute(true);
            base.OnAppearing();
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           // await PopupNavigation.Instance.PushAsync(new DeleteAdPopup());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
			await Shell.Current.Navigation.PushAsync(new PropertyDetails());
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            viewModel.IsBusy = true;
            var Id = (CachedImage)sender;
           var idHolder = Id.ClassId;
            await Task.Run(() =>
             {
                 Constants.NavigationParamter = idHolder;
                  // Shell.Current.Navigation.PushPopupAsync(new DeleteAdPopup());
                 viewModel.LoadPropertiesAddsCommand.Execute(true);
                 viewModel.IsBusy = false;
             });
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            var model = ((CachedImage)sender).BindingContext as Advertisement;
            Constants.NavigationParamter = model.Id;
            var data = await waitForDeletePopup();
            if (data == true)
            {
                viewModel.DeleteAdSameCommand.Execute(true);
            }
        }
       
        private async Task<bool> waitForDeletePopup()
        {
            var tcs = new TaskCompletionSource<bool>();
            await PopupNavigation.Instance.PushAsync(new DeleteAdPopup(tcs));
            return await tcs.Task;
        }
        private async void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            try{
                var lablId =(CarouselView)( ((CachedImage)sender).Parent);
                var Id = lablId.ClassId;
                Constants.NavigationParamter = Id;
                await Shell.Current.Navigation.PushAsync(new PropertyDetails());
            }
            catch (Exception ex)
            {

            }
           

        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new AppShell();
            // true or false to disable or enable the action
            return base.OnBackButtonPressed();
        }
    }
}