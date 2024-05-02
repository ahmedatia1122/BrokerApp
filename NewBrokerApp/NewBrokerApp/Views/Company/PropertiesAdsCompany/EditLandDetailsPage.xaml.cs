using DevExpress.XamarinForms.Editors;
using FFImageLoading.Forms;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Common;
using NewBrokerApp.Views.Popup;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Company.PropertiesAdsCompany
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditLandDetailsPage : ContentPage
    {
        PropertyViewModel viewModel;
        MediaFile _mediaFile;
        public int PropertyType;
        public bool ShowAddrssMap { get; set; } = false;
        public EditLandDetailsPage()
        {
            InitializeComponent();
            var propertyType = Constants.AdvertisementParamter as Advertisement;
            PropertyType = Convert.ToInt32(propertyType.TypeId);
            BindingContext = viewModel = new PropertyViewModel();
            lblTitle.Text = AppResources.Edit + " " + propertyType.Type;
            viewModel.Type = 1;
            datePickerDelivery.MinimumDate = DateTime.Now;
            Device.BeginInvokeOnMainThread(async () =>
            {
                viewModel.LoadPropertyPersonTitleCommand.Execute(true);
                viewModel.LoadPropertyPersonTypeCommand.Execute(true);
                viewModel.LoadPropertyStatusTypeForLandCommand.Execute(true);
                viewModel.LoadPropertyUsingForLandCommand.Execute(true);
                viewModel.LoadPropertyNumbersCommand.Execute(true);
                viewModel.LoadPropertyGovernmentsCommand.Execute(true);
                viewModel.LoadPropertyCitiesCommand.Execute(true);

                viewModel.LoadPropertyStatusCommand.Execute(true);
                viewModel.LoadPropertyDocumentCommand.Execute(true);
                viewModel.LoadPropertyFinishedCommand.Execute(true);
                viewModel.LoadPropertyPriceCommand.Execute(true);
                viewModel.ChoosePropertyFacilitiesCommand.Execute(true);
                viewModel.AdvertiseForEditCommand.Execute(true);

            });
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (!IsValidPropertyBasic())
            {
                return;
            }
            viewModel.SelectGovernment = viewModel.Governments.Where(x => x.Id == viewModel.AdvertisementModel.GovernorateId).FirstOrDefault();
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = true;
                            viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
            stkDetailsLand.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;

        }
        private bool IsValidPropertyBasic()
        {
            if (viewModel.AdvertisementModel.AgreementStatus == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.choosepropertyagreementstatus, AppResources.ok);
                return false;
            }
            if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title))
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterpropertytitle, AppResources.ok);

                return false;
            }

            return true;


        }
        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
           
            if (!IsValidPropertyAddress())
            {
                return;
            }
            viewModel.AdvertisementModel.GovernorateId = viewModel.SelectGovernment.Id;
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
            stkDetailsLand.IsVisible = true;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }
        private  bool IsValidPropertyAddress()
        {
            if (viewModel.SelectGovernment == null)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.chooseGovernment, AppResources.ok);

                return false;
            }
            //if (viewModel.SelectCity == null)
            //{
            //    App.Current.MainPage.DisplayAlert("", AppResources.chooseCity, AppResources.ok);

            //    return false;
            //}
            if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Compound))
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterCompound, AppResources.ok);
                return false;
            }
            if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Street))
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterStreet, AppResources.ok);
                return false;
            }
            if (string.IsNullOrEmpty(viewModel.AdvertisementModel.BuildingNumber))
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterBuildingNumber, AppResources.ok);
                return false;
            }
            if (ShowAddrssMap == false)
            {
                getForAddress();
                return false;
            }
            return true;


        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            
            if (!IsValidPropertyDetails())
            {
                return;
            }
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 4).FirstOrDefault();
            stkDetailsLand.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }
        private bool IsValidPropertyDetails()
        {
                
                    if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Area))
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterLandArea, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.FloorsNumber==null)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyFloorsNumber, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.BuildingStatus == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyBuildingStatus, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.Decoration == null)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyFinishing, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.Rooms == null)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyRooms, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.Reception == null)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyReceptions, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.Dinning == null)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyDinnings, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.Balcony == null)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyBalcony, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.Kitchen == null)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyKitchen, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.Toilet == null)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyToilet, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.Document == null || viewModel.AdvertisementModel.Document == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyDocument, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyFacilites, AppResources.ok);
                        return false;
                    }
                  
                
            
            return true;

        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (!IsValidPropertyPhotos())
            {
                return;
            }
            if (viewModel.AdvertisementModel.AgreementStatus == 2)
            {
                viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
                stkPaymentFacilities.IsVisible = true;
                stkInstallment.IsVisible = false;
            }
            else
            {
                stkPaymentFacilities.IsVisible = false;
                stkInstallment.IsVisible = true;
            }
            stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 5).FirstOrDefault();
                stkDetailsLand.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = true;
                stkContactInformation.IsVisible = false;
           
           

        }
        private bool IsValidPropertyPhotos()
        {

            if (viewModel.AdvertisementModel.PhotosList.Count == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.pleaseUploadAtleatestonePhoto, AppResources.ok);

                return false;
            }
            if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Description))
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyDescription, AppResources.ok);
                return false;
            }
           
            return true;


        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            if (Constants.NavigationProject != null || viewModel.AdvertisementModel.ProjectId != null)
            {
                framPuplish.IsVisible = false;
                framSaveProj.IsVisible = true;
                framPuplishProj.IsVisible = true;
            }
            else
            {
                framPuplish.IsVisible = true;
                framPuplishProj.IsVisible = false;
                framSaveProj.IsVisible = false;
            }
            if (!IsValidPropertyPricing())
            {
                return;
            }
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 6).FirstOrDefault();
                stkDetailsLand.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                stkContactInformation.IsVisible = true;
            
           
        }
        private bool IsValidPropertyPricing()
        {
            if (viewModel.AdvertisementModel.AgreementStatus == 2)
            {
                if (viewModel.AdvertisementModel.Price == 0)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterPropertyPrice, AppResources.ok);

                    return false;
                }
                if (viewModel.AdvertisementModel.Rent == null)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.enterPaymentFacility, AppResources.ok);
                    return false;
                }
            }
            else
            {
                if (viewModel.AdvertisementModel.Price == 0)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterPropertyPrice, AppResources.ok);

                    return false;
                }
                if (viewModel.AdvertisementModel.DownPayment == null)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterPropertyDownPayment, AppResources.ok);

                    return false;
                }
                if (viewModel.AdvertisementModel.DeliveryDate == null)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterPropertyDeliveryDate, AppResources.ok);

                    return false;
                }
                if (viewModel.AdvertisementModel.MonthlyInstallment == null)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterMonthlyInstallment, AppResources.ok);

                    return false;
                }
                if (viewModel.AdvertisementModel.YearlyInstallment == null)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterYearlyInstallment, AppResources.ok);

                    return false;
                }
                if (viewModel.AdvertisementModel.NumOfYears == null)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterNumOfYears, AppResources.ok);

                    return false;
                }

            }
            return true;
        }
        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new AddsPage());
        }
        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            stkBasic.IsVisible = true;
            StkAddress.IsVisible = false;
            viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 1).FirstOrDefault();
            stkDetailsLand.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = true;
             viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
            stkDetailsLand.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_12(object sender, EventArgs e)
        {
            viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            stkDetailsLand.IsVisible = true;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_13(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 4).FirstOrDefault();
            stkDetailsLand.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_14(object sender, EventArgs e)
        {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 5).FirstOrDefault();
                stkDetailsLand.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = true;
                stkContactInformation.IsVisible = false;
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.AgreementStatus = data.Id;
            }
            catch (Exception ex)
            { }
      
        }

        private void CheckBox_CheckedChanged_2(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                //var cb = (CheckBox)sender;
                //var item = (DefinitionModel)cb.BindingContext;
                //if (e.Value == true)
                //{
                //    viewModel.AdvertisementModel.FacilitesApi.Add(item.Id);
                //}
                //else
                //{
                //    viewModel.AdvertisementModel.FacilitesApi.Remove(item.Id);
                //}

            }
            catch (Exception ex)
            {

            }
        }
        private void CollectionView_SelectionChanged_9(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.Document = data.Id;
            }
            catch (Exception ex)
            { }
    
        }

        private void CollectionView_SelectionChanged_10(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                if (viewModel.AdvertisementModel.AgreementStatus == 1)
                {
                    viewModel.AdvertisementModel.PaymentFacility = data.Id;
                }
                else
                {
                    viewModel.AdvertisementModel.Rent = data.Id;
                }
            }
            catch (Exception ex)
            { }



        }

        public async Task<string> uploadFile()
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
        private void CheckBox_CheckedChanged_3(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                viewModel.AdvertisementModel.ContactRegisterInTheAccount = e.Value;
            }
            catch (Exception ex)
            { }

         
        }
        private void CollectionView_SelectionChanged_18(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.LandingStatus = data.Id;
            }
            catch (Exception ex)
            { }
          
        }
        private void CollectionView_SelectionChanged_19(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.UsingFor = data.Id;
            }
            catch (Exception ex)
            { }
   
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            try
            {
                viewModel.AdvertisementModel.IsWhatsApped = e.Value;
            }
            catch (Exception ex)
            { }
            
        }
        private async void TapGestureRecognizer_Tapped_19(object sender, EventArgs e)
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
        private void TapGestureRecognizer_Tapped_20(object sender, EventArgs e)
        {
            try
            {
                col_morePhotos.IsVisible = true;
                frmPhoto.IsVisible = false;
            }
            catch (Exception ex)
            { }
         
        }

        private async void TapGestureRecognizer_Tapped_25(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(secondMobileNumber.Text))
            {
                await App.Current.MainPage.DisplayAlert("", AppResources.InvalidPhone, AppResources.ok);

            }
            else if (!string.IsNullOrEmpty(secondMobileNumber.Text) && (secondMobileNumber.Text.Length != 11 || !secondMobileNumber.Text.StartsWith("01")))
            {
                await App.Current.MainPage.DisplayAlert("", AppResources.phoneNumberformat, AppResources.ok);


            }
            else
            {
                Constants.UserMobileNumber = viewModel.AdvertisementModel.SecondMobileNumber;
             //   Constants.UserVerifyCode = GetVerifyCode();
                //viewModel.CheckPhoneNumberOtpCommand.Execute(true);
                await Shell.Current.Navigation.PushAsync(new Views.Popup.MobileContactVerifyPage());

                //var data = await waitForVerifyCode();

            }

        }
        public string GetVerifyCode()
        {
            return "1234";
        }
        private async Task<bool> waitForVerifyCode()
        {
            var tcs = new TaskCompletionSource<bool>();
           // await PopupNavigation.Instance.PushAsync(new MobileContactVerifyPage(tcs));
            //await Navigation.PushPopupAsync(new CityPage(tcs));
            return await tcs.Task;
        }
        private async void TapGestureRecognizer_Tapped_26(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }
        private async Task<AdvertisementModel> waitForAddress()
        {
            var tcs = new TaskCompletionSource<AdvertisementModel>();
            await PopupNavigation.Instance.PushAsync(new GetAddress(viewModel.AdvertisementModel, tcs));
            //await Navigation.PushPopupAsync(new CityPage(tcs));
            return await tcs.Task;
        }
        private async void TapGestureRecognizer_Tapped_27(object sender, EventArgs e)
        {
            var data = await waitForAddress();
            //  await PopupNavigation.Instance.PushAsync(new CityPage());
            viewModel.AdvertisementModel.Latitude = data.Latitude;
            viewModel.AdvertisementModel.Longitude = data.Longitude;
        }
        private async void getForAddress()
        {
            var tcs = new TaskCompletionSource<AdvertisementModel>();
            await PopupNavigation.Instance.PushAsync(new GetAddress(viewModel.AdvertisementModel, tcs));
            //await Navigation.PushPopupAsync(new CityPage(tcs));
            var data = await tcs.Task;
            if (string.IsNullOrEmpty(data.Latitude) || string.IsNullOrEmpty(data.Longitude))
            {
                ShowAddrssMap = false;
            }
            else
            {
                ShowAddrssMap = true;
            }
            viewModel.AdvertisementModel.Latitude = data.Latitude;
            viewModel.AdvertisementModel.Longitude = data.Longitude;
        }
        private void BorderlessEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get the current text from the Entry control
            var text = e.NewTextValue;

          String[] map = { "٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" };

            for (int i = 0; i <= 9; i++)
            {
                text = text.Replace(map[i], i.ToString());
            }

            // Set the converted text back to the Entry control
            ((Entry)sender).Text = text;
        }

        private void BorderlessEntry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // Get the current text from the Entry control
            var text = e.NewTextValue;

            String[] map = { "٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" };

            for (int i = 0; i <= 9; i++)
            {
                text = text.Replace(map[i], i.ToString());
            }

            // Set the converted text back to the Entry control
            ((Entry)sender).Text = text;
        }

        private void BorderlessEntry_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            // Get the current text from the Entry control
            var text = e.NewTextValue;

            String[] map = { "٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" };

            for (int i = 0; i <= 9; i++)
            {
                text = text.Replace(map[i], i.ToString());
            }

            // Set the converted text back to the Entry control
            ((Entry)sender).Text = text;
        }

        private void BorderlessEntry_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            // Get the current text from the Entry control
            var text = e.NewTextValue;

            String[] map = { "٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" };

            for (int i = 0; i <= 9; i++)
            {
                text = text.Replace(map[i], i.ToString());
            }

            // Set the converted text back to the Entry control
            ((Entry)sender).Text = text;
        }
        private async void TapGestureRecognizer_Tapped_28(object sender, EventArgs e)
        {
            if(stkBasic.IsVisible == true)
            {
                await Shell.Current.Navigation.PopAsync();
            }
            else if (StkAddress.IsVisible==true)
            {
                stkBasic.IsVisible = true;
                StkAddress.IsVisible = false;
                viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 1).FirstOrDefault();
                stkDetailsLand.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (stkDetailsLand.IsVisible ==true)
            {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                
            }
           
            else if (stkPhoto.IsVisible == true)
            {

                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                               viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
                               stkDetailsLand.IsVisible = true;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = false;
                       stkContactInformation.IsVisible = false;
            }
            else if (stkPrice.IsVisible == true)
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                               viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 4).FirstOrDefault();
                stkDetailsLand.IsVisible = false;
                stkPhoto.IsVisible = true;
                stkPrice.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (stkContactInformation.IsVisible == true)
            {
                stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        stkDetailsLand.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = true;
                       stkContactInformation.IsVisible = false;
            }
        }

        private void ComboBoxEdit_SelectionChanged_1(object sender, EventArgs e)
        {
            //var data = (e.CurrentSelection.FirstOrDefault() as PropertyModel);
            var cb = (ComboBoxEdit)sender;
            var data = (PropertyModel)cb.SelectedItem;
            if (data.Id == 1)
            {
                stkBasic.IsVisible = true;
                StkAddress.IsVisible = false;
                viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 1).FirstOrDefault();
                stkDetailsLand.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (data.Id == 2)
            {
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }

            }
            else if (data.Id == 3)
            {
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    stkDetailsLand.IsVisible = true;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }

            }
            else if (data.Id == 4)
            {
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    stkDetailsLand.IsVisible = true;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }

            }
            else if (data.Id == 5)
            {
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    stkDetailsLand.IsVisible = true;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.PhotosList.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    if (viewModel.AdvertisementModel.AgreementStatus == 2)
                    {
                        viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
                        stkPaymentFacilities.IsVisible = true;
                        stkInstallment.IsVisible = false;
                    }
                    else
                    {
                        stkPaymentFacilities.IsVisible = false;
                        stkInstallment.IsVisible = true;
                    }
                    stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        stkDetailsLand.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = true;
                        stkContactInformation.IsVisible = false;
                }

            }
            else if (data.Id == 6)
            {
                if (Constants.NavigationProject != null || viewModel.AdvertisementModel.ProjectId != null)
                {
                    framPuplish.IsVisible = false;
                    framSaveProj.IsVisible = true;
                    framPuplishProj.IsVisible = true;
                }
                else
                {
                    framPuplish.IsVisible = true;
                    framPuplishProj.IsVisible = false;
                    framSaveProj.IsVisible = false;
                }
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
                            stkDetailsLand.IsVisible = true;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.PhotosList.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.Price == 0)
                {
                    if (viewModel.AdvertisementModel.AgreementStatus == 2)
                    {
                        viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
                        stkPaymentFacilities.IsVisible = true;
                        stkInstallment.IsVisible = false;
                    }
                    else
                    {
                        stkPaymentFacilities.IsVisible = false;
                        stkInstallment.IsVisible = true;
                    }
                    stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        stkDetailsLand.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = true;
                        stkContactInformation.IsVisible = false;
                   
                   
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 6).FirstOrDefault();
                    stkDetailsLand.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = true;
                }

            }
        }

        private void CustomEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = e.NewTextValue;

            String[] map = { "٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" };

            for (int i = 0; i <= 9; i++)
            {
                text = text.Replace(map[i], i.ToString());
            }

            // Set the converted text back to the Entry control
            ((CustomEditor)sender).Text = text;
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
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

                var data = viewModel.PropertyLayouts.ToList().IndexOf(item);
                viewModel.PropertyLayouts.Remove(item);
                item = await uploadFile();
                viewModel.PropertyLayouts.Insert(data, item);

            }
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
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
    }
}