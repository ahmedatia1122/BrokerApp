using NewBrokerApp.ViewModels;
using NewBrokerApp.Views.Controls;
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
	public partial class NotificationPage : ContentPage
	{
		AccountViewModel viewModel;
		public NotificationPage ()
		{
			InitializeComponent ();
			stkFooter.Children.Add(new Footer("notification", this));
			BindingContext = viewModel=new AccountViewModel ();
			viewModel.LoadAllNotification.Execute(true);
		}
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new AppShell();
            // true or false to disable or enable the action
            return base.OnBackButtonPressed();
        }
    }
}