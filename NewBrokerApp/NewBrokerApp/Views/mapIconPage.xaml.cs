using NewBrokerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mapIconPage : StackLayout
    {
        private Advertisement _model=new Advertisement();

        public mapIconPage(Advertisement model)
        {
            InitializeComponent();
            _model = model;
            BindingContext = this;
            if(_model.IsCompany==true && _model.CompanyLogo!=null) 
            {
                imgCompany.Source = ImageSource.FromUri(new Uri(_model.CompanyLogo));

            }
        }

        public Advertisement Model
        {
            get { return _model; }
        }
    }
}