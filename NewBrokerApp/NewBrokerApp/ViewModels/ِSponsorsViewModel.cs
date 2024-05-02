using Acr.UserDialogs;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using NewBrokerApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewBrokerApp.ViewModels
{
    public class SponsorsViewModel : BaseViewModel
    {
        public Command SponsorsCommand { get; }
        private ObservableCollection<SponsorModel> _sponsorsItem;
        public ObservableCollection<SponsorModel> SponsorsItem
        {
            get { return _sponsorsItem; }
            set { SetProperty(ref _sponsorsItem, value); }
        }
        public SponsorsViewModel()
        {
            SponsorsItem = new ObservableCollection<SponsorModel>();
            SponsorsCommand = new Command(async () => await ExecuteSponsorsCommand());
          

        }
        private async Task ExecuteSponsorsCommand()
        {

            try
            {
                if (IsBusy) return;
                IsBusy = true;
                ListLength = 15;
                ItemTreshold = 1;
                if (PageIndex == 0)
                {
                    SponsorsItem.Clear();
                }

                var res = await WebService.GetAllSponsors();
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    foreach (var item in res.Result.Sponsors)
                    {

                        SponsorsItem.Add(item);
                    }
                }
                
              

            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }


    }
}
