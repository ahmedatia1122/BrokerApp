using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewBrokerApp.ViewModels
{
    public class RateUsViewModel : BaseViewModel
    {
        public Command RateUsCommand { get; }

        public RateUsInput _updatRateUsItem;
        public RateUsInput UpdatRateUsItem
        {
            get
            {
                return _updatRateUsItem;
            }
            set => SetProperty(ref _updatRateUsItem, value);

        }
        private int _selectedStarValue;
        public int SelectedStarValue
        {
            get => _selectedStarValue;
            set => SetProperty(ref _selectedStarValue, value);
        }
        public ICommand SelectedStarCommand => new Command<int>((selectedStarValue) =>
        {
            SelectedStarValue = selectedStarValue;
        });
        public RateUsViewModel()
        {
            UpdatRateUsItem = new RateUsInput();
            RateUsCommand = new Command(async () => { await ExecutUpdateRateUsCommand(); });
        }
        private async Task ExecutUpdateRateUsCommand()
        {

            try
            {

                UpdatRateUsItem.UserRate = SelectedStarValue;
                UpdatRateUsItem.UserId = Convert.ToInt64(Constants.UserId);
                var rate = await WebService.CreateRate(UpdatRateUsItem);

                if (!rate.Success)
                    await PopupNavigation.Instance.PopAsync();
                // ShowMessege(AppResources.Alert, rate?.Error);
                else if (rate?.Result?.Success != true)
                {
                    await PopupNavigation.Instance.PopAsync();
                    ShowMessege(AppResources.Alert, rate?.Result?.Error);
                }
                else if (rate?.Result?.Success == true)
                {
                    ShowMessege(AppResources.Alert, AppResources.Thankssharingrating) ;
                    Application.Current.MainPage = new AppShell();
                    await PopupNavigation.Instance.PopAsync();
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
