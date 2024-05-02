using NewBrokerApp.Helpers;
using NewBrokerApp.Resources;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Owner;
using Plugin.Media.Abstractions;
using Plugin.Media;
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
    public partial class UploadPhotoPage : ContentPage
    {
        AccountViewModel viewModel;
        MediaFile _mediaFile;
        public UploadPhotoPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AccountViewModel();
            viewModel.PersonDetailsCommand.Execute(true);


        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
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
                imgAvatar.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                imgAvatarCompany.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                //viewModel.CompanyDetailsItem.PictureAvatar = _mediaFile;
                frmSave.IsVisible = true;
               
               
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {
                if (Constants.LoginType == 3)
                {
                    viewModel.CompanyDetailsItem.PictureLogo = _mediaFile;
                    viewModel.UpdateCompanyAccountCommand.Execute(true);
                }
                else
                {
                    viewModel.PersonDetailsItem.PrfilAvatar = _mediaFile;
                    viewModel.UpdateAccountCommand.Execute(true);
                }
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
