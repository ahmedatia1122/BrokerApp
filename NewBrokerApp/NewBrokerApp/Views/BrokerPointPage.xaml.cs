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
	public partial class BrokerPointPage : ContentPage
	{
		AddsViewModel viewModel;
		public BrokerPointPage ()
		{
			InitializeComponent ();
			BindingContext=viewModel=new AddsViewModel();
			viewModel.LoadAdvertismentPointsCommand.Execute(this);
			stkFooter.Children.Add(new Footer("",this));
		}
	}
}