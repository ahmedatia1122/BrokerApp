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

namespace NewBrokerApp.Views.PropertiesAds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBuildingDetailsPage : ContentPage
    {
        PropertyViewModel viewModel;
        MediaFile _mediaFile;
        public int PropertyType;
        public bool ShowAddrssMap { get; set; } = false;
        public int IsCheckedAlert;
        public EditBuildingDetailsPage()
        {
            InitializeComponent();
            var propertyType = Constants.AdvertisementParamter as Advertisement;
            PropertyType = Convert.ToInt32(propertyType.TypeId);
            BindingContext = viewModel = new PropertyViewModel();
            lblTitle.Text = AppResources.Edit + " " + propertyType.Type;
            viewModel.Type = 1;
            datePickerBuilding.MaximumDate = DateTime.Now;
            Device.BeginInvokeOnMainThread(async () =>
            {
                viewModel.LoadPropertyBuildingPartationsCommand.Execute(true);
                viewModel.LoadPropertyBuildingUnitsCommand.Execute(true);
                viewModel.LoadPropertyBuildingUsingCommand.Execute(true);
                viewModel.LoadPropertyGovernmentsCommand.Execute(true);
                viewModel.LoadPropertyCitiesCommand.Execute(true);
                viewModel.LoadPropertyNumbersCommand.Execute(true);
                viewModel.LoadPropertyStatusCommand.Execute(true);
                viewModel.LoadPropertyPersonTitleCommand.Execute(true);
                viewModel.LoadPropertyPersonTypeCommand.Execute(true);
                viewModel.LoadPropertyPriceCommand.Execute(true);
                viewModel.ChoosePropertyFacilitiesCommand.Execute(true);
                viewModel.LoadPropertyDocumentCommand.Execute(true);
                viewModel.LoadPropertyFinishedCommand.Execute(true);
                viewModel.LoadPropertyPaymentFacilityCommand.Execute(true);
                viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
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
                            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
            StkDetailsBuilding.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
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
            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
            StkDetailsBuilding.IsVisible = true;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
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
            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
            StkDetailsBuilding.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }
        private bool IsValidPropertyDetails()
        {
            if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Area))
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyArea, AppResources.ok);
                return false;
            }
            if (viewModel.AdvertisementModel.FloorsNumber == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyFloorsNumber, AppResources.ok);
                return false;
            }
            if (viewModel.AdvertisementModel.UsingFor == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyUsingFor, AppResources.ok);
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
            if (viewModel.AdvertisementModel.NumUnits == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyNumUnits, AppResources.ok);
                return false;
            }
            if (viewModel.AdvertisementModel.NumPartitions == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyNumPartitions, AppResources.ok);
                return false;
            }
            if (viewModel.AdvertisementModel.Width == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyWidth, AppResources.ok);
                return false;
            }
            if (viewModel.AdvertisementModel.Length == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyLength, AppResources.ok);
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
                if (viewModel.AdvertisementModel.AgreementStatus == 1)
                {
                 Col_Payment.ItemsSource = viewModel.PropertyPaymentFacaility;
                    Col_Payment.IsVisible = true;
                    Col_PaymentRent.IsVisible = false;
                }
                else
                {
                       Col_PaymentRent.ItemsSource = viewModel.PropertyPaymentRentFacaility;
                    Col_Payment.IsVisible = false;
                    Col_PaymentRent.IsVisible = true;

                }
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                StkDetailsBuilding.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = true;
                stkAdvertise.IsVisible = false;
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
            if (!IsValidPropertyPricing())
            {
                return;
            }
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                StkDetailsBuilding.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                stkContactInformation.IsVisible = false;
                stkAdvertise.IsVisible = true;
            
           
        }
        private bool IsValidPropertyPricing()
        {
         
                if (viewModel.AdvertisementModel.Price == 0)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterPropertyPrice, AppResources.ok);

                    return false;
                }
            if (viewModel.AdvertisementModel.AgreementStatus == 1)
            {
                if (viewModel.AdvertisementModel.PaymentFacility == null)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.enterPaymentFacility, AppResources.ok);
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
            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
            StkDetailsBuilding.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = true;
             viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
            StkDetailsBuilding.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_12(object sender, EventArgs e)
        {
            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            StkDetailsBuilding.IsVisible = true;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_13(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
            StkDetailsBuilding.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_14(object sender, EventArgs e)
        {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                StkDetailsBuilding.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = true;
                stkContactInformation.IsVisible = false;
                stkAdvertise.IsVisible = false;
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
             viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 7).FirstOrDefault();
            StkDetailsBuilding.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            stkAdvertise.IsVisible = false;
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

        private void CollectionView_SelectionChanged_11(object sender, SelectionChangedEventArgs e)
        {
            // please check this property
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.UsingFor = data.Id;
            }
            catch (Exception ex)
            { }
           
        }

        private void CollectionView_SelectionChanged_12(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.BuildingStatus = data.Id;
            }
            catch (Exception ex)
            { }
           
        }

        private void CollectionView_SelectionChanged_13(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.Decoration = data.Id;
            }
            catch (Exception ex)
            { }
        
        }

        private void CollectionView_SelectionChanged_14(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.NumUnits = data.Id;
            }
            catch (Exception ex)
            { }
          
        }

        private void CollectionView_SelectionChanged_15(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.NumPartitions = data.Id;
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
                entryGarden.IsEnabled = e.Value == true ? true : false;
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
        private void CollectionView_SelectionChanged_10(object sender, SelectionChangedEventArgs e)
        {
           
            try
            {
                if (Col_Payment.SelectedItem != null)
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

        private async void CheckBox_CheckedChanged_3(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (IsCheckedAlert == 2)
                {
                    myCheckBox1.IsChecked = false;
                    await App.Current.MainPage.DisplayAlert("", AppResources.PleaseChooseOneNumber, AppResources.ok);
                }
                else
                {
                    viewModel.AdvertisementModel.ContactRegisterInTheAccount = e.Value;
                    if (e.Value == true)
                    {
                        showAnotherNumber.IsEnabled = false;
                        IsCheckedAlert = 1;
                    }
                    else
                    {
                        showAnotherNumber.IsEnabled = true;
                        IsCheckedAlert = 0;
                    }
                }
            }
            catch (Exception ex)
            { }

        }

        private async void CheckBox_CheckedChanged_8(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (IsCheckedAlert == 1)
                {
                    myCheckBox2.IsChecked = false;
                    await App.Current.MainPage.DisplayAlert("", AppResources.PleaseChooseOneNumber, AppResources.ok);
                }
                else
                {
                    if (e.Value == true)
                    {
                        showAnotherNumber.IsEnabled = true;
                        IsCheckedAlert = 2;
                    }
                    else
                    {
                        showAnotherNumber.IsEnabled = false;
                        IsCheckedAlert = 0;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CheckBox_CheckedChanged_4(object sender, CheckedChangedEventArgs e)
        {
       
            try
            {
                viewModel.AdvertisementModel.Shop = e.Value;
                buildingshopNo.IsEnabled = e.Value == true ? true : false;
            }
            catch (Exception ex)
            { }
        }
        private void CheckBox_CheckedChanged_5(object sender, CheckedChangedEventArgs e)
        {
           
            try
            {
                viewModel.AdvertisementModel.Parking = e.Value;
                BuildingSpace.IsEnabled = e.Value == true ? true : false;
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
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var mediaOption = new PickMediaOptions()
                    {
                        PhotoSize = PhotoSize.Medium
                    };
                    _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                    if (_mediaFile == null) return;
                    img.Source = ImageSource.FromStream(() => _mediaFile.GetStream());

                    var data = viewModel.PropertyPhotosNext.ToList().IndexOf(item);
                    viewModel.PropertyPhotosNext.RemoveAt(data);
                    viewModel.PropertyPhotosNext.Insert(data, await uploadFile()); 
                });
            }
        }
        private void TapGestureRecognizer_Tapped_20(object sender, EventArgs e)
        {
            col_morePhotos.IsVisible = true;
            frmPhoto.IsVisible = false;
        }

        private async void TapGestureRecognizer_Tapped_25(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(viewModel.AdvertisementModel.SecondMobileNumber))
            {
                await App.Current.MainPage.DisplayAlert("", AppResources.InvalidPhone, AppResources.ok);

            }
            else if (!string.IsNullOrEmpty(viewModel.AdvertisementModel.SecondMobileNumber) && (viewModel.AdvertisementModel.SecondMobileNumber.Length != 11 || !viewModel.AdvertisementModel.SecondMobileNumber.StartsWith("01")))
            {
                await App.Current.MainPage.DisplayAlert("", AppResources.phoneNumberformat, AppResources.ok);


            }
            else
            {
                Constants.UserMobileNumber = viewModel.AdvertisementModel.SecondMobileNumber;
              //  Constants.UserVerifyCode = GetVerifyCode();
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
            await PopupNavigation.Instance.PushAsync(new GetAddress(viewModel.AdvertisementModel,tcs));
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
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                StkDetailsBuilding.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (StkDetailsBuilding.IsVisible ==true)
            {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                
            }
           
            else if (stkPhoto.IsVisible == true)
            {

                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                               viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                               StkDetailsBuilding.IsVisible = true;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = false;
                        stkAdvertise.IsVisible = false;
                       stkContactInformation.IsVisible = false;
            }
            else if (stkPrice.IsVisible == true)
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                               viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                StkDetailsBuilding.IsVisible = false;
                stkPhoto.IsVisible = true;
                stkPrice.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (stkAdvertise.IsVisible==true)
            {
                
                    if (viewModel.AdvertisementModel.AgreementStatus == 1)
                    {
                     Col_Payment.ItemsSource = viewModel.PropertyPaymentFacaility;
                        Col_Payment.IsVisible = true;
                        Col_PaymentRent.IsVisible = false;
                    }
                    else
                    {
                           Col_PaymentRent.ItemsSource = viewModel.PropertyPaymentRentFacaility;
                        Col_Payment.IsVisible = false;
                        Col_PaymentRent.IsVisible = true;

                    }
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = true;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
            }
            else if (stkContactInformation.IsVisible == true)
            {
                stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                        StkDetailsBuilding.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = false;
                        stkAdvertise.IsVisible = true;
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
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                StkDetailsBuilding.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (data.Id == 2)
            {
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }

            }
            else if (data.Id == 3)
            {
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = true;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }

            }
            else if (data.Id == 4)
            {
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = true;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }

            }
            else if (data.Id == 5)
            {
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = true;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.PhotosList.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                  
                   
                        if (viewModel.AdvertisementModel.AgreementStatus == 1)
                        {
                         Col_Payment.ItemsSource = viewModel.PropertyPaymentFacaility;
                            Col_Payment.IsVisible = true;
                            Col_PaymentRent.IsVisible = false;
                        }
                        else
                        {
                               Col_PaymentRent.ItemsSource = viewModel.PropertyPaymentRentFacaility;
                            Col_Payment.IsVisible = false;
                            Col_PaymentRent.IsVisible = true;
                        }
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        StkDetailsBuilding.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = true;
                        stkAdvertise.IsVisible = false;
                        stkContactInformation.IsVisible = false;
                }

            }
            else if (data.Id == 6)
            {
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                            StkDetailsBuilding.IsVisible = true;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.PhotosList.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.Price == 0)
                {
                   
                        if (viewModel.AdvertisementModel.AgreementStatus == 1)
                        {
                         Col_Payment.ItemsSource = viewModel.PropertyPaymentFacaility;
                            Col_Payment.IsVisible = true;
                            Col_PaymentRent.IsVisible = false;
                        }
                        else
                        {
                               Col_PaymentRent.ItemsSource = viewModel.PropertyPaymentRentFacaility;
                            Col_Payment.IsVisible = false;
                            Col_PaymentRent.IsVisible = true;

                        }
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        StkDetailsBuilding.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = true;
                        stkAdvertise.IsVisible = false;
                        stkContactInformation.IsVisible = false;
                   
                   
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                    stkAdvertise.IsVisible = true;
                }

            }
            else if (data.Id == 7)
            {
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                            StkDetailsBuilding.IsVisible = true;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.PhotosList.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.Price == 0)
                {
                  
                        if (viewModel.AdvertisementModel.AgreementStatus == 1)
                        {
                         Col_Payment.ItemsSource = viewModel.PropertyPaymentFacaility;
                            Col_Payment.IsVisible = true;
                            Col_PaymentRent.IsVisible = false;
                        }
                        else
                        {
                               Col_PaymentRent.ItemsSource = viewModel.PropertyPaymentRentFacaility;
                            Col_Payment.IsVisible = false;
                            Col_PaymentRent.IsVisible = true;

                        }
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        StkDetailsBuilding.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = true;
                        stkAdvertise.IsVisible = false;
                        stkContactInformation.IsVisible = false;
                   
                }
                else if (string.IsNullOrEmpty(viewModel.AdvertisementModel.AdvertiseMakerName))
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                    stkAdvertise.IsVisible = true;
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 7).FirstOrDefault();
                    StkDetailsBuilding.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
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
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var mediaOption = new PickMediaOptions()
                    {
                        PhotoSize = PhotoSize.Medium
                    };
                    _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                    if (_mediaFile == null) return;
                    img.Source = ImageSource.FromStream(() => _mediaFile.GetStream());

                    var data = viewModel.PropertyPhotos.ToList().IndexOf(item);
                    viewModel.PropertyPhotos.RemoveAt(data);
                    viewModel.PropertyPhotos.Insert(data, await uploadFile());
                });

            }
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new AppShell();
            // true or false to disable or enable the action
            return base.OnBackButtonPressed();
        }

        private void Col_PaymentRent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Col_PaymentRent.SelectedItem != null)
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
            }
            catch (Exception ex)
            { }
        }
    }
}