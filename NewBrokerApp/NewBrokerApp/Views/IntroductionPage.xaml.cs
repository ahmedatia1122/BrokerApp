using NewBrokerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroductionPage : ContentPage
    {
        OnBoardingViewModel viewmodel = new OnBoardingViewModel();
        public IntroductionPage()
        {
            InitializeComponent();
            BindingContext= viewmodel;
        }
    }
}