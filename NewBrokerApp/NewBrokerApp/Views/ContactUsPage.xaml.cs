using Acr.UserDialogs;
using NewBrokerApp.Models;
using NewBrokerApp.ViewModels;
using Plugin.Media.Abstractions;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms.Xaml;


namespace NewBrokerApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactUsPage : ContentPage
	{
        ContactUsViewModel viewModel = new ContactUsViewModel();
        MediaFile _mediaFile;
        public ContactUsPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel;
            viewModel.LoadSocialMediaCommand.Execute(this);
            viewModel.LoadContactusUsWhatsAppCommand.Execute(this);
        }
        private async void TapGestureRecognizer_Tapped_FileUpload(object sender, EventArgs e)
        {
            try
            {
                 
                var resultList = await FilePicker.PickMultipleAsync();

                if (resultList != null)
                {
                    foreach (var result in resultList)
                    {

                        var stream = await result.OpenReadAsync();
                        byte[] data;
                        using (var br = new BinaryReader(stream))
                            data = br.ReadBytes((int)stream.Length);


                        ByteArrayContent bytes = new ByteArrayContent(data);

                        var multi = new MultipartFormDataContent();
                        multi.Add(bytes, "file", result.FileName);
                        viewModel.ContactUsItem.Attachment = result.FileName;
                        fileUpload.Text = viewModel.ContactUsItem.Attachment;
                        //var resualt = await _sevicesequestForQuotation.AsyncUpload(multi);
                        //if (!resualt.success)
                        //{
                        //    fileName = new StackLayout();
                        //    Toast.ShowError(strings.get("fileNotUploaded"));
                        //}
                        //else
                        //{
                        //    viewModel.ContactUsItem.Add(new Models.ContactUsInput()
                        //    {
                        //        id = resualt.pictureId,
                        //        deleted = false,
                        //    });
                        //    //  viewModel.FillUploud = resualt.pictureId;
                        //    fileName.Children.Add(new Label()
                        //    {
                        //        TextColor = Color.Black,
                        //        FontSize = 16,
                        //        Text = result.FileName
                        //    });
                        //}
                    }
                }
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                // The user canceled or something went wrong
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {

                var resultList = await FilePicker.PickMultipleAsync();

                if (resultList != null)
                {
                    foreach (var result in resultList)
                    {

                        var stream = await result.OpenReadAsync();
                        byte[] data;
                        using (var br = new BinaryReader(stream))
                            data = br.ReadBytes((int)stream.Length);


                        ByteArrayContent bytes = new ByteArrayContent(data);

                        var multi = new MultipartFormDataContent();
                        multi.Add(bytes, "file", result.FileName);
                        viewModel.ContactUsItem.Attachment = result.FileName;
                        fileUpload.Text = viewModel.ContactUsItem.Attachment;
                        //var resualt = await _sevicesequestForQuotation.AsyncUpload(multi);
                        //if (!resualt.success)
                        //{
                        //    fileName = new StackLayout();
                        //    Toast.ShowError(strings.get("fileNotUploaded"));
                        //}
                        //else
                        //{
                        //    viewModel.ContactUsItem.Add(new Models.ContactUsInput()
                        //    {
                        //        id = resualt.pictureId,
                        //        deleted = false,
                        //    });
                        //    //  viewModel.FillUploud = resualt.pictureId;
                        //    fileName.Children.Add(new Label()
                        //    {
                        //        TextColor = Color.Black,
                        //        FontSize = 16,
                        //        Text = result.FileName
                        //    });
                        //}
                    }
                }
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                // The user canceled or something went wrong
            }

        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var data= e.CurrentSelection.FirstOrDefault() as SocialMediaModel;
                await Browser.OpenAsync(data.SocialValue, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {
                Chat.Open("+2" + viewModel.WhatsAppNumber, "");
            }
            catch
            {

            }
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            try { 
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "This is not support on your device.", "OK");
                return ;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                    // if (_mediaFile == null) return ;
                    fileUpload.Text= Path.GetFileName(_mediaFile.Path);
                    viewModel.Attachment = Path.GetFileName(_mediaFile.Path);
                //imgAvatarCompany.Source = ImageSource.FromStream(() => _mediaFile.GetStream());

            }
          //  return viewModel.Attachment;
        }
            catch (Exception ex)
            {
           //     UserDialogs.Instance.HideLoading();

                return ;
                // The user canceled or something went wrong
            }
            

        }
    }
}