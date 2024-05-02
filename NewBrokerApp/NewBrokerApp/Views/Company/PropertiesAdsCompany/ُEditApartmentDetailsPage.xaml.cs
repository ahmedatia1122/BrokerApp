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
using CheckBox = Xamarin.Forms.CheckBox;

namespace NewBrokerApp.Views.Company.PropertiesAdsCompany
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditApartmentDetailsPage : ContentPage
    {
        PropertyViewModel viewModel;
        MediaFile _mediaFile;
        MediaFile _mediaFile2;
        MediaFile _mediaFile3;
        MediaFile _mediaFile4;
        MediaFile _mediaFile5;
        MediaFile _mediaFile6;
        public int PropertyType;
        public bool ShowAddrssMap { get; set; } = false;
        public EditApartmentDetailsPage()
        {
            InitializeComponent();
            var propertyType = Constants.AdvertisementParamter as Advertisement;
            PropertyType = Convert.ToInt32(propertyType.TypeId);
            BindingContext = viewModel = new PropertyViewModel();
            lblTitle.Text = AppResources.Edit + " " + propertyType.Type;
            BindingContext = viewModel = new PropertyViewModel();
            viewModel.Type = 1;
            datePickerDelivery.MinimumDate = DateTime.Now;
            Device.BeginInvokeOnMainThread(async () =>
            {
                viewModel.LoadPropertyStatusCommand.Execute(true);
                viewModel.LoadPropertyPriceCommand.Execute(true);
                viewModel.LoadPropertyNumbersCommand.Execute(true);
                viewModel.LoadPropertyPersonTitleCommand.Execute(true);
                viewModel.LoadPropertyPersonTypeCommand.Execute(true);
                viewModel.LoadPropertyGovernmentsCommand.Execute(true);
                viewModel.LoadPropertyCitiesCommand.Execute(true);
                viewModel.LoadPropertyDocumentCommand.Execute(true);
                viewModel.LoadPropertyFinishedCommand.Execute(true);
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
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;

        }
        private bool IsValidPropertyBasic()
        {
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
            stkDetails.IsVisible = true;
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
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }
        private bool IsValidPropertyDetails()
        {
                
                    if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Area))
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterApartmentArea, AppResources.ok);
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
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 5).FirstOrDefault();
                stkDetails.IsVisible = false;
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
                stkDetails.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                stkContactInformation.IsVisible = true;
        }
        private bool IsValidPropertyPricing()
        {
         
                if (viewModel.AdvertisementModel.Price == 0)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterPropertyPrice, AppResources.ok);

                    return false;
                }
                return true;

        }
        private async void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            if(Constants.NavigationProject != null)
            {
                await Shell.Current.Navigation.PopAsync();
            }
            else
            {
                Shell.Current.Navigation.PushAsync(new AddsPage());
            }
        }
        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            stkBasic.IsVisible = true;
            StkAddress.IsVisible = false;
            viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 1).FirstOrDefault();
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = true;
             viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
            stkDetails.IsVisible = false;
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
            stkDetails.IsVisible = true;
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
            stkDetails.IsVisible = false;
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
                stkDetails.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = true;
                stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_15(object sender, EventArgs e)
        {
            if (!IsValidPropertyAdvertise())
            {
                return;
            }
            viewModel.AdvertisementModel.MrMrs = viewModel.SelectedTitle.Id;
            viewModel.AdvertisementModel.AdvertiseMaker = viewModel.SelectedPersonType.Id;
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
             viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 7).FirstOrDefault();
            stkDetails.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkContactInformation.IsVisible = true;
        }
        private bool IsValidPropertyAdvertise()
        {
            if (viewModel.SelectedTitle == null)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.pleaseChooseAdvertiserTitle, AppResources.ok);
                return false;
            }
            if (viewModel.SelectedPersonType == null)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.pleaseChooseAdvertiserMaker, AppResources.ok);

                return false;
            }
            if (string.IsNullOrEmpty(viewModel.AdvertisementModel.AdvertiseMakerName))
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterAdvertiseMakerName, AppResources.ok);
                return false;
            }
            
            return true;


        }


        private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.BuildingStatus = data.Id;
            }
            catch (Exception ex)
            {

            }
        }

        private void CollectionView_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.Decoration = data.Id;
            }
            catch (Exception ex)
            {

            }
        }
            private void CollectionView_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.Rooms = data.Id;
            }
            catch (Exception ex)
            { }

        }

    private void CollectionView_SelectionChanged_4(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.Reception = data.Id;
            }
            catch (Exception ex)
            { }
        }

        private void CollectionView_SelectionChanged_5(object sender, SelectionChangedEventArgs e)
        {
                try
                {
                    var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                    viewModel.AdvertisementModel.Dinning = data.Id;
                }
                catch (Exception ex)
                { }
}

        private void CollectionView_SelectionChanged_6(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.Balcony = data.Id;
            }
            catch (Exception ex)
            { }
}

        private void CollectionView_SelectionChanged_7(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.Kitchen = data.Id;
            }
            catch (Exception ex)
            { }
        }

        private void CollectionView_SelectionChanged_8(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.Toilet = data.Id;
            }
            catch (Exception ex)
            { }
        }

        private void FunishedCheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                viewModel.AdvertisementModel.Furnished = e.Value;
            }
            catch (Exception ex)
            { }
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
           
            try
            {
                viewModel.AdvertisementModel.Elevator = e.Value;
            }
            catch (Exception ex)
            { }
        }

        private void CheckBox_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                viewModel.AdvertisementModel.Garden = e.Value;
                entryGardenArea.IsEnabled = e.Value == true ? true : false;
            }
            catch (Exception ex)
            { }
        
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

        private void CheckBox_CheckedChanged_2(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                var cb = (CheckBox)sender;
                var item = (DefinitionModel)cb.BindingContext;
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
        private void CheckBox_CheckedChanged_5(object sender, CheckedChangedEventArgs e)
        {
            viewModel.AdvertisementModel.Parking = e.Value;
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

        private async void TapGestureRecognizer_Tapped_17(object sender, EventArgs e)
        {

        
        var data = await waitForChoosePersonTitle();
            //  await PopupNavigation.Instance.PushAsync(new CityPage());
        //    txtitle.Text = data.Name;
            viewModel.AdvertisementModel.MrMrs = data.Id;
        }
    private async Task<DefinitionModel> waitForChoosePersonTitle()
    {
        var tcs = new TaskCompletionSource<DefinitionModel>();
        await PopupNavigation.Instance.PushAsync(new TitlePage(tcs));
        //await Navigation.PushPopupAsync(new CityPage(tcs));
        return await tcs.Task;
    }

        private async void TapGestureRecognizer_Tapped_18(object sender, EventArgs e)
        {
            var data = await waitForChoosePersonType();
            //  await PopupNavigation.Instance.PushAsync(new CityPage());
           // txtownerOrBroker.Text = data.Name;
            viewModel.AdvertisementModel.AdvertiseMaker = data.Id;
        }
        private async Task<DefinitionModel> waitForChoosePersonType()
        {
            var tcs = new TaskCompletionSource<DefinitionModel>();
            await PopupNavigation.Instance.PushAsync(new PersonTypePage(tcs));
            //await Navigation.PushPopupAsync(new CityPage(tcs));
            return await tcs.Task;
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

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            try
            {
                viewModel.AdvertisementModel.IsWhatsApped = e.Value;
            }
            catch (Exception ex)
            { }
           
        }


        private void CheckBox_CheckedChanged_6(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                viewModel.AdvertisementModel.AirConditioner = e.Value;
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
              //  Constants.UserVerifyCode = GetVerifyCode();
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
            if (Constants.NavigationProject != null)
            {
                if (stkBasic.IsVisible == true)
                {
                    await Shell.Current.Navigation.PopAsync();
                }
                else if (StkAddress.IsVisible == true)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (stkDetails.IsVisible == true)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;

                }

                else if (stkPhoto.IsVisible == true)
                {

                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    stkDetails.IsVisible = true;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (stkPrice.IsVisible == true)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (stkContactInformation.IsVisible == true)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 5).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = true;
                    stkContactInformation.IsVisible = false;
                }
        }
            else
            {
                if (stkBasic.IsVisible == true)
                {
                    await Shell.Current.Navigation.PopAsync();
                }
                else if (StkAddress.IsVisible == true)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (stkDetails.IsVisible == true)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;

                }

                else if (stkPhoto.IsVisible == true)
                {

                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    stkDetails.IsVisible = true;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (stkPrice.IsVisible == true)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (stkContactInformation.IsVisible == true)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 5).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = true;
                    stkContactInformation.IsVisible = false;
                }
            }
           
        }
        private async void TapGestureRecognizer_Tapped_29(object sender, EventArgs e)
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

                var data = viewModel.PropertyPhotos.ToList().IndexOf(item);
                viewModel.PropertyPhotos.Remove(item);
                item = await uploadFile();
                viewModel.PropertyPhotos.Insert(data, item);

            }
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
            col_morePhotos.IsVisible = true;
            frmPhoto.IsVisible = false;
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
                stkDetails.IsVisible = false;
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
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetails.IsVisible = false;
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
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    stkDetails.IsVisible = true;
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
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    stkDetails.IsVisible = true;
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
                    stkDetails.IsVisible = false;
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
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    stkDetails.IsVisible = true;
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
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        stkDetails.IsVisible = false;
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
                    stkDetails.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 3).FirstOrDefault();
                            stkDetails.IsVisible = true;
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
                    stkDetails.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.Price == 0)
                {
                   
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedPropertyName = viewModel.PropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        stkDetails.IsVisible = false;
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
                    stkDetails.IsVisible = false;
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