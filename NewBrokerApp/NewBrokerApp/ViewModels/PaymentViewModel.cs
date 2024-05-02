using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using NewBrokerApp.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace NewBrokerApp.ViewModels
{
    public class PaymentViewModel : BaseViewModel
    {
        public Command LoadDurationCommand { get; }
        public Command LoadFeatureCommand { get; }
        public Command LoadDurationProjectCommand { get; }
        public ObservableCollection<DurationModel> _durationModel;
        public ObservableCollection<DurationModel> DurationItems
        {
            get { return _durationModel; }
            set { SetProperty(ref _durationModel, value); }
        }
        private DefinitionModel _featureModel;
        public DefinitionModel FeatureModel
        {
            get { return _featureModel; }
            set { SetProperty(ref _featureModel, value); }
        }
        private PackageModel _packageDetailsItem;
        public PackageModel PackageDetailsItem
        {
            get
            {
                return _packageDetailsItem;
            }
            set => SetProperty(ref _packageDetailsItem, value);

        }

        public string Keyword { get; set; }
        public int Type { get; set; }
        public Command LoadGetCompanyPackageDetailsCommand { get; }
        public PaymentViewModel()
        {
            PackageDetailsItem=new PackageModel();
            DurationItems =new ObservableCollection<DurationModel>();
            FeatureModel=new DefinitionModel();
            LoadDurationCommand = new Command(async () => { await ExecuteAllDurationsListCommand(); });
            LoadDurationProjectCommand = new Command(async () => { await ExecuteAllDurationsListProjectCommand(); });
            LoadFeatureCommand = new Command(async () => { await ExecuteAllFeatureListCommand(); });
            LoadGetCompanyPackageDetailsCommand = new Command(async () => { await ExecuteGetCompanyPackageDetailsCommand(); });

        }
        private async Task ExecuteGetCompanyPackageDetailsCommand()
        {
            try
            {
                var res = await WebService.GetCompanyPackageDetails(Convert.ToInt64(Constants.UserId));
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    PackageDetailsItem = res.Result.Details;
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
        private async Task ExecuteAllFeatureListCommand()
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                Device.BeginInvokeOnMainThread(async() => {
                    var res = await WebService.GetDefinitionList(new DefinitionsInputModel { Keyword = Keyword, Type = Type, Start = PageIndex * ListLength, Length = ListLength });
                    if (!res.Success)
                        ShowMessege(AppResources.Alert, res?.Error);
                    else if (res?.Result?.Success != true)
                    {
                        ShowMessege(AppResources.Alert, res?.Result?.Error);
                    }
                    else if (res?.Result?.Success == true)
                    {
                        FeatureModel = res.Result.Definitions[0];

                    }
                });
                

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
        private async Task ExecuteAllDurationsListCommand()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                if (IsBusy) return;
                IsBusy = true;
                DurationItems.Clear();
                var res = await WebService.GetAllDurations(new DurationsInputModel {Type=(Constants.NavigationParamter as DefinitionModel).Id,IsPublish=true });
                var Feature = await WebService.GetDefinitionList(new DefinitionsInputModel { Keyword = Keyword, Type = 9, Start = PageIndex * ListLength, Length = ListLength });

                foreach (var item in res.Result.Durations)
                {
                    DurationItems.Add(item);
                }
                if (!Feature.Success)
                    ShowMessege(AppResources.Alert, Feature?.Error);
                else if (Feature?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, Feature?.Result?.Error);
                }
                else if (Feature?.Result?.Success == true)
                {
                    FeatureModel = Feature.Result.Definitions[0];
                  
                }
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
                IsBusy = false;
            }


        }
        private async Task ExecuteAllDurationsListProjectCommand()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                if (IsBusy) return;
                IsBusy = true;
                DurationItems.Clear();
                var res = await WebService.GetAllDurations(new DurationsInputModel { Type = 1, IsPublish = true });
                var Feature = await WebService.GetDefinitionList(new DefinitionsInputModel { Keyword = Keyword, Type = 9, Start = PageIndex * ListLength, Length = ListLength });

                foreach (var item in res.Result.Durations)
                {
                    DurationItems.Add(item);
                }
                if (!Feature.Success)
                    ShowMessege(AppResources.Alert, Feature?.Error);
                else if (Feature?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, Feature?.Result?.Error);
                }
                else if (Feature?.Result?.Success == true)
                {
                    FeatureModel = Feature.Result.Definitions[0];

                }
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
                IsBusy = false;
            }


        }

    }
}
