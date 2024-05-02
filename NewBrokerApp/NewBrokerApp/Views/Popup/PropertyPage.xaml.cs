using NewBrokerApp.Models;
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
    public partial class PropertyPage : PopupPage
    {
        TaskCompletionSource<string> ChooseCompletionTask;
        public PropertyPage(TaskCompletionSource<string> ChooseCompletionTask)
        {
            InitializeComponent();
            this.ChooseCompletionTask = ChooseCompletionTask;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var id =((Label) (sender as StackLayout).Children.ElementAt(0)).Text;
            ChooseCompletionTask.TrySetResult(id);
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}