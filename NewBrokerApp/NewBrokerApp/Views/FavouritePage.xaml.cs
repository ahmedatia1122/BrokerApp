using FFImageLoading.Forms;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavouritePage : ContentPage
	{
        AddsViewModel viewModel;
        public FavouritePage ()
		{
			InitializeComponent ();
            BindingContext = viewModel=new AddsViewModel();
            viewModel.LoadFavouritesAddsCommand.Execute(true);
            stkFooter.Children.Add(new Footer("favourite", this));
        }

       

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var item = ((Frame)sender).BindingContext as Favourite;
            Constants.NavigationParamter = item.AdvertisementId;
            await Shell.Current.Navigation.PushAsync(new PropertyDetails());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var item = ((CachedImage)sender).BindingContext as Favourite;
            viewModel.FavouriteId= item.Id;
           viewModel.DeleteFavoriteCommand.Execute(true);

        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            var item = ((Frame)sender).BindingContext as Favourite;
            if (!string.IsNullOrEmpty( item.MobileNumber))
            {
                Chat.Open("+2" + item.MobileNumber);
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