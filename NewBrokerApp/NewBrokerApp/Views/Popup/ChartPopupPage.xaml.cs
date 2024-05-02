using Microcharts;
using NewBrokerApp.Helpers;
using NewBrokerApp.Resources;
using NewBrokerApp.Services;
using NewBrokerApp.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace NewBrokerApp.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartPopupPage : PopupPage
    {
        
        AddsViewModel viewModel;
    
        public ChartPopupPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AddsViewModel();
            txtTitle.Text = Constants.title;
            viewModel.LoadDataChartCommand.Execute(true);
        }
        
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}