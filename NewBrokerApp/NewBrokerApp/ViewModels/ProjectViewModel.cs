using NewBrokerApp.Helpers;
using NewBrokerApp.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using NewBrokerApp.Models;
using System.Collections.ObjectModel;
using NewBrokerApp.Views;
using Plugin.Media.Abstractions;
using System.Net.Http;
using System.IO;
using Rg.Plugins.Popup.Services;
using Acr.UserDialogs;
using DevExpress.Mvvm.Native;
using System.Linq;
using NewBrokerApp.Views.Company;

namespace NewBrokerApp.ViewModels
{
    public class ProjectViewModel : BaseViewModel
    {
        public Command LoadAllProjectCommand { get; }
        public Command LoadDeletedProjectCommand { get; }
        public Command LoadGetProjectDetailsCommand { get; }
        public Command OpenAddDetailsCommand { get; }
        public Command OpenProjectDetailsCommand { get; }
        public Command ChangeProjectStatusCommand { get; }
        public Command OpenProjectAdEditDetailsCommand { get; }
        public Command OpenDeleteAddCommand { get; }
        public Command LoadEditProjectCommand { get; }
        public Command PaymentProjectCommand { get; }
        public Command DurationToProjectAdsCommand { get; }
        public Command GetLatestAdvertiseIdCommand { get; }
        public long LastAdvertiseId { get; set; }
        // public string LastAdvertise{ get; set; }
        private string _lastAdvertise;
        public string LastAdvertise
        {
            get => _lastAdvertise;
            set
            {
                this._lastAdvertise = value;
                this.OnPropertyChanged("LastAdvertise");
            }
            // set => SetProperty(ref _nextSelectedDates, value);
        }
        public long AdId { get; set; }
        public ProjectModel _projectDetailsItem;
        public ProjectModel ProjectDetailsItem
        {
            get { return _projectDetailsItem; }
            set
            {
                SetProperty(ref _projectDetailsItem, value);
            }
        }
        public int _heightRequest;
        public int  HeightRequest
        {
            get { return _heightRequest; }
            set
            {
                SetProperty(ref _heightRequest, value);
            }
        } 
        public bool _showCreatProject;
        public bool ShowCreatProject
        {
            get { return _showCreatProject; }
            set
            {
                SetProperty(ref _showCreatProject, value);
            }
        }
        public bool _showListProject;
        public bool ShowListProject
        {
            get { return _showListProject; }
            set
            {

                _showListProject = value;
                OnPropertyChanged("ShowListProject");
            }
            //set
            //{
            //    SetProperty(ref _showListProject, value);
            //}
        }
        public bool _isEnabledPayment;
        public bool IsEnabledPayment
        {
            get { return _isEnabledPayment; }
            set
            {
                _isEnabledPayment = value;
                OnPropertyChanged("IsEnabledPayment");
                //SetProperty(ref _isEnabledPayment, value);
            }
        }
        public ObservableCollection<ProjectModel> _projectsItems;
        public ObservableCollection<ProjectModel> ProjectsItems
        {
            get { return _projectsItems; }
            set { SetProperty(ref _projectsItems, value); }
        }
        
        private ObservableCollection<string> _propertyPhotos;
        public ObservableCollection<string> PropertyPhotos
        {
            get { return _propertyPhotos; }
            //set { SetProperty(ref _propertyPhotos, value); }
            set
            {

                _propertyPhotos = value;
                OnPropertyChanged("PropertyPhotos");
            }
        }
        private ObservableCollection<string> _propertyPhotosNext;
        public ObservableCollection<string> PropertyPhotosNext
        {
            get { return _propertyPhotosNext; }
            set
            {

                _propertyPhotosNext = value;
                OnPropertyChanged("PropertyPhotosNext");
            }
        }
        private ObservableCollection<string> _propertyLayouts;
        public ObservableCollection<string> PropertyLayouts
        {
            get { return _propertyLayouts; }
            set { SetProperty(ref _propertyLayouts, value); }
        }
        private ObservableCollection<string> _propertyLayoutNext;
        public ObservableCollection<string> PropertyLayoutNext
        {
            get { return _propertyLayoutNext; }
            set
            {

                _propertyLayoutNext = value;
                OnPropertyChanged("_propertyLayoutNext");
            }
        }
        public ObservableCollection<AdvertisementModel> _addsItems;
        public ObservableCollection<AdvertisementModel> AddsItems
        {
            get { return _addsItems; }
            set
            {

                _addsItems = value;
                OnPropertyChanged();
            }
            //set { SetProperty(ref _addsItems, value); }
        }
        //public AdvertisementModel _advertisementItems;
        //public AdvertisementModel AdvertisementItems
        //{
        //    get { return _advertisementItems; }
        //    set
        //    {
        //        SetProperty(ref _advertisementItems, value);
        //    }
        //}
        public ProjectViewModel()
        {
            ProjectsItems = new ObservableCollection<ProjectModel>();
         
            AddsItems = new ObservableCollection<AdvertisementModel>();
            PropertyPhotos = new ObservableCollection<string>();
            PropertyPhotosNext = new ObservableCollection<string>();
            PropertyLayouts = new ObservableCollection<string>();
            PropertyLayoutNext = new ObservableCollection<string>();
            ProjectDetailsItem = new ProjectModel();
            LoadAllProjectCommand = new Command(async () => { await ExecuteGetAllProjectCommand(); });
          
            LoadEditProjectCommand = new Command(async () => { await ExecuteEditProjectCommand(); });
            OpenAddDetailsCommand = new Command(async () => await ExecuteOpenAddDetailCommand());
            LoadDeletedProjectCommand = new Command(async () => await ExecuteDeletedProjectCommand());
            LoadGetProjectDetailsCommand = new Command(async () => await ExecuteGetProjectDetailsCommand());
            OpenProjectDetailsCommand = new Command<ProjectModel>(async (item) => await ExecuteOpenProjectDetailCommand(item));
            ChangeProjectStatusCommand = new Command<AdvertisementModel>(async (item) => await ExecuteChangeAddProjectStatusCommand(item));
            OpenProjectAdEditDetailsCommand = new Command<AdvertisementModel>(async (item) => await ExecuteOpenEditDetailCommand(item));
            OpenDeleteAddCommand = new Command(async () => await ExecuteOpenDeleteAddCommand());
            PaymentProjectCommand = new Command(async () => { await ExecutePaymentProjectCommand(); });
            DurationToProjectAdsCommand = new Command(async () => { await ExecuteDurationToProjectAdsCommand(); });
            GetLatestAdvertiseIdCommand = new Command(async () => { await ExecuteGetLatestAdvertiseId(); });

        }
        private async Task ExecuteOpenProjectDetailCommand(ProjectModel item)
        {
            Constants.NavigationProject = item.Id;
            await Shell.Current.Navigation.PushAsync(new Views.Company.EditProjectPage());
        }

        private async Task ExecuteOpenAddDetailCommand()
        {
            ProjectDetailsItem.CompanyId = Constants.CompanyId;
            foreach (var item in ProjectDetailsItem.MediaFiles)
            {
                ProjectDetailsItem.PhotosList.Add(await uploadFile(item));
            }
            foreach (var item in ProjectDetailsItem.MediaFilesLayout)
            {
                ProjectDetailsItem.LayoutsList.Add(await uploadFile(item));
            }
            Constants.NavigationProject = ProjectDetailsItem;
            await Shell.Current.Navigation.PushAsync(new Views.PropertiesAds.PropertyTypesPage());

        }

        private async Task ExecuteEditProjectCommand()
        {
            try
            {
                var PhotoList = new List<string>();
                var LayoutList = new List<string>();
                foreach (var item in PropertyPhotos)
                {
                    if (!item.Contains("AddPhoto"))
                    {
                        PhotoList.Add(await CheckPhoto(item));
                    }
                }
                foreach (var item in PropertyPhotosNext)
                {
                    if (!item.Contains("AddPhoto"))
                    {
                        PhotoList.Add(await CheckPhoto(item));
                    }
                }
                foreach (var item in PropertyLayouts)
                {
                    if (!item.Contains("AddPhoto"))
                    {
                        LayoutList.Add(await CheckPhoto(item));
                    }
                }
                foreach (var item in PropertyLayoutNext)
                {
                    if (!item.Contains("AddPhoto"))
                    {
                        LayoutList.Add(await CheckPhoto(item));
                    }
                }
               
                ProjectDetailsItem.PhotosList = PhotoList;
                ProjectDetailsItem.LayoutsList = LayoutList;
                var res = await WebService.ManagaProject(ProjectDetailsItem);
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    ShowMessege(AppResources.Alert, AppResources.SuccessFully);
                    Application.Current.MainPage = new AppShell();
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
        private async Task ExecuteGetAllProjectCommand()
        {
            try
            {
                var res = await WebService.GetAllProjectForCompanyId();
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    ProjectsItems.Clear();
                    foreach (var item in res.Result.Projects)
                    {
                        

                        ProjectsItems.Add(item);
                    }
                    
                    if (res.Result.Projects.Count == 0)
                    {
                       
                        ShowCreatProject = true;
                        ShowListProject = false;
                    }
                    else
                    {
                        ShowCreatProject = false;
                        ShowListProject = true;
                        HeightRequest = (res.Result.Projects.Count * 60) + 5;
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
        private async Task ExecuteDeletedProjectCommand()
        {
            try
            {
                var res = await WebService.DeleteProject(Convert.ToInt64(Constants.NavigationProject.ToString()));
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Msg);
                    LoadAllProjectCommand.Execute(true);
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
        private async Task ExecuteGetProjectDetailsCommand()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                        var project = await WebService.GetProjectDetails(Convert.ToInt64(Constants.NavigationProject));
                        if (!project.Success)
                            ShowMessege(AppResources.Alert, project?.Error);
                        else if (project?.Result?.Success != true)
                        {
                            ShowMessege(AppResources.Alert, project?.Result?.Error);
                        }
                        else if (project?.Result?.Success == true)
                        {
                            ProjectDetailsItem = project.Result.Details;
                    foreach(var item in ProjectDetailsItem.PhotosList.Take(3))
                        {
                        PropertyPhotos.Add(item);
                    }
                    foreach (var item in ProjectDetailsItem.PhotosList.Skip(3))
                    {
                        PropertyPhotosNext.Add(item);
                    }
                    foreach (var item in ProjectDetailsItem.LayoutsList.Take(3))
                    {
                        PropertyLayouts.Add(item);
                    }
                    foreach (var item in ProjectDetailsItem.LayoutsList.Skip(3))
                    {
                        PropertyLayoutNext.Add(item);
                    }
                    AddsItems.Clear();
                    foreach (var item in project.Result.Details.Advertisements)
                    {
                        item.IsImage = item.IsPublish == true ? "stop" : "playy";
                        AddsItems.Add(item);
                    }
                    if (project.Result.Details.Advertisements.Count == 0)
                    {
                        HeightRequest = 0;
                    }
                    else
                    {
                        HeightRequest = (project.Result.Details.Advertisements.Count * 60) + 5;
                    }
                    var data = AddsItems.Where(x => x.IsPublish == false).ToList();
                    if (data.Count > 0)
                    {
                        IsEnabledPayment = true;
                    }
                    else
                    {
                        IsEnabledPayment = false;
                    }
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
        private async Task ExecuteChangeAddProjectStatusCommand(AdvertisementModel item)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var res = await WebService.ChangeAddStatus(item.Id);
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var advertise = await WebService.GetAdvertiseForEdit(item.Id);
                        if (!advertise.Success)
                            ShowMessege(AppResources.Alert, advertise?.Error);
                        else if (advertise?.Result?.Success != true)
                        {
                            ShowMessege(AppResources.Alert, advertise?.Result?.Error);
                        }
                        else if (advertise?.Result?.Success == true)
                        {
                            Constants.NavigationAdvertiserModel = advertise.Result.Advertisement;
                            Constants.NavigationParamter = new DefinitionModel { Id = advertise.Result.Advertisement.Type };
                            await Shell.Current.Navigation.PushAsync(new PaymentCompanyPage());
                        }
                    });

                    // await PopupNavigation.Instance.PopAsync();
                    UserDialogs.Instance.HideLoading();
                }
                else if (res?.Result?.Success == true)
                {
                    LoadGetProjectDetailsCommand.Execute(true);
                }
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
        private async Task ExecuteOpenEditDetailCommand(AdvertisementModel item)
        {
            Constants.NavigationParamter = item.Id;
            Constants.AdvertisementParamter = item;
            Constants.NavigationProject = item;
            await PropertyType(item.Type);
            switch (item.Type)
                {
                    case 1:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditApartmentDetailsPage());
                        break;
                    case 2:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditVillaDetailsPage());
                        break;
                    case 3:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditChaletDetailsPage());
                        break;
                    case 4:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditBuildingDetailsPage());
                        break;
                    case 5:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditAdminOfficeDetailsPage());
                        break;
                    case 6:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditShopDetailsPage());
                        break;
                    case 7:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.EditLandDetailsPage());
                        break;
                
            }
        }
        public async Task PropertyType(int TypeId)
        {
            Advertisement item = new Advertisement();
            var propertyType = Constants.AdvertisementParamter as AdvertisementModel;
            switch (TypeId)
            {
                case 1:
                    propertyType.TypeName = "Apartment"; break;
                case 2:
                    propertyType.TypeName = "Villa"; break;
                case 3:
                    propertyType.TypeName = "ChaletForSummer"; break;
                case 4:
                    propertyType.TypeName = "Building"; break;
                case 5:
                    propertyType.TypeName = "AdminOffice"; break;
                case 6:
                    propertyType.TypeName = "Shop"; break;
                case 7:
                    propertyType.TypeName = "Land"; break;
            }
            item.Id = propertyType.Id;
            item.TypeId = TypeId;
            item.Type = propertyType.TypeName;
            Constants.AdvertisementParamter = item;
        }
        private async Task ExecuteOpenDeleteAddCommand()
        {
            try
            {
                var res = await WebService.DeleteAdd(AdId);
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    LoadGetProjectDetailsCommand.Execute(true);
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
        //private async Task ExecuteDurationToProjectAdsCommand()
        //{
        //    try
        //    {
        //        var res = await WebService.DurationToProjectAds();
        //        if (!res.Success)
        //            ShowMessege(AppResources.Alert, res?.Error);
        //        else if (res?.Result?.Success != true)
        //        {
        //            ShowMessege(AppResources.Alert, res?.Result?.Error);
        //        }
        //        else if (res?.Result?.Success == true)
        //        {
        //            await Shell.Current.Navigation.PushAsync(new AddProjectPage());
        //            Constants.NavigationProject = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IsBusy = false;
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}
        private async Task ExecuteDurationToProjectAdsCommand()
        {
            try
            { 
                var data = Constants.NavigationProject as ProjectModel;
                data.AdvertisementsInput = new List<long>();
                foreach (var item in data.Advertisements)
                {
                    data.AdvertisementsInput.Add(item.Id);
                }
                
                var res = await WebService.PlaceDurationToAds(data);
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    await Shell.Current.Navigation.PushAsync(new AddProjectPage());
                    Constants.NavigationProject = null;
                    Constants.PaymentStatus = 0;
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
        private async Task ExecuteGetLatestAdvertiseId()
        {
            try
            {
                Device.BeginInvokeOnMainThread(async () => {
                    var result = await WebService.GetLastAdvertise();
                    if (result.Result.Success != true)
                    {
                        LastAdvertiseId = 0;
                        LastAdvertise = string.Format(AppResources.Adhasbeenactivtedsuccessfully, LastAdvertiseId + 1);
                        //  ShowMessege(AppResources.Alert, result.Result?.Error);
                    }
                    else
                    {
                        LastAdvertiseId = result.Result.Id;
                        LastAdvertise = string.Format(AppResources.Adhasbeenactivtedsuccessfully, LastAdvertiseId + 1);


                    }
                });

            }
            catch (Exception ex)
            {

            }
        }

        async Task<string> CheckPhoto(string photo)
        {
            return photo.Replace("https://brokerapi.nahrdev.website/Resources/UploadFiles/", "");
        }
        private async Task ExecutePaymentProjectCommand()
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                    var data = ProjectDetailsItem.Advertisements.Where(x => x.IsPublish == false).ToList();
                if(data.Count > 0)
                {
                    ProjectDetailsItem.Advertisements = data;
                }
                    Constants.NavigationProject = ProjectDetailsItem;
                   await Shell.Current.Navigation.PushAsync(new PaymentProjectPage());
              
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


