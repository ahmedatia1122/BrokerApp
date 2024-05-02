using Acr.UserDialogs;

using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace NewBrokerApp.ViewModels
{
    public class ContactUsViewModel : BaseViewModel
    {
        public Command LoadContactUsAddsCommand { get; }
        public Command LoadAttachmentCommand { get; }
        public Command LoadSocialMediaCommand { get; }
        public Command LoadContactusUsWhatsAppCommand { get; }
        public ObservableCollection<SocialMediaModel> _socialmedia;
        public ObservableCollection<SocialMediaModel> SocialMedia
        {
            get { return _socialmedia; }
            set { SetProperty(ref _socialmedia, value); }
        }
        private ContactUsInput _contactUsItem;
        public ContactUsInput ContactUsItem
        {
            get
            {
                return _contactUsItem;
            }
            set => SetProperty(ref _contactUsItem, value);

        }
        private string _attachmentItem;
        public string Attachment
        {
            get
            {
                return _attachmentItem;
            }
            set => SetProperty(ref _attachmentItem, value);

        }
        private string _whatsAppNumber;
        public string WhatsAppNumber
        {
            get
            {
                return _whatsAppNumber;
            }
            set => SetProperty(ref _whatsAppNumber, value);

        }
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        MultipartFormDataContent multi;
        MediaFile _mediaFile;
        public ContactUsViewModel()
        {
            
            SocialMedia = new ObservableCollection<SocialMediaModel>();
            LoadContactUsAddsCommand = new Command(async () => { await ExecuteCreateContanctUsCommand(); });
            LoadAttachmentCommand = new Command(async () => { await ExecuteAttachmentCommand(); });
            ContactUsItem = new ContactUsInput();
            LoadSocialMediaCommand = new Command(async () => { await ExecuteAllSocialListCommand(); });
            LoadContactusUsWhatsAppCommand = new Command(async () => { await ExecuteContactUsWhatsAppCommand(); });

            
        }
        public async Task<string> uploadFile(MultipartFormDataContent content)
        {

            if (content == null)
            {
                //await Application.Current.MainPage.DisplayAlert("Error", "There was an error when trying to get your image.", "OK");
                return null;
            }
            else
            {
                var uri = $"{Constants.ApiURL}/api/Upload/UploadMobile";
           //     var content = new MultipartFormDataContent();

                //content.Add(new StreamContent(_mediaFile.GetStream()),
                //    "\"file\"",
                //    $"\"{_mediaFile.Path}\"");

                var httpClient = new HttpClient();
                var httpResponseMessage = await httpClient.PostAsync(uri, content);
                if (httpResponseMessage.IsSuccessStatusCode == true)
                {
                   return "sucess";
                }
                else
                {
                    return null;
                }

            }
        }
        private async Task ExecuteCreateContanctUsCommand()
        {

            try
            {
              
                if (string.IsNullOrEmpty(ContactUsItem.Email)||!IsValidEmail(ContactUsItem.Email.Trim()))
                {
                    ShowMessege(AppResources.Alert, AppResources.EmailNotValid);
                }
              else  if (string.IsNullOrEmpty(ContactUsItem.Subject))
                {
                    ShowMessege(AppResources.Alert, AppResources.enterSubject);
                }
                else
                {
                    if (multi != null)
                    {
                        if (await uploadFile(multi) == "sucess")
                        {
                            ContactUsItem.Attachment = Attachment;
                        }
                    }
                  
                    var res = await WebService.CreateContanctUs(ContactUsItem);
                    if (!res.Success)
                        ShowMessege(AppResources.Alert, res?.Error);
                    else if (res?.Result?.Success != true)
                    {
                        ShowMessege(AppResources.Alert, res?.Result?.Error);
                    }
                    else if (res?.Result?.Success == true)
                    {
                        ShowMessege(AppResources.Alert, AppResources.Emailhasbeensent);
                        Application.Current.MainPage = new AppShell();
                    }
                }
               





            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }
        public async Task<string> ExecuteAttachmentCommand()
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "This is not support on your device.", "OK");
                    return null;
                }
                else
                {
                    var mediaOption = new PickMediaOptions()
                    {
                        PhotoSize = PhotoSize.Medium
                    };
                    _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                    // if (_mediaFile == null) return ;
                   // fileUpload.Text = Path.GetFileName(_mediaFile.Path);
                    Attachment = Path.GetFileName(_mediaFile.Path);
                    //imgAvatarCompany.Source = ImageSource.FromStream(() => _mediaFile.GetStream());

                }
                return Attachment;
                //  return viewModel.Attachment;
            }
            catch (Exception ex)
            {
                //     UserDialogs.Instance.HideLoading();

                return null;
                // The user canceled or something went wrong
            }
            //try
            //{
            //    UserDialogs.Instance.ShowLoading();
            //    var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            //    if (status != PermissionStatus.Granted)
            //    {
            //        status = await Permissions.RequestAsync<Permissions.StorageRead>();
            //        if (status != PermissionStatus.Granted)
            //        {
            //            // permission denied, handle accordingly
            //            return null;
            //        }
            //    }
            //    var resultList = await FilePicker.PickMultipleAsync();

            //    if (resultList != null)
            //    {
            //        foreach (var result in resultList)
            //        {

            //            var stream = await result.OpenReadAsync();
            //            byte[] data;
            //            using (var br = new BinaryReader(stream))
            //                data = br.ReadBytes((int)stream.Length);


            //            ByteArrayContent bytes = new ByteArrayContent(data);

            //            multi = new MultipartFormDataContent();
            //            multi.Add(bytes, "file", result.FileName);
            //            Attachment = result.FileName;
            //            //viewModel.ContactUsItem.Attachment = result.FileName;
            //            //fileUpload.Text = viewModel.ContactUsItem.Attachment;
            //            //var resualt = await _sevicesequestForQuotation.AsyncUpload(multi);
            //            //if (!resualt.success)
            //            //{
            //            //    fileName = new StackLayout();
            //            //    Toast.ShowError(strings.get("fileNotUploaded"));
            //            //}
            //            //else
            //            //{
            //            //    viewModel.ContactUsItem.Add(new Models.ContactUsInput()
            //            //    {
            //            //        id = resualt.pictureId,
            //            //        deleted = false,
            //            //    });
            //            //    //  viewModel.FillUploud = resualt.pictureId;
            //            //    fileName.Children.Add(new Label()
            //            //    {
            //            //        TextColor = Color.Black,
            //            //        FontSize = 16,
            //            //        Text = result.FileName
            //            //    });
            //            //}
            //        }
            //    }
            //    return Attachment;

            //}
            //catch (Exception ex)
            //{
            //    UserDialogs.Instance.HideLoading();

            //    return null;
            //    // The user canceled or something went wrong
            //}
            //finally
            //{
            //    UserDialogs.Instance.HideLoading();

            //}

            //   return Attachment;
        }
        private async Task ExecuteAllSocialListCommand()
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                ListLength = 15;
                ItemTreshold = 1;
                if (PageIndex == 0)
                {
                    SocialMedia.Clear();
                }

                var res = await WebService.GetAllSocialMedia();
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    foreach (var item in res.Result.SocialContacts)
                    {

                        SocialMedia.Add(item);
                    }
                }
                if (res.Result.SocialContacts.Count < ListLength)
                {
                    ItemTreshold = -1;
                    return;
                }
                PageIndex++;

            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }


        }
        private async Task ExecuteContactUsWhatsAppCommand()
        {
            try
            {

              
                var res = await WebService.GetDefinitionList(new DefinitionsInputModel { Keyword = "", Type =7, Start = PageIndex * ListLength, Length = ListLength });
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    WhatsAppNumber = res.Result.Definitions[1].Name;
                }
               
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
