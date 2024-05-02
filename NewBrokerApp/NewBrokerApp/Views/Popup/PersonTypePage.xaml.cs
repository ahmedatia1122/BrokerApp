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
	public partial class PersonTypePage : PopupPage
	{
		PropertyViewModel viewModel;
        TaskCompletionSource<DefinitionModel> ChooseCompletionTask;
        DefinitionModel personTypeModel;
        public PersonTypePage(TaskCompletionSource<DefinitionModel> ChooseCompletionTask)
		{
			InitializeComponent ();
			BindingContext= viewModel=new PropertyViewModel();
			viewModel.LoadPropertyPersonTypeCommand.Execute(true);
            personTypeModel = new DefinitionModel();
            this.ChooseCompletionTask = ChooseCompletionTask;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var data = (sender as StackLayout).BindingContext as DefinitionModel;
            personTypeModel = data;
            ChooseCompletionTask.TrySetResult(personTypeModel);
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
          //  Navigation.PopPopupAsync(true);
           
           
        }
    }
}