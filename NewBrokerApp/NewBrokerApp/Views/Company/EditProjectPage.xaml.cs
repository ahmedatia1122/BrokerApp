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
using FFImageLoading.Forms;
using NewBrokerApp.Helpers;
using System.Net.Http;
using System.IO;
using NewBrokerApp.Models;
using NewBrokerApp.Views.Common;
using Rg.Plugins.Popup.Services;

namespace NewBrokerApp.Views.Company
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProjectPage : ContentPage
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
        public EditProjectPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProjectViewModel();
            if (Constants.ProjectId != null)
            {
                stkBasicInfo.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkLayout.IsVisible = false;
                stkProject.IsVisible = true;
                Constants.NavigationProject=Convert.ToInt32( Constants.ProjectId.ToString());
            }
            else
            {
                stkBasicInfo.IsVisible = true;
                stkPhoto.IsVisible = false;
                stkLayout.IsVisible = false;
                stkProject.IsVisible = false;
            }
           
            viewModel.LoadGetProjectDetailsCommand.Execute(true);
            

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
            //if (!IsValidProjectName())
            //{
            //    return;
            //}
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
            var grid = (Grid)sender;
            var item = (string)grid.BindingContext;
            var img = (CachedImage)grid.Children.ElementAt(0);
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
                img.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                var data = viewModel.PropertyPhotos.IndexOf(item);
                if (data >= 0)
                {
                    viewModel.PropertyPhotos[data] = await uploadFile();
                }
                else
                {
                    viewModel.PropertyPhotos.Add(await uploadFile());
                }
                // var data = viewModel.PropertyPhotos.ToList().IndexOf(item);
                // viewModel.PropertyPhotos.RemoveAt(data);
                //// item = await uploadFile();
                // viewModel.PropertyPhotos.Insert(data, await uploadFile());

            }
        }
        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            var grid = (Grid)sender;
            var item = (string)grid.BindingContext;
            var img = (CachedImage)grid.Children.ElementAt(0);
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
                img.Source = ImageSource.FromStream(() => _mediaFile.GetStream());

                var data = viewModel.PropertyPhotosNext.ToList().IndexOf(item);
                viewModel.PropertyPhotosNext.Remove(item);
                item = await uploadFile();
                viewModel.PropertyPhotosNext.Insert(data, item);
            }
        }
        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            col_morePhotos.IsVisible = true;
            frmPhoto.IsVisible = false;
        }

        private async void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            var grid = (Grid)sender;
            var item = (string)grid.BindingContext;
            var img = (CachedImage)grid.Children.ElementAt(0);
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
                img.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                var data = viewModel.PropertyLayouts.IndexOf(item);
                if (data >= 0)
                {
                    viewModel.PropertyLayouts[data] = await uploadFile();
                }
                else
                {
                    viewModel.PropertyLayouts.Add(await uploadFile());
                }
                // var data = viewModel.PropertyPhotos.ToList().IndexOf(item);
                // viewModel.PropertyPhotos.RemoveAt(data);
                //// item = await uploadFile();
                // viewModel.PropertyPhotos.Insert(data, await uploadFile());

            }
        }
        private async void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            var grid = (Grid)sender;
            var item = (string)grid.BindingContext;
            var img = (CachedImage)grid.Children.ElementAt(0);
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
                img.Source = ImageSource.FromStream(() => _mediaFile.GetStream());

                var data = viewModel.PropertyLayoutNext.ToList().IndexOf(item);
                viewModel.PropertyLayoutNext.Remove(item);
                item = await uploadFile();
                viewModel.PropertyLayoutNext.Insert(data, item);
            }
        }
        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            col_moreLayout.IsVisible = true;
            frmLayout.IsVisible = false;
        }
        public async Task<string> uploadFile()
        {
            try
            {
                if (_mediaFile == null)
                {
                    //await Application.Current.MainPage.DisplayAlert("Error", "There was an error when trying to get your image.", "OK");
                    return null;
                }
                else
                {
                    var uri = $"{Constants.ApiURL}/api/Upload/UploadMobile";
                    var content = new MultipartFormDataContent();

                    content.Add(new StreamContent(_mediaFile.GetStream()),
                        "\"file\"",
                        $"\"{_mediaFile.Path}\"");

                    var httpClient = new HttpClient();
                    var httpResponseMessage = await httpClient.PostAsync(uri, content);
                    if (httpResponseMessage.IsSuccessStatusCode == true)
                    {
                        return Path.GetFileName(_mediaFile.Path);
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            //if (!IsValidPhotos())
            //{
            //    return;
            //}

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
            //if (!IsValidLayout())
            //{
            //    return;
            //}
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
        private async void TapGestureRecognizer_Tapped_14(object sender, EventArgs e)
        {
            var model = ((CachedImage)sender).BindingContext as AdvertisementModel;
            viewModel.AdId = model.Id;
            var data = await waitForDeletePopup();
            if (data == true)
            {
                viewModel.OpenDeleteAddCommand.Execute(true);
            }
        }

        private async Task<bool> waitForDeletePopup()
        {
            var tcs = new TaskCompletionSource<bool>();
            await PopupNavigation.Instance.PushAsync(new DeleteProjectPopUp(tcs));
            return await tcs.Task;
        }
    }
}