using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.PropertiesAds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPropertyPage : ContentPage
    {
        PropertyViewModel viewModel;
        public SearchPropertyPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new PropertyViewModel();
            viewModel.LoadPropertyPriceCommand.Execute(true);
            viewModel.LoadPropertyNumbersCommand.Execute(true);
            viewModel.LoadPropertyFinishedSearchCommand.Execute(true);
            viewModel.LoadPropertyTypesSearchCommand.Execute(true);
            viewModel.LoadPropertyCitiesSearchCommand.Execute(true);
            //viewModel.LoadPricesCommand.Execute(true);
            //viewModel.LoadAreasCommand.Execute(true);
          //  comPrpertyType.TextHorizontalAlignment= Constants.SelectedIndex == 1?TextAlignment.End:TextAlignment.Start;
           // comPrpertyCity.TextHorizontalAlignment= Constants.SelectedIndex == 1?TextAlignment.End:TextAlignment.Start;



        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Constants.Rooms = (e.CurrentSelection.FirstOrDefault() as DefinitionModel).Id;
        }

        private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Constants.FinishedId = (e.CurrentSelection.FirstOrDefault() as DefinitionModel).Id;
        }
       

        

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Constants.Parking = e.Value;
        }

        private void CheckBox_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {
            Constants.Furnished = e.Value;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
            Constants.CityId = viewModel.SelectCity != null? viewModel.SelectCity.Id:0;
            Constants.PropertyType = viewModel.SelectedProperty !=null? viewModel.SelectedProperty.Id:0;
            Constants.AreaFrom = viewModel.AreaFrom > 0 ?viewModel.AreaFrom.Value : 0;
            Constants.AreaTo = viewModel.AreaTo > 0 ? viewModel.AreaTo.Value : 0;
            Constants.PriceFrom = viewModel.PriceFrom > 0 ? viewModel.PriceFrom.Value : 0;
            Constants.PriceTo = viewModel.PriceTo > 0 ? viewModel.PriceTo.Value : 0;
            Constants.Street=txtStreet.Text;
            Constants.SearchPropetry = true;
            Shell.Current.Navigation.PopAsync();
        }


        private void CollectionView_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            var item = e.CurrentSelection.FirstOrDefault() as DefinitionModel;
            Constants.ArgmentStatus = item.Id;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Constants.Street = null;
            Constants.ArgmentStatus = 0;
            Constants.Parking = null;
            Constants.PropertyType = 0;
            Constants.PriceFrom = 0;
            Constants.PriceTo = 0;
            Constants.CityId = 0;
            Constants.Furnished = null;
            Constants.FinishedId = 0;


            Shell.Current.Navigation.PopAsync();
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new AppShell();
            // true or false to disable or enable the action
            return base.OnBackButtonPressed();
        }
    }
}