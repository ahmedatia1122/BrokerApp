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
    public partial class AddProjectPage : ContentPage
    {
        ProjectViewModel viewModel;
        public AddProjectPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProjectViewModel();
            viewModel.LoadAllProjectCommand.Execute(true);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new ProjectInfoPage());
        }
        private async void TapGestureRecognizer_Tapped_3 (object sender, EventArgs e)
        {
            var model = ((CachedImage)sender).BindingContext as ProjectModel;
            Constants.NavigationProject = model.Id;
            var data = await waitForDeletePopup();
            if (data == true)
            {
                viewModel.LoadDeletedProjectCommand.Execute(true);
            }
        }

        private async Task<bool> waitForDeletePopup()
        {
            var tcs = new TaskCompletionSource<bool>();
            await PopupNavigation.Instance.PushAsync(new DeleteProjectPopUp(tcs));
            return await tcs.Task;
        }

    }
}