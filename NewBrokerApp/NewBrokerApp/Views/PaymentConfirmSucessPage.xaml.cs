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
    public partial class PaymentConfirmSucessPage : ContentPage
    {
        public PaymentConfirmSucessPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
        }
    }
}