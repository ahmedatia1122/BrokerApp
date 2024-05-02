using NewBrokerApp.Models;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteAdPopup : PopupPage
    {
        TaskCompletionSource<bool> ChooseTask;
        public DeleteAdPopup(TaskCompletionSource<bool> ChooseCompletionTask)
        {
            InitializeComponent();
            this.ChooseTask = ChooseCompletionTask;
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            ChooseTask.TrySetResult(true);
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}