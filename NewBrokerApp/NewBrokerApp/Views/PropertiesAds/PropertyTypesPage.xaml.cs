using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace NewBrokerApp.Views.PropertiesAds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyTypesPage : ContentPage
    {
        PropertyViewModel viewModel;
        public PropertyTypesPage()
        {
            InitializeComponent();
            BindingContext= viewModel=new PropertyViewModel();
            viewModel.Type = 10;
            viewModel.LoadPropertyTypesCommand.Execute(true);
            stkFooter.Children.Add(new Footer("addProperty", this));
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }
        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new AppShell();
            // true or false to disable or enable the action
            return base.OnBackButtonPressed();
        }
    }
}