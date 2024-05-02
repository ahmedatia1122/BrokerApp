using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Controls;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SelectionChangedEventArgs = Xamarin.Forms.SelectionChangedEventArgs;

namespace NewBrokerApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        PropertyViewModel viewModel;
        public HomePage ()
		{
			InitializeComponent ();
            Constants.NavigationParamter = "131277";
            var propertyType = Constants.AdvertisementParamter as Advertisement;
          //  PropertyType = Convert.ToInt32(propertyType.TypeId);
            BindingContext = viewModel = new PropertyViewModel();
          //  lblTitle.Text = AppResources.Edit + " " + propertyType.Type;
            BindingContext = viewModel = new PropertyViewModel();
            viewModel.Type = 1;
            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    viewModel.LoadPropertyStatusCommand.Execute(true);
            //    viewModel.LoadPropertyPriceCommand.Execute(true);
            //    viewModel.LoadPropertyNumbersCommand.Execute(true);
            //    viewModel.LoadPropertyPersonTitleCommand.Execute(true);
            //    viewModel.LoadPropertyPersonTypeCommand.Execute(true);
            //    viewModel.LoadPropertyGovernmentsCommand.Execute(true);
            //    viewModel.LoadPropertyCitiesCommand.Execute(true);
            //    viewModel.LoadPropertyDocumentCommand.Execute(true);
            //    viewModel.LoadPropertyFinishedCommand.Execute(true);
            //    viewModel.ChoosePropertyFacilitiesCommand.Execute(true);
            //    viewModel.LoadPropertyPaymentFacilityCommand.Execute(true);
            //    viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
            //    viewModel.AdvertiseForEditCommand.Execute(true);
            //    Col_Payment.ItemsSource = viewModel.PropertyPaymentFacaility;

            //});
            //var   PropertyPaymentFacaility = new List<DefinitionModel>();
            //  var PropertyPaymentFacilityItems = new List<DefinitionModel>()
            //  {
            //      new DefinitionModel { Id = 1, Name = AppResources.Allowed},
            //      new DefinitionModel { Id = 2, Name = AppResources.NotAllowed},
            //  };
            //  PropertyPaymentFacaility.AddRange(PropertyPaymentFacilityItems);
            viewModel.LoadPropertyPaymentFacilityCommand.Execute(true);
            viewModel.LoadPropertyPaymentRentFacilityCommand.Execute(true);
            viewModel.AdvertiseForEditCommand.Execute(true);
            // Col_Payment.ItemsSource = viewModel.PropertyPaymentFacaility;
            stkFooter.Children.Add(new Footer("home", this));

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

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
			await Shell.Current.Navigation.PushAsync(new BasicPropertyPage());
        }
    }
}