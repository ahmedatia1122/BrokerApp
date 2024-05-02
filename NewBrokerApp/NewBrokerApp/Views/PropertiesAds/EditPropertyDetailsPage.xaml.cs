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
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.PropertiesAds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPropertyDetailsPage : ContentPage
    {
        PropertyViewModel viewModel;
        MediaFile _mediaFile;
        MediaFile _mediaFile2;
        MediaFile _mediaFile3;
        MediaFile _mediaFile4;
        MediaFile _mediaFile5;
        MediaFile _mediaFile6;
        public int PropertyType;
        public EditPropertyDetailsPage()
        {
            InitializeComponent();
            Device.BeginInvokeOnMainThread( async () => {
                var propertyType = Constants.AdvertisementParamter as Advertisement;
                PropertyType =Convert.ToInt32(propertyType.TypeId);
                BindingContext = viewModel = new PropertyViewModel();
                lblTitle.Text = AppResources.Edit + " " + propertyType.Type;
                viewModel.LoadPropertyPersonTypeCommand.Execute(true);
                viewModel.LoadPropertyNumbersCommand.Execute(true);
                viewModel.LoadPropertyStatusCommand.Execute(true);
                viewModel.LoadPropertyPriceCommand.Execute(true);
                viewModel.LoadPropertyCitiesCommand.Execute(true);
                viewModel.LoadPropertyDocumentCommand.Execute(true);
                viewModel.LoadPropertyFinishedCommand.Execute(true);
                viewModel.Type = 1;
                viewModel.ChoosePropertyFacilitiesCommand.Execute(true);
                viewModel.LoadPropertyProximityToTheSeaCommand.Execute(true);
                viewModel.LoadPropertyChaletTypeCommand.Execute(true);
                viewModel.LoadPropertyStatusTypeForLandCommand.Execute(true);
                viewModel.LoadPropertyUsingForLandCommand.Execute(true);
                viewModel.LoadPropertyBuildingUsingCommand.Execute(true);
                viewModel.LoadPropertyBuildingUnitsCommand.Execute(true);
                viewModel.LoadPropertyBuildingPartationsCommand.Execute(true);
                viewModel.LoadPropertyAdminTypeCommand.Execute(true);
                viewModel.LoadPropertyPersonTitleCommand.Execute(true);
                viewModel.AdvertiseForEditCommand.Execute(true);
                viewModel.LoadPropertyMinBookListCommand.Execute(true);
            });
            

        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (viewModel.AdvertisementModel.NumOfMonths == 1)
            {
                stkOneMonth.IsVisible = true;
                stkTwo.IsVisible = false;
            }
            else
            {
                stkTwo.IsVisible = true;
                stkOneMonth.IsVisible = false;
            }
           
            if (!IsValidPropertyBasic())
            {
                return;
            }
            
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = true;
            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
            stkDetails.IsVisible = false;
            stkDetailsVilla.IsVisible = false;
            StkDetailsBuilding.IsVisible = false;
            stkDetailsChalet.IsVisible = false;
            stkDetailsLand.IsVisible = false;
            stkDetailsShops.IsVisible = false;
            stkDetailsAdmin.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
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
        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            var data = await waitForChooseCity();
            //  await PopupNavigation.Instance.PushAsync(new CityPage());
            //txtCity.Text = data.Name;
            viewModel.AdvertisementModel.CityId = data.Id;
        }
        private async Task<CityModel> waitForChooseCity()
        {
            var tcs = new TaskCompletionSource<CityModel>();
            await PopupNavigation.Instance.PushAsync(new CityPage(tcs));
            //await Navigation.PushPopupAsync(new CityPage(tcs));
            return await tcs.Task;
        }
        private async Task<string> waitForChoosePropertyType()
        {
            var tcs = new TaskCompletionSource<string>();
            await PopupNavigation.Instance.PushAsync(new PropertyPage(tcs));
            //await Navigation.PushPopupAsync(new CityPage(tcs));
            return await tcs.Task;
        }
        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            
            if (!IsValidPropertyAddress())
            {
                return;
            }
            viewModel.AdvertisementModel.CityId = viewModel.SelectCity.Id;
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
            switch (PropertyType)
            {
                case 1:
                    stkDetails.IsVisible = true;
                    break;
                case 2:
                    stkDetailsVilla.IsVisible = true;
                    break;
                case 3:
                    stkDetailsChalet.IsVisible = true;
                    break;
                case 4:
                    StkDetailsBuilding.IsVisible = true;
                    break;
                case 5:
                    stkDetailsAdmin.IsVisible = true;
                    break;
                case 6:
                    stkDetailsShops.IsVisible = true;
                    break;
                case 7:
                    stkDetailsLand.IsVisible = true;
                    break;
            }
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }
        private  bool IsValidPropertyAddress()
        {

            if (viewModel.SelectCity == null)
            {
                App.Current.MainPage.DisplayAlert("", AppResources.chooseCity, AppResources.ok);

                return false;
            }
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
            //if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Latitude)|| string.IsNullOrEmpty(viewModel.AdvertisementModel.Longitude))
            //{
            //    getForAddress();
            //    return false;
            //}
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
            stkDetails.IsVisible = false;
            stkDetailsVilla.IsVisible = false;
            StkDetailsBuilding.IsVisible = false;
            stkDetailsChalet.IsVisible = false;
            stkDetailsLand.IsVisible = false;
            stkDetailsShops.IsVisible = false;
            stkDetailsAdmin.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }
        private bool IsValidPropertyDetails()
        {

            switch (viewModel.AdvertisementModel.Type)
            {
                case 1:
                
                    if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Area))
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyArea, AppResources.ok);
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
                    
                    break;
                case 2:
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
                    break;
                case 3:
                    if (viewModel.AdvertisementModel.ChaletType == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyChaletType, AppResources.ok);
                        return false;
                    }
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
                    if (viewModel.AdvertisementModel.ProximityToTheSea == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyProximityToTheSeat, AppResources.ok);
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

                    break;
                case 4:
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
                   
                    break;
                case 5:
                    if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Area))
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyArea, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.Officies==0)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.chooseofficeType, AppResources.ok);
                        return false;
                    }
                   
                    if (viewModel.AdvertisementModel.OfficesFloors == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyOfficesFloors, AppResources.ok);
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
                    break;
                case 6:
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
                    
                    break;
                case 7:
                    if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Area))
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyArea, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.StreetWidth==0)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyStreetWidth, AppResources.ok);
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
                    if (viewModel.AdvertisementModel.LandingStatus == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyLandingStatus, AppResources.ok);
                        return false;
                    }
                    if (viewModel.AdvertisementModel.UsingFor == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyUsingFor, AppResources.ok);
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
                   
                    break;
                   
            }
            return true;

        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            if (!IsValidPropertyPhotos())
            {
                return;
            }
            if(viewModel.AdvertisementModel.Type == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
               viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                PriceChalets.IsVisible = true;
                stkPrice.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else
            {
                if (viewModel.AdvertisementModel.AgreementStatus == 1)
                {
                    viewModel.LoadPropertyPaymentFacilityCommand.Execute(true);
                    Col_Payment.IsVisible = true;
                    Col_PaymentRent.IsVisible = false;
                }
                else
                {
                    viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
                    Col_Payment.IsVisible = false;
                    Col_PaymentRent.IsVisible = true;

                }
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
               viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkPrice.IsVisible = true;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
           

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
                viewModel.AdvertisementModel.PaymentFacility =viewModel.SelectedPaymentFacality?.Id;
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkContactInformation.IsVisible = false;
                stkAdvertise.IsVisible = true;
        }
        private bool IsValidPropertyPricing()
        {
            if(PropertyType == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
            {
                if (viewModel.AdvertisementModel.DurationId == 0)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseChooseDuration, AppResources.ok);

                    return false;
                }
                
                return true;
            }
            else
            {
                if (viewModel.AdvertisementModel.Price == 0)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterPropertyPrice, AppResources.ok);

                    return false;
                }
                if (viewModel.SelectedPaymentFacality == null)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.enterPaymentFacility, AppResources.ok);
                    return false;
                }

                return true;
            }
         


        }
        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new PropertyTypesPage());
        }

        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new AddsPage());
        }

        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new PaymentPage());
        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            stkBasic.IsVisible = true;
            StkAddress.IsVisible = false;
            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
            stkDetails.IsVisible = false;
            stkDetailsVilla.IsVisible = false;
            StkDetailsBuilding.IsVisible = false;
            stkDetailsChalet.IsVisible = false;
            stkDetailsLand.IsVisible = false;
            stkDetailsAdmin.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = true;
          viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
            stkDetails.IsVisible = false;
            stkDetailsVilla.IsVisible = false;
            StkDetailsBuilding.IsVisible = false;
            stkDetailsChalet.IsVisible = false;
            stkDetailsLand.IsVisible = false;
            stkDetailsShops.IsVisible = false;
            stkDetailsAdmin.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_12(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
           viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
            switch (PropertyType)
            {
                case 1:
                    stkDetails.IsVisible = true;
                    break;
                case 2:
                    stkDetailsVilla.IsVisible = true;
                    break;
                case 3:
                    stkDetailsChalet.IsVisible = true;
                    break;
                case 4:
                    StkDetailsBuilding.IsVisible = true;
                    break;
                case 5:
                    stkDetailsAdmin.IsVisible = true;
                    break;
                case 6:
                    stkDetailsShops.IsVisible = true;
                    break;
                case 7:
                    stkDetailsLand.IsVisible = true;
                    break;
            }
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_13(object sender, EventArgs e)
        {
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
          viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
            stkDetails.IsVisible = false;
            stkDetailsVilla.IsVisible = false;
            StkDetailsBuilding.IsVisible = false;
            stkDetailsChalet.IsVisible = false;
            stkDetailsLand.IsVisible = false;
            stkDetailsShops.IsVisible = false;
            stkDetailsAdmin.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_14(object sender, EventArgs e)
        {
            if(PropertyType == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = true;
                stkContactInformation.IsVisible = false;
                stkAdvertise.IsVisible = false;
            }
            else
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = true;
                PriceChalets.IsVisible = false;
                stkContactInformation.IsVisible = false;
                stkAdvertise.IsVisible = false;
            }
            

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
            stkDetails.IsVisible = false;
            stkDetailsVilla.IsVisible = false;
            StkDetailsBuilding.IsVisible = false;
            stkDetailsChalet.IsVisible = false;
            stkDetailsLand.IsVisible = false;
            stkDetailsShops.IsVisible = false;
            stkDetailsAdmin.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
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
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.AgreementStatus = data.Id;
        }

        private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.BuildingStatus = data.Id;
        }

        private void CollectionView_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Decoration = data.Id;
        }

        private void CollectionView_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Rooms = data.Id;
        }

        private void CollectionView_SelectionChanged_4(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Reception = data.Id;
        }

        private void CollectionView_SelectionChanged_5(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Dinning = data.Id;
        }

        private void CollectionView_SelectionChanged_6(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Balcony = data.Id;
        }

        private void CollectionView_SelectionChanged_7(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Kitchen = data.Id;
        }

        private void CollectionView_SelectionChanged_8(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Toilet = data.Id;
        }

        private void FunishedCheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            viewModel.AdvertisementModel.Furnished = e.Value;
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            viewModel.AdvertisementModel.Elevator = e.Value;
        }

        private void CheckBox_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {
            viewModel.AdvertisementModel.Garden = e.Value;
            entryGarden.IsEnabled = e.Value == true ?true:false;
            entryGardenArea.IsEnabled = e.Value == true ? true : false;
            entryGardenArea1.IsEnabled = e.Value == true ? true : false;
            GardenDetailsVilla.IsEnabled = e.Value == true ? true : false;
        }

        private void CollectionView_SelectionChanged_9(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Document = data.Id;
        }

        private void CheckBox_CheckedChanged_2(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                var cb = (CheckBox)sender;
                var item = (AdvertisementFacilites)cb.BindingContext;
                //if (e.Value == true)viewModel.AdvertisementModel.PaymentFacility
                //{
                //   // viewModel.AdvertisementModel.FacilitesApi.Add(item.Id);
                //}
                //else
                //{
                //   // viewModel.AdvertisementModel.FacilitesApi.Remove(item.Id);
                //}

            }
            catch (Exception ex)
            {

            }
        }

        private void CollectionView_SelectionChanged_10(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.PaymentFacility = data.Id;

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
            viewModel.AdvertisementModel.ContactRegisterInTheAccount = e.Value;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            viewModel.AdvertisementModel.IsWhatsApped = e.Value;
        }

        private void CollectionView_SelectionChanged_11(object sender, SelectionChangedEventArgs e)
        {
            // please check this property
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.UsingFor = data.Id;
        }

        private void CollectionView_SelectionChanged_12(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.BuildingStatus = data.Id;
        }

        private void CollectionView_SelectionChanged_13(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Decoration = data.Id;
        }

        private void CollectionView_SelectionChanged_14(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.NumUnits = data.Id;
        }

        private void CollectionView_SelectionChanged_15(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.NumPartitions = data.Id;
        }

        private void CheckBox_CheckedChanged_4(object sender, CheckedChangedEventArgs e)
        {
            viewModel.AdvertisementModel.Shop = e.Value;
            buildingshopNo.IsEnabled = e.Value == true ? true : false;
        }

        private void CheckBox_CheckedChanged_5(object sender, CheckedChangedEventArgs e)
        {
            viewModel.AdvertisementModel.Parking = e.Value;
            BuildingSpace.IsEnabled = e.Value == true ? true : false;
        }

        private void CollectionView_SelectionChanged_16(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.ProximityToTheSea = data.Id;

        }

        private void CollectionView_SelectionChanged_17(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.ChaletType = data.Id;

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

        private void CollectionView_SelectionChanged_20(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.OfficesFloors = data.Id;
        }

        private void CollectionView_SelectionChanged_21(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.OfficesFloors = data.Id;
        }

        private void CheckBox_CheckedChanged_6(object sender, CheckedChangedEventArgs e)
        {
            viewModel.AdvertisementModel.AirConditioner = e.Value;
        }

        
      


      

        private void CheckBox_CheckedChanged_7(object sender, CheckedChangedEventArgs e)
        {
            viewModel.AdvertisementModel.Parking = e.Value;
            entryparking.IsEnabled = e.Value == true ? true : false;
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

        private void CollectionView_SelectionChanged_22(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Officies = data.Id;
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
            var grid = (Grid)sender;
             var item = (string)grid.BindingContext;
            var img =(CachedImage) grid.Children.ElementAt(0);
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

               var data= viewModel.PropertyPhotos.ToList().IndexOf(item);
                viewModel.PropertyPhotos.Remove(item);
                item = await uploadFile();
                viewModel.PropertyPhotos.Insert(data,item);

            }
        }

        private void CheckBox_CheckedChanged_8(object sender, CheckedChangedEventArgs e)
        {
            viewModel.AdvertisementModel.Pool = e.Value;
            BuildingSpace.IsEnabled = e.Value == true ? true : false;
        }
        private async void TapGestureRecognizer_Tapped_16(object sender, EventArgs e)
        {
            if (stkBasic.IsVisible == true)
            {
                await Shell.Current.Navigation.PopAsync();
            }
            else if (StkAddress.IsVisible == true)
            {
                stkBasic.IsVisible = true;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (stkDetails.IsVisible == true || stkDetailsVilla.IsVisible == true ||
                StkDetailsBuilding.IsVisible == true || stkDetailsChalet.IsVisible == true
                || stkDetailsLand.IsVisible == true || stkDetailsShops.IsVisible == true
                || stkDetailsAdmin.IsVisible == true)
            {

                stkBasic.IsVisible = false;
                StkAddress.IsVisible = true;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;

            }

            else if (stkPhoto.IsVisible == true)
            {

                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                switch (PropertyType)
                {
                    case 1:
                        stkDetails.IsVisible = true;
                        break;
                    case 2:
                        stkDetailsVilla.IsVisible = true;
                        break;
                    case 3:
                        stkDetailsChalet.IsVisible = true;
                        break;
                    case 4:
                        StkDetailsBuilding.IsVisible = true;
                        break;
                    case 5:
                        stkDetailsAdmin.IsVisible = true;
                        break;
                    case 6:
                        stkDetailsShops.IsVisible = true;
                        break;
                    case 7:
                        stkDetailsLand.IsVisible = true;
                        break;
                }
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (PriceChalets.IsVisible == true || stkPrice.IsVisible == true)
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = true;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (stkAdvertise.IsVisible == true)
            {
                if (PropertyType == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                   viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    PriceChalets.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    if (viewModel.AdvertisementModel.AgreementStatus == 1)
                    {
                        viewModel.LoadPropertyPaymentFacilityCommand.Execute(true);
                        Col_Payment.IsVisible = true;
                        Col_PaymentRent.IsVisible = false;
                    }
                    else
                    {
                        viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
                        Col_Payment.IsVisible = false;
                        Col_PaymentRent.IsVisible = true;

                    }
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                   viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkPrice.IsVisible = true;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
            }
            else if (stkContactInformation.IsVisible == true)
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = true;
                stkContactInformation.IsVisible = false;
            }
        }
        protected override bool OnBackButtonPressed()
        {
            if (stkBasic.IsVisible == true)
            {
                Shell.Current.Navigation.PopAsync();
            }
            else if (StkAddress.IsVisible == true)
            {
                stkBasic.IsVisible = true;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (stkDetails.IsVisible == true || stkDetailsVilla.IsVisible == true ||
                StkDetailsBuilding.IsVisible == true || stkDetailsChalet.IsVisible == true
                || stkDetailsLand.IsVisible == true || stkDetailsShops.IsVisible == true
                || stkDetailsAdmin.IsVisible == true)
            {

                stkBasic.IsVisible = false;
                StkAddress.IsVisible = true;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;

            }

            else if (stkPhoto.IsVisible == true)
            {

                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                switch (PropertyType)
                {
                    case 1:
                        stkDetails.IsVisible = true;
                        break;
                    case 2:
                        stkDetailsVilla.IsVisible = true;
                        break;
                    case 3:
                        stkDetailsChalet.IsVisible = true;
                        break;
                    case 4:
                        StkDetailsBuilding.IsVisible = true;
                        break;
                    case 5:
                        stkDetailsAdmin.IsVisible = true;
                        break;
                    case 6:
                        stkDetailsShops.IsVisible = true;
                        break;
                    case 7:
                        stkDetailsLand.IsVisible = true;
                        break;
                }
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (PriceChalets.IsVisible == true || stkPrice.IsVisible == true)
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = true;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (stkAdvertise.IsVisible == true)
            {
                if (PropertyType == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                   viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    PriceChalets.IsVisible = true;
                    stkPrice.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    if (viewModel.AdvertisementModel.AgreementStatus == 1)
                    {
                        viewModel.LoadPropertyPaymentFacilityCommand.Execute(true);
                        Col_Payment.IsVisible = true;
                        Col_PaymentRent.IsVisible = false;
                    }
                    else
                    {
                        viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
                        Col_Payment.IsVisible = false;
                        Col_PaymentRent.IsVisible = true;

                    }
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                   viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkPrice.IsVisible = true;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
            }
            else if (stkContactInformation.IsVisible == true)
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                stkDetails.IsVisible = false;
                stkDetailsVilla.IsVisible = false;
                StkDetailsBuilding.IsVisible = false;
                stkDetailsChalet.IsVisible = false;
                stkDetailsLand.IsVisible = false;
                stkDetailsShops.IsVisible = false;
                stkDetailsAdmin.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = true;
                stkContactInformation.IsVisible = false;
            }
            return true;
            // return base.OnBackButtonPressed();
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
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                        stkDetails.IsVisible = false;
                        stkDetailsVilla.IsVisible = false;
                        StkDetailsBuilding.IsVisible = false;
                        stkDetailsChalet.IsVisible = false;
                        stkDetailsLand.IsVisible = false;
                        stkDetailsShops.IsVisible = false;
                        stkDetailsAdmin.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = false;
                        PriceChalets.IsVisible = false;
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
                            stkDetails.IsVisible = false;
                            stkDetailsVilla.IsVisible = false;
                            StkDetailsBuilding.IsVisible = false;
                            stkDetailsChalet.IsVisible = false;
                            stkDetailsLand.IsVisible = false;
                            stkDetailsShops.IsVisible = false;
                            stkDetailsAdmin.IsVisible = false;
                            stkPhoto.IsVisible = false;
                            stkPrice.IsVisible = false;
                            PriceChalets.IsVisible = false;
                            stkAdvertise.IsVisible = false;
                            stkContactInformation.IsVisible = false;
                        }
                        else
                        {
                            stkBasic.IsVisible = false;
                            StkAddress.IsVisible = true;
                            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                            stkDetails.IsVisible = false;
                            stkDetailsVilla.IsVisible = false;
                            StkDetailsBuilding.IsVisible = false;
                            stkDetailsChalet.IsVisible = false;
                            stkDetailsLand.IsVisible = false;
                            stkDetailsShops.IsVisible = false;
                            stkDetailsAdmin.IsVisible = false;
                            stkPhoto.IsVisible = false;
                            stkPrice.IsVisible = false;
                            PriceChalets.IsVisible = false;
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
                            stkDetails.IsVisible = false;
                            stkDetailsVilla.IsVisible = false;
                            StkDetailsBuilding.IsVisible = false;
                            stkDetailsChalet.IsVisible = false;
                            stkDetailsLand.IsVisible = false;
                            stkDetailsShops.IsVisible = false;
                            stkDetailsAdmin.IsVisible = false;
                            stkPhoto.IsVisible = false;
                            stkPrice.IsVisible = false;
                            PriceChalets.IsVisible = false;
                            stkAdvertise.IsVisible = false;
                            stkContactInformation.IsVisible = false;
                        }
                        else if (viewModel.AdvertisementModel.CityId == 0)
                        {
                            stkBasic.IsVisible = false;
                            StkAddress.IsVisible = true;
                            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                            stkDetails.IsVisible = false;
                            stkDetailsVilla.IsVisible = false;
                            StkDetailsBuilding.IsVisible = false;
                            stkDetailsChalet.IsVisible = false;
                            stkDetailsLand.IsVisible = false;
                            stkDetailsShops.IsVisible = false;
                            stkDetailsAdmin.IsVisible = false;
                            stkPhoto.IsVisible = false;
                            stkPrice.IsVisible = false;
                            PriceChalets.IsVisible = false;
                            stkAdvertise.IsVisible = false;
                            stkContactInformation.IsVisible = false;
                        }
                        else
                        {
                            stkBasic.IsVisible = false;
                            StkAddress.IsVisible = false;
                            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                            switch (PropertyType)
                            {
                                case 1:
                                    stkDetails.IsVisible = true;
                                    break;
                                case 2:
                                    stkDetailsVilla.IsVisible = true;
                                    break;
                                case 3:
                                    stkDetailsChalet.IsVisible = true;
                                    break;
                                case 4:
                                    StkDetailsBuilding.IsVisible = true;
                                    break;
                                case 5:
                                    stkDetailsAdmin.IsVisible = true;
                                    break;
                                case 6:
                                    stkDetailsShops.IsVisible = true;
                                    break;
                                case 7:
                                    stkDetailsLand.IsVisible = true;
                                    break;
                            }
                            stkPhoto.IsVisible = false;
                            stkPhoto.IsVisible = false;
                            stkPrice.IsVisible = false;
                            PriceChalets.IsVisible = false;
                            stkAdvertise.IsVisible = false;
                            stkContactInformation.IsVisible = false;
                        }

                    }
                    else if (data.Id == 4)
                    {
                if (viewModel.AdvertisementModel.NumOfMonths == 1)
                {
                    stkOneMonth.IsVisible = true;
                    stkTwo.IsVisible = false;
                }
                else
                {
                    stkTwo.IsVisible = true;
                    stkOneMonth.IsVisible = false;
                }
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                        {
                            stkBasic.IsVisible = true;
                            StkAddress.IsVisible = false;
                            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                            stkDetails.IsVisible = false;
                            stkDetailsVilla.IsVisible = false;
                            StkDetailsBuilding.IsVisible = false;
                            stkDetailsChalet.IsVisible = false;
                            stkDetailsLand.IsVisible = false;
                            stkDetailsShops.IsVisible = false;
                            stkDetailsAdmin.IsVisible = false;
                            stkPhoto.IsVisible = false;
                            stkPrice.IsVisible = false;
                            PriceChalets.IsVisible = false;
                            stkAdvertise.IsVisible = false;
                            stkContactInformation.IsVisible = false;
                        }
                        else if (viewModel.AdvertisementModel.CityId == 0)
                        {
                            stkBasic.IsVisible = false;
                            StkAddress.IsVisible = true;
                            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                            stkDetails.IsVisible = false;
                            stkDetailsVilla.IsVisible = false;
                            StkDetailsBuilding.IsVisible = false;
                            stkDetailsChalet.IsVisible = false;
                            stkDetailsLand.IsVisible = false;
                            stkDetailsShops.IsVisible = false;
                            stkDetailsAdmin.IsVisible = false;
                            stkPhoto.IsVisible = false;
                            stkPrice.IsVisible = false;
                            PriceChalets.IsVisible = false;
                            stkAdvertise.IsVisible = false;
                            stkContactInformation.IsVisible = false;
                        }
                        else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                        {
                            stkBasic.IsVisible = false;
                            StkAddress.IsVisible = false;
                            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                            switch (PropertyType)
                            {
                                case 1:
                                    stkDetails.IsVisible = true;
                                    break;
                                case 2:
                                    stkDetailsVilla.IsVisible = true;
                                    break;
                                case 3:
                                    stkDetailsChalet.IsVisible = true;
                                    break;
                                case 4:
                                    StkDetailsBuilding.IsVisible = true;
                                    break;
                                case 5:
                                    stkDetailsAdmin.IsVisible = true;
                                    break;
                                case 6:
                                    stkDetailsShops.IsVisible = true;
                                    break;
                                case 7:
                                    stkDetailsLand.IsVisible = true;
                                    break;
                            }
                            stkPhoto.IsVisible = false;
                            stkPhoto.IsVisible = false;
                            stkPrice.IsVisible = false;
                            PriceChalets.IsVisible = false;
                            stkAdvertise.IsVisible = false;
                            stkContactInformation.IsVisible = false;
                        }
                        else
                        {
                            stkBasic.IsVisible = false;
                            StkAddress.IsVisible = false;
                            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                            stkDetails.IsVisible = false;
                            stkDetailsVilla.IsVisible = false;
                            StkDetailsBuilding.IsVisible = false;
                            stkDetailsChalet.IsVisible = false;
                            stkDetailsLand.IsVisible = false;
                            stkDetailsShops.IsVisible = false;
                            stkDetailsAdmin.IsVisible = false;
                            stkPhoto.IsVisible = false;
                            stkPhoto.IsVisible = true;
                            stkPrice.IsVisible = false;
                            PriceChalets.IsVisible = false;
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
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.CityId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    switch (PropertyType)
                    {
                        case 1:
                            stkDetails.IsVisible = true;
                            break;
                        case 2:
                            stkDetailsVilla.IsVisible = true;
                            break;
                        case 3:
                            stkDetailsChalet.IsVisible = true;
                            break;
                        case 4:
                            StkDetailsBuilding.IsVisible = true;
                            break;
                        case 5:
                            stkDetailsAdmin.IsVisible = true;
                            break;
                        case 6:
                            stkDetailsShops.IsVisible = true;
                            break;
                        case 7:
                            stkDetailsLand.IsVisible = true;
                            break;
                    }
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.PhotosList.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else
                {
                    if (PropertyType == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
                    {
                        if (viewModel.AdvertisementModel.NumOfMonths == 1)
                        {
                            stkOneMonth.IsVisible = true;
                            stkTwo.IsVisible = false;
                        }
                        else
                        {
                            stkTwo.IsVisible = true;
                            stkOneMonth.IsVisible = false;
                        }
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        stkDetails.IsVisible = false;
                        stkDetailsVilla.IsVisible = false;
                        StkDetailsBuilding.IsVisible = false;
                        stkDetailsChalet.IsVisible = false;
                        stkDetailsLand.IsVisible = false;
                        stkDetailsShops.IsVisible = false;
                        stkDetailsAdmin.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = false;
                        PriceChalets.IsVisible = true;
                        stkAdvertise.IsVisible = false;
                        stkContactInformation.IsVisible = false;
                    }
                    else
                    {
                        if (viewModel.AdvertisementModel.AgreementStatus == 1)
                        {
                            viewModel.LoadPropertyPaymentFacilityCommand.Execute(true);
                            Col_Payment.IsVisible = true;
                            Col_PaymentRent.IsVisible = false;
                        }
                        else
                        {
                            viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
                            Col_Payment.IsVisible = false;
                            Col_PaymentRent.IsVisible = true;
                        }
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        stkDetails.IsVisible = false;
                        stkDetailsVilla.IsVisible = false;
                        StkDetailsBuilding.IsVisible = false;
                        stkDetailsChalet.IsVisible = false;
                        stkDetailsLand.IsVisible = false;
                        stkDetailsShops.IsVisible = false;
                        stkDetailsAdmin.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = true;
                        PriceChalets.IsVisible = false;
                        stkAdvertise.IsVisible = false;
                        stkContactInformation.IsVisible = false;
                    }
                    
                }

            }
                    else if (data.Id == 6)
            {
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.CityId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    switch (PropertyType)
                    {
                        case 1:
                            stkDetails.IsVisible = true;
                            break;
                        case 2:
                            stkDetailsVilla.IsVisible = true;
                            break;
                        case 3:
                            stkDetailsChalet.IsVisible = true;
                            break;
                        case 4:
                            StkDetailsBuilding.IsVisible = true;
                            break;
                        case 5:
                            stkDetailsAdmin.IsVisible = true;
                            break;
                        case 6:
                            stkDetailsShops.IsVisible = true;
                            break;
                        case 7:
                            stkDetailsLand.IsVisible = true;
                            break;
                    }
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.PhotosList.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.Price == 0)
                {
                    if (PropertyType == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
                    {
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                        stkDetails.IsVisible = false;
                        stkDetailsVilla.IsVisible = false;
                        StkDetailsBuilding.IsVisible = false;
                        stkDetailsChalet.IsVisible = false;
                        stkDetailsLand.IsVisible = false;
                        stkDetailsShops.IsVisible = false;
                        stkDetailsAdmin.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = false;
                        PriceChalets.IsVisible = false;
                        stkAdvertise.IsVisible = true;
                        stkContactInformation.IsVisible = false;
                    }
                    else
                    {
                        if (viewModel.AdvertisementModel.AgreementStatus == 1)
                        {
                            viewModel.LoadPropertyPaymentFacilityCommand.Execute(true);
                            Col_Payment.IsVisible = true;
                            Col_PaymentRent.IsVisible = false;
                        }
                        else
                        {
                            viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
                            Col_Payment.IsVisible = false;
                            Col_PaymentRent.IsVisible = true;

                        }
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        stkDetails.IsVisible = false;
                        stkDetailsVilla.IsVisible = false;
                        StkDetailsBuilding.IsVisible = false;
                        stkDetailsChalet.IsVisible = false;
                        stkDetailsLand.IsVisible = false;
                        stkDetailsShops.IsVisible = false;
                        stkDetailsAdmin.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = true;
                        PriceChalets.IsVisible = false;
                        stkAdvertise.IsVisible = false;
                        stkContactInformation.IsVisible = false;
                    }
                    
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
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
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.CityId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.FacilitesApi.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
                    switch (PropertyType)
                    {
                        case 1:
                            stkDetails.IsVisible = true;
                            break;
                        case 2:
                            stkDetailsVilla.IsVisible = true;
                            break;
                        case 3:
                            stkDetailsChalet.IsVisible = true;
                            break;
                        case 4:
                            StkDetailsBuilding.IsVisible = true;
                            break;
                        case 5:
                            stkDetailsAdmin.IsVisible = true;
                            break;
                        case 6:
                            stkDetailsShops.IsVisible = true;
                            break;
                        case 7:
                            stkDetailsLand.IsVisible = true;
                            break;
                    }
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.PhotosList.Count == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.Price == 0)
                {
                    if(PropertyType == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
                    {
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 7).FirstOrDefault();
                        stkDetails.IsVisible = false;
                        stkDetailsVilla.IsVisible = false;
                        StkDetailsBuilding.IsVisible = false;
                        stkDetailsChalet.IsVisible = false;
                        stkDetailsLand.IsVisible = false;
                        stkDetailsShops.IsVisible = false;
                        stkDetailsAdmin.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = false;
                        PriceChalets.IsVisible = false;
                        stkAdvertise.IsVisible = false;
                        stkContactInformation.IsVisible = true;
                    }
                    else
                    {
                        if (viewModel.AdvertisementModel.AgreementStatus == 1)
                        {
                            viewModel.LoadPropertyPaymentFacilityCommand.Execute(true);
                            Col_Payment.IsVisible = true;
                            Col_PaymentRent.IsVisible = false;
                        }
                        else
                        {
                            viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
                            Col_Payment.IsVisible = false;
                            Col_PaymentRent.IsVisible = true;

                        }
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        stkDetails.IsVisible = false;
                        stkDetailsVilla.IsVisible = false;
                        StkDetailsBuilding.IsVisible = false;
                        stkDetailsChalet.IsVisible = false;
                        stkDetailsLand.IsVisible = false;
                        stkDetailsShops.IsVisible = false;
                        stkDetailsAdmin.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = true;
                        PriceChalets.IsVisible = false;
                        stkAdvertise.IsVisible = false;
                        stkContactInformation.IsVisible = false;
                    }
                   
                }
                else if (string.IsNullOrEmpty(viewModel.AdvertisementModel.AdvertiseMakerName))
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                    stkAdvertise.IsVisible = true;
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 7).FirstOrDefault();
                    stkDetails.IsVisible = false;
                    stkDetailsVilla.IsVisible = false;
                    StkDetailsBuilding.IsVisible = false;
                    stkDetailsChalet.IsVisible = false;
                    stkDetailsLand.IsVisible = false;
                    stkDetailsShops.IsVisible = false;
                    stkDetailsAdmin.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = true;
                }



            }
        }
        private void ComboBoxEdit_SelectionChanged(object sender, EventArgs e)
        {
            var picker = (ComboBoxEdit)sender;
            var selectedItem = Convert.ToInt32(picker.SelectedItem);
            if (selectedItem == 1)
            {
                viewModel.AdvertisementModel.NumOfMonths = selectedItem;
                stkOneMonth.IsVisible = true;
                stkTwo.IsVisible = false;
            }
            else
            {
                viewModel.AdvertisementModel.NumOfMonths = selectedItem;
                DateTime today = DateTime.Today;
                int nextMonth = today.AddMonths(1).Month;
                stkOneMonth.IsVisible = false;
                stkTwo.IsVisible = true;
            }
        }
        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            entryWeek.IsEnabled = true;
            entryDay.IsEnabled = false;
            viewModel.AdvertisementModel.ChaletRentType = 1;
        }

        private void RadioButton_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {
            entryDay.IsEnabled = true;
            entryWeek.IsEnabled = false;
            viewModel.AdvertisementModel.ChaletRentType = 2;
        }
        private void CollectionView_SelectionChanged_23(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.MinTimeToBookForChaletId = data.Id;
        }

    }
}