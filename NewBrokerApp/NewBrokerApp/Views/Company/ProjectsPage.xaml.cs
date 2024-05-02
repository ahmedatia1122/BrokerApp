using FFImageLoading.Forms;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Common;
using Rg.Plugins.Popup.Services;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Company
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectsPage : ContentPage
    {
        ProjectViewModel viewModel;
       
        public ProjectsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProjectViewModel();
            
            viewModel.LoadAllProjectCommand.Execute(true);
           // adsViewModel.LoadAddDetailsCommand.Execute(this);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}