using NewBrokerApp.Resources;
using NewBrokerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        OnBoardingViewModel viewmodel = new OnBoardingViewModel();
        public LoadingPage()
        {
            InitializeComponent();
            BindingContext = viewmodel;
           
        }
        protected override void OnAppearing()
        {
            viewmodel.InitCommand.Execute(null);
            base.OnAppearing();
        }
    }
}