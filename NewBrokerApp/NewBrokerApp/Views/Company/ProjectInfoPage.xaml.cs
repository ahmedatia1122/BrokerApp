using Plugin.Media.Abstractions;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Resources;


namespace NewBrokerApp.Views.Company
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectInfoPage : ContentPage
    {
        ProjectViewModel viewModel;
        MediaFile _mediaFile;
        MediaFile _mediaFile2;
        MediaFile _mediaFile3;
        MediaFile _mediaFile4;
        MediaFile _mediaFile5;
        MediaFile _mediaFile6;
        MediaFile _mediaFile7;
        MediaFile _mediaFile8;
        MediaFile _mediaFile9;
        MediaFile _mediaFile10;
        MediaFile _mediaFile11;
        MediaFile _mediaFile12;
        public ProjectInfoPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProjectViewModel();
            stkBasicInfo.IsVisible = true;
            stkPhoto.IsVisible = false;
            stkLayout.IsVisible = false;
            stkProject.IsVisible = false;
          
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (stkBasicInfo.IsVisible == true)
            {
                await Shell.Current.Navigation.PushAsync(new AddProjectPage());

            }
            else if (stkPhoto.IsVisible == true)
            {
                stkBasicInfo.IsVisible = true;
                stkPhoto.IsVisible = false;
                stkLayout.IsVisible = false;
                stkProject.IsVisible = false;
            }
            else if (stkLayout.IsVisible == true)
            {

                stkBasicInfo.IsVisible = false;
                stkPhoto.IsVisible = true;
                stkLayout.IsVisible = false;
                stkProject.IsVisible = false;
            }

            else if (stkProject.IsVisible == true)
            {
                stkBasicInfo.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkLayout.IsVisible = true;
                stkProject.IsVisible = false;
            }
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new AddProjectPage());
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (!IsValidProjectName())
            {
                return;
            }
            stkBasicInfo.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkLayout.IsVisible = false;
            stkProject.IsVisible = false;
        }
        private bool IsValidProjectName()
        {
            if (string.IsNullOrEmpty(textName.Text))
            {
                App.Current.MainPage.DisplayAlert("", AppResources.InvalidUserName, AppResources.ok);

                return false;
            }
            return true;
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
                firstPhoto.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                viewModel.ProjectDetailsItem.MediaFiles.Add(_mediaFile);
            }
        }
        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            try
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
                    _mediaFile2 = await CrossMedia.Current.PickPhotoAsync();
                    if (_mediaFile2 == null) return;
                    SecondPhoto.Source = ImageSource.FromStream(() => _mediaFile2.GetStream());
                    viewModel.ProjectDetailsItem.MediaFiles.Add(_mediaFile2);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private async void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            try
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
                    _mediaFile3 = await CrossMedia.Current.PickPhotoAsync();
                    if (_mediaFile3 == null) return;
                    ThirdPhoto.Source = ImageSource.FromStream(() => _mediaFile3.GetStream());
                    viewModel.ProjectDetailsItem.MediaFiles.Add(_mediaFile3);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            frmPhoto.IsVisible = false;
            gridPhoto.IsVisible = true;

        }

        private async void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            try
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
                    _mediaFile4 = await CrossMedia.Current.PickPhotoAsync();
                    if (_mediaFile4 == null) return;
                    fourthPhoto.Source = ImageSource.FromStream(() => _mediaFile4.GetStream());
                    viewModel.ProjectDetailsItem.MediaFiles.Add(_mediaFile4);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private async void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
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
                _mediaFile5 = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile5 == null) return;
                fivePhoto.Source = ImageSource.FromStream(() => _mediaFile5.GetStream());
                viewModel.ProjectDetailsItem.MediaFiles.Add(_mediaFile5);
            }
        }

        private async void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
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
                _mediaFile6 = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile6 == null) return;
                SixPhoto.Source = ImageSource.FromStream(() => _mediaFile6.GetStream());
                viewModel.ProjectDetailsItem.MediaFiles.Add(_mediaFile6);
            }

        }
        private async void TapGestureRecognizer_Tapped_30(object sender, EventArgs e)
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
                _mediaFile7 = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile7 == null) return;
                firstLayout.Source = ImageSource.FromStream(() => _mediaFile7.GetStream());
                viewModel.ProjectDetailsItem.MediaFilesLayout.Add(_mediaFile7);
            }
        }

        private async void TapGestureRecognizer_Tapped_31(object sender, EventArgs e)
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
                _mediaFile8 = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile8 == null) return;
                SecondLayout.Source = ImageSource.FromStream(() => _mediaFile8.GetStream());
                viewModel.ProjectDetailsItem.MediaFilesLayout.Add(_mediaFile8);
            }
        }

        private async void TapGestureRecognizer_Tapped_32(object sender, EventArgs e)
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
                _mediaFile9 = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile9 == null) return;
                ThirdLayout.Source = ImageSource.FromStream(() => _mediaFile9.GetStream());
                viewModel.ProjectDetailsItem.MediaFilesLayout.Add(_mediaFile9);
            }
        }

        private async void TapGestureRecognizer_Tapped_33(object sender, EventArgs e)
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
                _mediaFile10 = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile10 == null) return;
                fourthLayout.Source = ImageSource.FromStream(() => _mediaFile10.GetStream());
                viewModel.ProjectDetailsItem.MediaFilesLayout.Add(_mediaFile10);
            }
        }

        private async void TapGestureRecognizer_Tapped_34(object sender, EventArgs e)
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
                _mediaFile11 = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile11 == null) return;
                fiveLayout.Source = ImageSource.FromStream(() => _mediaFile11.GetStream());
                viewModel.ProjectDetailsItem.MediaFilesLayout.Add(_mediaFile11);
            }
        }

        private async void TapGestureRecognizer_Tapped_35(object sender, EventArgs e)
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
                _mediaFile12 = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile12 == null) return;
                SixLayout.Source = ImageSource.FromStream(() => _mediaFile12.GetStream());
                viewModel.ProjectDetailsItem.MediaFilesLayout.Add(_mediaFile12);
            }
        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            if (!IsValidPhotos())
            {
                return;
            }

            stkBasicInfo.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkLayout.IsVisible = true;
            stkProject.IsVisible = false;
        }
        private bool IsValidPhotos()
        {

            if (viewModel.ProjectDetailsItem.MediaFiles.Count == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.pleaseUploadAtleatestonePhoto, AppResources.ok);

                return false;
            }
            return true;
        }

        private void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {
            stkBasicInfo.IsVisible = true;
            stkPhoto.IsVisible = false;
            stkLayout.IsVisible = false;
            stkProject.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_12(object sender, EventArgs e)
        {
            stkBasicInfo.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkLayout.IsVisible = false;
            stkProject.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_13(object sender, EventArgs e)
        {
            if (!IsValidLayout())
            {
                return;
            }
            stkBasicInfo.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkLayout.IsVisible = false;
            stkProject.IsVisible = true;
        }
        private bool IsValidLayout()
        {
            if (viewModel.ProjectDetailsItem.MediaFilesLayout.Count == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.pleaseUploadAtleatestoneLayout, AppResources.ok);

                return false;
            }
            return true;
        }
        private async void TapGestureRecognizer_Tapped_29(object sender, EventArgs e)
        {
            frmLayout.IsVisible = false;
            gridLayout.IsVisible = true;
        }
        private async void TapGestureRecognizer_Tapped_36(object sender, EventArgs e)
        {
            stkBasicInfo.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkLayout.IsVisible = true;
            stkProject.IsVisible = false;
        }
    }
}