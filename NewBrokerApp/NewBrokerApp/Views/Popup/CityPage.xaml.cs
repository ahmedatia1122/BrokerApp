using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
	public partial class CityPage : PopupPage
	{
		PropertyViewModel viewModel;
        TaskCompletionSource<CityModel> ChooseCompletionTask;
        CityModel citymodel;
        public CityPage (TaskCompletionSource<CityModel> ChooseCompletionTask)
		{
			InitializeComponent ();
			BindingContext= viewModel=new PropertyViewModel();
			viewModel.LoadPropertyCitiesCommand.Execute(true);
            citymodel = new CityModel();
            this.ChooseCompletionTask = ChooseCompletionTask;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var data = (sender as StackLayout).BindingContext as  CityModel;
            citymodel = data;
            ChooseCompletionTask.TrySetResult(citymodel);
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
          //  Navigation.PopPopupAsync(true);
           
           
        }
    }
}