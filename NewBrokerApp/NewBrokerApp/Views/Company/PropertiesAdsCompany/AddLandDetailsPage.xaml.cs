using DevExpress.XamarinForms.Editors;
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
using NewBrokerApp.Views.PropertiesAds;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Company.PropertiesAdsCompany
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLandDetailsPage : ContentPage
    {
        PropertyViewModel viewModel;
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
        public int PropertyType;
        public AddLandDetailsPage()
        {
            InitializeComponent();
            var propertyType = Constants.NavigationParamter as DefinitionModel;
            PropertyType = propertyType.Id;
            lblTitle.Text = AppResources.add + " " + propertyType.Name;
            BindingContext = viewModel = new PropertyViewModel();
            viewModel.AdvertisementModel.Type = propertyType.Id;
            viewModel.Type = 1;
            datePickerDelivery.MinimumDate = DateTime.Now;
            viewModel.AdvertisementModel.DeliveryDate = DateTime.Now;
            viewModel.LoadPropertyStatusTypeForLandCommand.Execute(true);
            viewModel.LoadPropertyUsingForLandCommand.Execute(true);
            viewModel.LoadPropertyNumbersCommand.Execute(true);
            viewModel.LoadPropertyStatusCommand.Execute(true);
            viewModel.LoadPropertyDocumentCommand.Execute(true);
            viewModel.LoadPropertyFinishedCommand.Execute(true);
            viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);

            Device.BeginInvokeOnMainThread(async () =>
            {
                viewModel.LoadPropertyPriceCommand.Execute(true);
                viewModel.ChoosePropertyFacilitiesCommand.Execute(true);
            });
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            viewModel.LoadPropertyGovernmentsCommand.Execute(true);
            if (!IsValidPropertyBasic())
            {
                return;
            }
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
           // viewModel.AdvertisementModel.CityId = viewModel.SelectCity.Id;
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
            if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Latitude)|| string.IsNullOrEmpty(viewModel.AdvertisementModel.Longitude))
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
                    if (viewModel.AdvertisementModel.AdvertisementFacilitesList.Count == 0)
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

            if (viewModel.AdvertisementModel.MediaFiles.Count == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.pleaseUploadAtleatestonePhoto, AppResources.ok);

                return false;
            }
            if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Description))
            {
                App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyDescription, AppResources.ok);
                return false;
            }
            if (viewModel.AdvertisementModel.MediaFilesLayout.Count == 0)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.pleaseUploadAtleatestoneLayout, AppResources.ok);

                return false;
            }
            return true;


        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            if (Constants.NavigationProject == null)
            {
                framPuplish.IsVisible = true;
            }
            else
            {
                framPuplish.IsVisible = false;
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
            Shell.Current.Navigation.PushAsync(new PropertyTypesPage());
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
            stkDetailsLand.IsVisible = false;
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

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.AgreementStatus = data.Id;
        }

        private void CheckBox_CheckedChanged_2(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                var cb = (CheckBox)sender;
                var item = (DefinitionModel)cb.BindingContext;
                if (e.Value == true)
                {
                    viewModel.AdvertisementModel.AdvertisementFacilitesList.Add(item.Id);
                }
                else
                {
                    viewModel.AdvertisementModel.AdvertisementFacilitesList.Remove(item.Id);
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void CollectionView_SelectionChanged_9(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Document = data.Id;
        }

        private void CollectionView_SelectionChanged_10(object sender, SelectionChangedEventArgs e)
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

        private async void TapGestureRecognizer_Tapped_16(object sender, EventArgs e)
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
                viewModel.AdvertisementModel.MediaFiles.Add(_mediaFile);
            }
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
            viewModel.AdvertisementModel.ContactRegisterInTheAccount = e.Value;
        }
        private void CollectionView_SelectionChanged_18(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.LandingStatus = data.Id;
        }
        private void CollectionView_SelectionChanged_19(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.UsingFor = data.Id;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            viewModel.AdvertisementModel.IsWhatsApped = e.Value;
        }
        private async void TapGestureRecognizer_Tapped_19(object sender, EventArgs e)
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
                    viewModel.AdvertisementModel.MediaFiles.Add(_mediaFile2);
                }
            }
            catch (Exception ex)
            {

            }
    
        }

        private async void TapGestureRecognizer_Tapped_20(object sender, EventArgs e)
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
                    viewModel.AdvertisementModel.MediaFiles.Add(_mediaFile3);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void TapGestureRecognizer_Tapped_21(object sender, EventArgs e)
        {
            frmPhoto.IsVisible = false;
            gridPhoto.IsVisible = true;

        }

        private async void TapGestureRecognizer_Tapped_22(object sender, EventArgs e)
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
                    viewModel.AdvertisementModel.MediaFiles.Add(_mediaFile4);
                }
            }
            catch (Exception ex)
            {

            }
         
        }

        private async void TapGestureRecognizer_Tapped_23(object sender, EventArgs e)
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
                viewModel.AdvertisementModel.MediaFiles.Add(_mediaFile5);
            }
        }

        private async void TapGestureRecognizer_Tapped_24(object sender, EventArgs e)
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
                viewModel.AdvertisementModel.MediaFiles.Add(_mediaFile6);
            }

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
                //Constants.UserVerifyCode = GetVerifyCode();
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
            await PopupNavigation.Instance.PushAsync(new GetAddress(viewModel.AdvertisementModel,tcs));
            //await Navigation.PushPopupAsync(new CityPage(tcs));
            var data = await tcs.Task;
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
                else if (viewModel.AdvertisementModel.AdvertisementFacilitesList.Count == 0)
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
                else if (viewModel.AdvertisementModel.AdvertisementFacilitesList.Count == 0)
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
                else if (viewModel.AdvertisementModel.MediaFiles.Count == 0)
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
                if (Constants.NavigationProject == null)
                {
                    framPuplish.IsVisible = true;
                }
                else
                {
                    framPuplish.IsVisible = false;
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
                else if (viewModel.AdvertisementModel.AdvertisementFacilitesList.Count == 0)
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
                else if (viewModel.AdvertisementModel.MediaFiles.Count == 0)
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
        private async void TapGestureRecognizer_Tapped_29(object sender, EventArgs e)
        {
            frmLayout.IsVisible = false;
            gridLayout.IsVisible = true;
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
                viewModel.AdvertisementModel.MediaFilesLayout.Add(_mediaFile7);
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
                viewModel.AdvertisementModel.MediaFilesLayout.Add(_mediaFile8);
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
                viewModel.AdvertisementModel.MediaFilesLayout.Add(_mediaFile9);
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
                viewModel.AdvertisementModel.MediaFilesLayout.Add(_mediaFile10);
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
                viewModel.AdvertisementModel.MediaFilesLayout.Add(_mediaFile11);
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
                viewModel.AdvertisementModel.MediaFilesLayout.Add(_mediaFile12);
            }
        }
    }
}