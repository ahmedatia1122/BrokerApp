using DevExpress.XamarinForms.Core;
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
    public partial class EditChaletDetailsPage : ContentPage
    {
        PropertyViewModel viewModel;
        MediaFile _mediaFile;
        public int PropertyType;
        public bool ShowAddrssMap { get; set; } = false;
        public int IsCheckedAlert;

        public EditChaletDetailsPage()
        {
            InitializeComponent();
           // calendar.Locale = new System.Globalization.CultureInfo("en-US");
           // calendarNext.Locale = new System.Globalization.CultureInfo("en-US");
            var propertyType = Constants.AdvertisementParamter as Advertisement;
            PropertyType = Convert.ToInt32(propertyType.TypeId);
            BindingContext = viewModel = new PropertyViewModel();
            lblTitle.Text = AppResources.Edit + " " + propertyType.Type;
            viewModel.Type = 1;
            DateTime dt = DateTime.Now;
            var month = dt.ToString("MMMM");
            var nextMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            var nextMonths = DateTime.Now.AddMonths(1);
            var monthStart = new DateTime(dt.Year, dt.Month, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1).ToString("MMMM dd yyyy");
            var nextMonthEnd = monthStart.AddMonths(2).AddDays(-1).ToString("MMMM dd yyyy");
           // txtMonth.Text = $"from 1st {month} to {monthEnd}";
           // txtnextMonth.Text = $"from 1st {nextMonth} to  {nextMonthEnd}";
           // calendar.MoveToDate = new DateTime(dt.Year, dt.Month, 1);
       
         //   calendarNext.MoveToDate = new DateTime(dt.Year, nextMonths.Month, 1);
            Device.BeginInvokeOnMainThread(async () =>
            {
               
                viewModel.LoadPropertyChaletTypeCommand.Execute(true);
                viewModel.LoadPropertyMinBookListCommand.Execute(true);
                viewModel.LoadPropertyPriceCommand.Execute(true);
                viewModel.LoadPropertyNumbersCommand.Execute(true);
                viewModel.LoadPropertyStatusCommand.Execute(true);
                viewModel.LoadPropertyPersonTitleCommand.Execute(true);
                viewModel.LoadPropertyPersonTypeCommand.Execute(true);
                viewModel.LoadPropertyGovernmentsCommand.Execute(true);
                viewModel.LoadPropertyCitiesCommand.Execute(true);
                viewModel.LoadPropertyDocumentCommand.Execute(true);
                viewModel.LoadPropertyFinishedCommand.Execute(true);
                viewModel.ChoosePropertyFacilitiesCommand.Execute(true);
                viewModel.LoadPropertyProximityToTheSeaCommand.Execute(true);
                viewModel.LoadPropertyPaymentFacilityCommand.Execute(true);
                viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
                viewModel.AdvertiseForEditCommand.Execute(true);
          
                // calendar.SelectedDates = viewModel.SelectedDatesThis;

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
            stkDetailsChalet.IsVisible = false;
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
            stkDetailsChalet.IsVisible = true;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
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
            if (ShowAddrssMap==false)
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
            stkDetailsChalet.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }
        private bool IsValidPropertyDetails()
        {
                
                    if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Area))
                    {
                        App.Current.MainPage.DisplayAlert("", AppResources.enterPropertyChaletArea, AppResources.ok);
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
            if (PropertyType == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                stkDetailsChalet.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = true;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
                if (viewModel.AdvertisementModel.ChaletRentType == 1)
                {
                    radDay.IsChecked = true;
                    radWeek.IsChecked = false;
                    entryDay.Text =viewModel.AdvertisementModel.ChaletRentValue.ToString();
                    entryWeek.Text = "";
                    entryWeek.Placeholder = "Week";
                }
                else
                {
                    radWeek.IsChecked = true;
                    radDay.IsChecked = false;
                    entryWeek.Text = viewModel.AdvertisementModel.ChaletRentValue.ToString();
                    entryDay.Placeholder = "Day";
                    entryDay.Text = "";
                }
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
                stkDetailsChalet.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = true;
                PriceChalets.IsVisible = false;
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
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                stkDetailsChalet.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
            stkContactInformation.IsVisible = false;
                stkAdvertise.IsVisible = true;

            
           
        }
        private bool IsValidPropertyPricing()
        {
            //if(PropertyType == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
            //   {
            //       if (viewModel.AdvertisementModel.NumOfMonths == null)
            //       {
            //           App.Current.MainPage.DisplayAlert("", AppResources.pleaseChooseDuration, AppResources.ok);

            //           return false;
            //       }
            //       return true;
            //   }
            //   else
            //   {
          
            if (viewModel.AdvertisementModel.AgreementStatus == 1)
            {
                if (viewModel.AdvertisementModel.Price == 0)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterPropertyPrice, AppResources.ok);

                    return false;
                }
                if (viewModel.AdvertisementModel.PaymentFacility == null)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.enterPaymentFacility, AppResources.ok);
                    return false;
                }
            }
            else
            {
                if (viewModel.AdvertisementModel.ChaletRentValue == null && viewModel.AdvertisementModel.ChaletRentType==null)
                {
                    App.Current.MainPage.DisplayAlert("", AppResources.pleaseEnterPropertyRentalvalue, AppResources.ok);

                    return false;
                }
            }
            return true;
            // }


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
            stkDetailsChalet.IsVisible = false;
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
            stkDetailsChalet.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_12(object sender, EventArgs e)
        {
            viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 3).FirstOrDefault();
            stkBasic.IsVisible = false;
            StkAddress.IsVisible = false;
            stkDetailsChalet.IsVisible = true;
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
            stkDetailsChalet.IsVisible = false;
            stkPhoto.IsVisible = false;
            stkPhoto.IsVisible = true;
            stkPrice.IsVisible = false;
            PriceChalets.IsVisible = false;
            stkAdvertise.IsVisible = false;
            stkContactInformation.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_14(object sender, EventArgs e)
        {
            if (PropertyType == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                stkDetailsChalet.IsVisible = false;
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
                stkDetailsChalet.IsVisible = false;
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
            stkDetailsChalet.IsVisible = false;
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
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.AgreementStatus = data.Id;
            }
            catch (Exception ex)
            { }
           
        }

        private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.BuildingStatus = data.Id;
            }
            catch (Exception ex)
            { }
           
        }

        private void CollectionView_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.Decoration = data.Id;
            }
            catch (Exception ex)
            { }
            
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
            {

            }
           
        }

        private void CollectionView_SelectionChanged_5(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.Dinning = data.Id;
            }
            catch (Exception ex)
            {

            }
           
        }

        private void CollectionView_SelectionChanged_6(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.Balcony = data.Id;
            }
            catch (Exception ex)
            {

            }
       
        }

        private void CollectionView_SelectionChanged_7(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Kitchen = data.Id;
            }
            catch (Exception ex)
            {

            }
        }
        private void CollectionView_SelectionChanged_23(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.MinTimeToBookForChaletId = data.Id;
             }
            catch (Exception ex)
            {

            }
        }
        private void CollectionView_SelectionChanged_8(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.Toilet = data.Id;
            }
            catch (Exception ex)
            {

            }
        }
        private void CollectionView_SelectionChanged_17(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
                viewModel.AdvertisementModel.ChaletType = data.Id;
            }
            catch (Exception ex)
            { }
    

        }
        private void CollectionView_SelectionChanged_16(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var data = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            viewModel.AdvertisementModel.ProximityToTheSea = data.Id;
            }
            catch (Exception ex)
            {

            }

        }
        private void RadioButton_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {
            try
            {

           
            entryDay.IsEnabled = true;
            entryWeek.IsEnabled = false;
            viewModel.AdvertisementModel.ChaletRentType = 1;
        }
            catch (Exception ex)
            {

            }
}
        private void CheckBox_CheckedChanged_8(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                viewModel.AdvertisementModel.Pool = e.Value;
            }
            catch (Exception ex)
            { }
        
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                entryWeek.IsEnabled = true;
                entryDay.IsEnabled = false;
                viewModel.AdvertisementModel.ChaletRentType = 2;
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
        private void CheckBox_CheckedChanged_5(object sender, CheckedChangedEventArgs e)
        {
           
            try
            {
                viewModel.AdvertisementModel.Parking = e.Value;
            }
            catch (Exception ex)
            { }
        }

        private void CheckBox_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {
           
            try
            {
                viewModel.AdvertisementModel.Garden = e.Value;
                entryGardenArea1.IsEnabled = e.Value == true ? true : false;
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

        private async void CheckBox_CheckedChanged_4(object sender, CheckedChangedEventArgs e)
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
                    viewModel.PropertyPhotosNext.Insert(data,await uploadFile());
                });
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
           viewModel.AdvertisementModel.Latitude = data.Latitude;
            viewModel.AdvertisementModel.Longitude = data.Longitude;
            if (string.IsNullOrEmpty(data.Latitude) || string.IsNullOrEmpty(data.Longitude))
            {
                ShowAddrssMap = false;

            }
            else
            {
                ShowAddrssMap = true;
            }
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
                stkDetailsChalet.IsVisible = false;
                stkPhoto.IsVisible = false;
                stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (stkDetailsChalet.IsVisible ==true)
            {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsChalet.IsVisible = false;
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
                               stkDetailsChalet.IsVisible = true;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = false;
                       stkContactInformation.IsVisible = false;
            }
            else if (stkPrice.IsVisible == true || PriceChalets.IsVisible == true)
            {
                stkBasic.IsVisible = false;
                StkAddress.IsVisible = false;
                               viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 4).FirstOrDefault();
                stkDetailsChalet.IsVisible = false;
                stkPhoto.IsVisible = true;
                PriceChalets.IsVisible = false;
                stkAdvertise.IsVisible = false;
                stkContactInformation.IsVisible = false;
            }
            else if (stkAdvertise.IsVisible==true)
            {
                if (PropertyType == 3 && viewModel.AdvertisementModel.AgreementStatus == 2)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                    stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = true;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                   
            }
            else if (stkContactInformation.IsVisible == true)
            {
                stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                        stkDetailsChalet.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = false;
                PriceChalets.IsVisible = false;
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
                stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = true;
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
                if (string.IsNullOrEmpty(viewModel.AdvertisementModel.Title) && viewModel.AdvertisementModel.AgreementStatus == 0)
                {
                    stkBasic.IsVisible = true;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
                    stkDetailsChalet.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = true;
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
                    stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = true;
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
                    stkDetailsChalet.IsVisible = false;
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
                        stkBasic.IsVisible = false;
                        StkAddress.IsVisible = false;
                        viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 5).FirstOrDefault();
                        stkDetailsChalet.IsVisible = false;
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
                        stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = true;
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
                    stkDetailsChalet.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
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
                        stkDetailsChalet.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = true;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                        stkContactInformation.IsVisible = false;
                   
                   
                }
                else
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                    stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                    stkContactInformation.IsVisible = false;
                }
                else if (viewModel.AdvertisementModel.GovernorateId == 0)
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = true;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 2).FirstOrDefault();
                    stkDetailsChalet.IsVisible = false;
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
                            stkDetailsChalet.IsVisible = true;
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
                    stkDetailsChalet.IsVisible = false;
                    stkPhoto.IsVisible = false;
                    stkPhoto.IsVisible = true;
                    stkPrice.IsVisible = false;
                    PriceChalets.IsVisible = false;
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
                        stkDetailsChalet.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPhoto.IsVisible = false;
                        stkPrice.IsVisible = true;
                    PriceChalets.IsVisible = false;
                    stkAdvertise.IsVisible = false;
                        stkContactInformation.IsVisible = false;
                   
                }
                else if (string.IsNullOrEmpty(viewModel.AdvertisementModel.AdvertiseMakerName))
                {
                    stkBasic.IsVisible = false;
                    StkAddress.IsVisible = false;
                    viewModel.SelectedSeekerpropertyName = viewModel.SeekerPropertyName.Where(x => x.Id == 6).FirstOrDefault();
                    stkDetailsChalet.IsVisible = false;
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
                    stkDetailsChalet.IsVisible = false;
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
            try
            {
                var picker = (ComboBoxEdit)sender;
                var selectedItem = Convert.ToInt32(picker.SelectedItem);
                if (selectedItem == 1)
                {
                    viewModel.AdvertisementModel.NumOfMonths = selectedItem;
                  //  stkOneMonth.IsVisible = true;
                   // stkTwo.IsVisible = false;
                }
                else
                {
                    viewModel.AdvertisementModel.NumOfMonths = selectedItem;
                    //stkOneMonth.IsVisible = true;
                   // stkTwo.IsVisible = true;
                    DateTime today = DateTime.Today;
                    int nextMonth = today.AddMonths(1).Month;
                   // dateNext.Month = nextMonth;
                   // dateNext.IsVisible = false;
                   // calendarNext.SelectedDates = viewModel.NextSelectedDates;

                }
            }
            catch (Exception ex)
            {

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

        private void calendar_SelectionChanged(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            try
            {
                var dd = (Syncfusion.SfCalendar.XForms.SfCalendar)sender;
                var calendar = e.Calendar.SelectedDates;
              //  var dates = viewModel.SelectedDates;
               // viewModel.SelectedDates = null;
               // viewModel.SelectedDates = dates;
                //foreach (var item in e.Calendar.SelectedDates)
                //{
                //    if (viewModel.SelectedDates.Count > 0)
                //    {
                //        foreach (var SelectedDat in viewModel.SelectedDates.Distinct())
                //        {
                //            if(item.Day != SelectedDat.Day)
                //            {
                //                viewModel.SelectedDates.Add(item);
                //            }

                //        }
                //    }
                //    else
                //    {
                //        viewModel.SelectedDates.Add(item);
                //    }

                //}
            }
            catch (Exception ex)
            {

            }
            
             
        }

        private void calendar_SelectionChanged_1(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
           // var dates = viewModel.NextSelectedDates;
           // viewModel.NextSelectedDates = null;
           // viewModel.NextSelectedDates = dates;
            //try
            //{
            //    if (viewModel.NextSelectedDates.Count > 0)
            //    {
            //        e.DateAdded.Where(x => !viewModel.NextSelectedDates.Any(b => b == x)).ToList()
            //              .ForEach(async item =>
            //              {
            //                  viewModel.NextSelectedDates.Add(item);

            //              });

            //        viewModel.NextSelectedDates.Where(x => !e.DateAdded.Any(b => b == x)).ToList()
            //                     .ForEach(async item =>
            //                     {
            //                         viewModel.NextSelectedDates.Remove(item);
            //                     });
            //    }
            //    else
            //    {
            //        viewModel.NextSelectedDates.Add(e.DateAdded.FirstOrDefault());
            //    }




            //}
            //catch (Exception ex)
            //{

            //}

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