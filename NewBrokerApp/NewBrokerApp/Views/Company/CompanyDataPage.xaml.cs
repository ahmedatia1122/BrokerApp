using NewBrokerApp.ViewModels;
using Plugin.Media.Abstractions;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NewBrokerApp.Models;
using NewBrokerApp.Views.Popup;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Essentials;
using Location = Xamarin.Essentials.Location;

namespace NewBrokerApp.Views.Company
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompanyDataPage : ContentPage
	{
        AccountViewModel viewModel;
        MediaFile _mediaFile;

        public CompanyDataPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new AccountViewModel();
            viewModel.PersonDetailsCommand.Execute(true);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return;
                imglogo.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                viewModel.CompanyDetailsItem.PictureLogo = _mediaFile;
            }
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return;
                imgBwLogo.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                viewModel.CompanyDetailsItem.PictureBwLogo = _mediaFile;
            }
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return;
                imgCommericalAvatar.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                viewModel.CompanyDetailsItem.PictureCommericalAvatar = _mediaFile;
            }
        }

        private async void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            var tcs = new TaskCompletionSource<CompanyDetailsModel>();
            await PopupNavigation.Instance.PushAsync(new GetAddressCompanyPage(viewModel.CompanyDetailsItem,tcs));
            //await Navigation.PushPopupAsync(new CityPage(tcs));
            var data = await tcs.Task;
                viewModel.CompanyDetailsItem.Latitude = data.Latitude;
                viewModel.CompanyDetailsItem.Longitude = data.Longitude;
                Geocoder geoCoder = new Geocoder();
                var address = await geoCoder.GetAddressesForPositionAsync(new Position(Convert.ToDouble(data.Latitude), Convert.ToDouble(data.Longitude)));
                string alladdString = "";
            Location location = new Location(Convert.ToDouble(data.Latitude), Convert.ToDouble(data.Longitude));
            var placemark = await Geocoding.GetPlacemarksAsync(location);
            var dd = address.FirstOrDefault();
            var lists = dd.Split(',');
            var allString = lists.FirstOrDefault();
            var allasddString = allString.Split(',');
            alladdString = allasddString.FirstOrDefault();
            var Province = placemark.ToList();
            var Provsince = Province[0];
            // الحصول على اسم البلد
           var Country = Provsince.CountryName;
            var Locality = Provsince.Locality;
            // الحصول على اسم المحافظة
            var Provinces = Provsince.AdminArea.Replace(" Governorate", "");
            // الحصول على اسم المدينة
            var City = Provsince.SubAdminArea;
            // الحصول على اسم الشارع
            if (Provsince.Thoroughfare == null)
            {
                 alladdString = alladdString;
            }
            else
            {
                alladdString = Provsince.Thoroughfare;
            }
            txtLocation.Text = Locality + "," + City + "," + Provinces;
        }
    }
}