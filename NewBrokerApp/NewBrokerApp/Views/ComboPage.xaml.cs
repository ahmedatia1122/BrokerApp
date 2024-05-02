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
    public partial class ComboPage : ContentPage
    {
        PropertyViewModel viewModel;
        public ComboPage()
        {
            InitializeComponent();
            BindingContext = viewModel=new PropertyViewModel();
            viewModel.LoadPropertyGovernmentsCommand.Execute(this);
        }

        private void calendar_DateSelectionChanged(object sender, EventArgs e)
        {

        }
    }
}