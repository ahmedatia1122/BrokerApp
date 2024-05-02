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
	public partial class SponsorPage : ContentPage
	{
        //ItemsViewModel viewModel = new ItemsViewModel();
        SponsorsViewModel viewModel = new SponsorsViewModel();
        public SponsorPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel;
            //viewModel.LoadItemsCommand.Execute(true);
            viewModel.SponsorsCommand.Execute(true);
            stkFooter.Children.Add(new Footer("", this));
        }
	}
}