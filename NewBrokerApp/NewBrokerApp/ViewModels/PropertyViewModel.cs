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
using Rg.Plugins.Popup.Extensions;

namespace NewBrokerApp.ViewModels
{
    public class PropertyViewModel : BaseViewModel
    {
        public Command LoadPropertyTypesCommand { get; }
        public Command LoadPropertyCitiesCommand { get; }
        public Command LoadPropertyCitiesSearchCommand { get; }
        public Command LoadPropertyGovernmentsCommand { get; }
        public Command LoadPropertyNumbersCommand { get; }
        public Command LoadPropertyStatusCommand { get; }
        public Command LoadPropertyFinishedCommand { get; }
        public Command LoadPropertyFinishedSearchCommand { get; }
        public Command LoadPropertyTypesSearchCommand { get; }
        
        public Command LoadPropertyDocumentCommand { get; }
        public Command LoadPropertyPriceCommand { get; }
        public Command LoadPropertyPaymentFacilityCommand { get; }
        public Command LoadPropertyPaymentRentFacilityCommand { get; }
        public Command LoadPropertyPersonTitleCommand { get; }
        public Command LoadPropertyPersonTypeCommand { get; }
        public Command LoadPropertyBuildingUsingCommand { get; }
        public Command LoadPropertyBuildingUnitsCommand { get; }
        public Command LoadPropertyBuildingPartationsCommand { get; }
        public Command LoadPropertyProximityToTheSeaCommand { get; }
        public Command LoadPropertyChaletTypeCommand { get; }
        public Command LoadPropertyStatusTypeForLandCommand { get; }
        public Command LoadPropertyUsingForLandCommand { get; }
        public Command LoadPropertyAdminTypeCommand { get; }
        public Command ChoosePropertyPriceCommand { get; }
        public Command ChoosePropertyFacilitiesCommand { get; }
        public Command SavePropertyInAdsCommand { get; }
        public Command SavePropertyCommand { get; }
        public Command PublishPropertyCommand { get; }
        public Command LoadPricesCommand { get; }
        public Command LoadAreasCommand { get; }
        public Command AdvertiseForEditCommand { get; }
        public Command UpdatePropertyCommand { get; }
        public Command CheckPhoneNumberOtpCommand { get; }
        public Command UpdatePropertyProjectCommand { get; }
        public Command GetLatestAdvertiseIdCommand { get; }
        public Command LoadPropertyMinBookListCommand { get; }
        
        string _keyword;
        public string Keyword
        {
            get { return _keyword; }
            set { SetProperty(ref _keyword, value); }
        }
        public List<DefinitionModel> _propertyTypes;
        public List<DefinitionModel> PropertyTypes
        {
            get { return _propertyTypes; }
            set
            {
                this._propertyTypes = value;
                this.OnPropertyChanged("PropertyTypes");
            }
            //set { SetProperty(ref _propertyTypes, value); }
        }
        public string _prices;
        public string Prices
        {
            get { return _prices; }
            set { SetProperty(ref _prices, value); }
        }
        public string _areas;
        public string Areas
        {
            get { return _areas; }
            set { SetProperty(ref _areas, value); }
        }
        private bool _showMorePhoto;
        public bool ShowMorePhoto
        {
            get { return _showMorePhoto; }
            set { SetProperty(ref _showMorePhoto, value); }
        }
        public ObservableCollection<DefinitionModel> _propertyFacilites;
        public ObservableCollection<DefinitionModel> PropertyFacilites
        {
            get { return _propertyFacilites; }
            set { SetProperty(ref _propertyFacilites, value); }
        }
        public ObservableCollection<DefinitionModel> _propertyMinBook;
        public ObservableCollection<DefinitionModel> PropertyMinBook
        {
            get { return _propertyMinBook; }
            set { SetProperty(ref _propertyMinBook, value); }
        }
        public ObservableCollection<CityModel> _cities;
        public ObservableCollection<CityModel> Cities
        {
            get { return _cities; }
            set { SetProperty(ref _cities, value); }
        }
        public ObservableCollection<GovernmentModel> _governments;
        public ObservableCollection<GovernmentModel> Governments
        {
            get { return _governments; }
            set { SetProperty(ref _governments, value); }
        }
        public CityModel _selectCity;
        public CityModel SelectCity
        {
            get { return _selectCity; }
            set { SetProperty(ref _selectCity, value); }
        }
        public GovernmentModel _selectGovernment;
        public GovernmentModel SelectGovernment
        {
            get { return _selectGovernment; }
            set { 
                SetProperty(ref _selectGovernment, value);
                if (value != null)
                {
                    LoadPropertyCitiesCommand.Execute(null);
                }

            }
        }
        public AdvertisementModel _advertisementModel;
        public AdvertisementModel AdvertisementModel
        {
            get { return _advertisementModel; }
            set { 
                SetProperty(ref _advertisementModel, value);
            }
        }
        public Command ChoosePropertyTypsPageCommand { get; }
        private List<DefinitionModel> _propertyNumbers;
        public List<DefinitionModel> PropertyNumbers
        {
            get { return _propertyNumbers; }
            set
            {
                this._propertyNumbers = value;
                this.OnPropertyChanged("PropertyNumbers");
            }
        }
        private List<DefinitionModel> _propertyStatus;
        public List<DefinitionModel> PropertyStatus
        {
            get { return _propertyStatus; }
            set
            {
                this._propertyStatus = value;
                this.OnPropertyChanged("PropertyStatus");
            }
        }
        private List<DefinitionModel> _propertyFinished;
        public List<DefinitionModel> PropertyFinished
        {
            get { return _propertyFinished; }
            set
            {
                this._propertyFinished = value;
                this.OnPropertyChanged("PropertyFinished");
            }
        }
        private List<DefinitionModel> _propertyDocument;
        public List<DefinitionModel> PropertyDocument
        {
            get { return _propertyDocument; }
            set
            {
                this._propertyDocument = value;
                this.OnPropertyChanged("PropertyDocument");
            }
        }
        private List<DefinitionModel> _propertyPrice;
        public List<DefinitionModel> PropertyPrice
        {
            get { return _propertyPrice; }
            set
            {
                this._propertyPrice = value;
                this.OnPropertyChanged("PropertyPrice");
            }
        }
        private List<DefinitionModel> _propertyPaymentFacaility;
        public List<DefinitionModel> PropertyPaymentFacaility
        {
            get { return _propertyPaymentFacaility; }
            set
            {
                this._propertyPaymentFacaility = value;
                this.OnPropertyChanged();
            }
        }
        private List<DefinitionModel> _propertyPaymentRentFacaility;
        public List<DefinitionModel> PropertyPaymentRentFacaility
        {
            get { return _propertyPaymentRentFacaility; }
            set
            {
                this._propertyPaymentRentFacaility = value;
                this.OnPropertyChanged("PropertyPaymentRentFacaility");
            }
        }
        private List<DefinitionModel> _propertyPersonTitle;
        public List<DefinitionModel> PropertyPersonTitle
        {
            get { return _propertyPersonTitle; }
            set
            {
                this._propertyPersonTitle = value;
                this.OnPropertyChanged("PropertyPersonTitle");
            }
        }
        private List<DefinitionModel> _propertyPersonType;
        public List<DefinitionModel> PropertyPersonType
        {
            get { return _propertyPersonType; }
        
            set
            {
                this._propertyPersonType = value;
                this.OnPropertyChanged("PropertyPersonType");
            }
        }
        private List<DefinitionModel> _propertyBuildingUsing;
        public List<DefinitionModel> PropertyBuildingUsing
        {
            get { return _propertyBuildingUsing; }
            set
            {
                this._propertyBuildingUsing = value;
                this.OnPropertyChanged("PropertyBuildingUsing");
            }
        }
        private List<DefinitionModel> _propertyBuildingUnits;
        public List<DefinitionModel> PropertyBuildingUnits
        {
            get { return _propertyBuildingUnits; }
            set
            {
                this._propertyBuildingUnits = value;
                this.OnPropertyChanged("PropertyBuildingUnits");
            }
        }
        private List<DefinitionModel> _propertyBuildingPartations;
        public List<DefinitionModel> PropertyBuildingPartations
        {
            get { return _propertyBuildingPartations; }
            set
            {
                this._propertyBuildingPartations = value;
                this.OnPropertyChanged("PropertyBuildingPartations");
            }
           
        }
        private List<DefinitionModel> _propertyProximityToTheSea;
        public List<DefinitionModel> PropertyProximityToTheSea
        {
            get { return _propertyProximityToTheSea; }
            set
            {
                this._propertyProximityToTheSea = value;
                this.OnPropertyChanged("PropertyProximityToTheSea");
            }
        }
        private List<DefinitionModel> _propertyChaletType;
        public List<DefinitionModel> PropertyChaletType
        {
            get { return _propertyChaletType; }
            set
            {
                this._propertyChaletType = value;
                this.OnPropertyChanged("PropertyChaletType");
            }
            
        }
        private List<DefinitionModel> _propertyStatusTypeLand;
        public List<DefinitionModel> PropertyStatusTypeLand
        {
            get { return _propertyStatusTypeLand; }
            set
            {
                this._propertyStatusTypeLand = value;
                this.OnPropertyChanged("PropertyStatusTypeLand");
            }
          
        }
        private List<DefinitionModel> _propertyUsingForLand;
        public List<DefinitionModel> PropertyUsingForLand
        {
            get { return _propertyUsingForLand; }
            set
            {
                this._propertyUsingForLand = value;
                this.OnPropertyChanged("PropertyUsingForLand");
            }
            
        }
        private List<DefinitionModel> _propertyAdminOfficeType;
        public List<DefinitionModel> PropertyAdminOfficeType
        {
            get { return _propertyAdminOfficeType; }
            set
            {
                this._propertyAdminOfficeType = value;
                this.OnPropertyChanged("PropertyAdminOfficeType");
            }
        }
        private ObservableCollection<AdvertisementFacilites> _advertisementFacilites;
        public ObservableCollection<AdvertisementFacilites> AdvertisementFacilites
        {
            get { return _advertisementFacilites; }
            set { SetProperty(ref _advertisementFacilites, value); }
        }
        
        private DefinitionModel selectedProperty;
        public DefinitionModel SelectedProperty
        {
            get { return selectedProperty; }
            set
            {
                SetProperty(ref selectedProperty, value);
            }
        }
        private DefinitionModel selectedCity;
        public DefinitionModel SelectedCity
        {
            get { return selectedCity; }
            set
            {
                SetProperty(ref selectedCity, value);
            }
        }
        private DefinitionModel selectedTitle;
        public DefinitionModel SelectedTitle
        {
            get { return selectedTitle; }
            set
            {
                SetProperty(ref selectedTitle, value);
            }
        }
        private DefinitionModel selectedAgreementStatus;
        public DefinitionModel SelectedAgreementStatus
        {
            get { return selectedAgreementStatus; }
            set
            {
                SetProperty(ref selectedAgreementStatus, value);
            }
        }
        private DefinitionModel selectedPropertyStatus;
        public DefinitionModel SelectedPropertyStatus
        {
            get { return selectedPropertyStatus; }
            set
            {
                SetProperty(ref selectedPropertyStatus, value);
            }
        }
        private DefinitionModel selectedLandStatus;
        public DefinitionModel SelectedLandStatus
        {
            get { return selectedLandStatus; }
            set
            {
                SetProperty(ref selectedLandStatus, value);
            }
        }
        private DefinitionModel selectedPropertyFinished;
        public DefinitionModel SelectedPropertyFinished
        {
            get { return selectedPropertyFinished; }
            set
            {
                SetProperty(ref selectedPropertyFinished, value);
            }
        } 
        private DefinitionModel selectedPropertyNumbers;
        public DefinitionModel SelectedPropertyNumbers
        {
            get { return selectedPropertyNumbers; }
            set
            {
                SetProperty(ref selectedPropertyNumbers, value);
            }
        }
        private DefinitionModel selectedPropertyRooms;
        public DefinitionModel SelectedPropertyRooms
        {
            get { return selectedPropertyRooms; }
            set
            {
                SetProperty(ref selectedPropertyRooms, value);
            }
        }
        private DefinitionModel selectedPropertyReception;
        public DefinitionModel SelectedPropertyReception
        {
            get { return selectedPropertyReception; }
            set
            {
                SetProperty(ref selectedPropertyReception, value);
            }
        }
        private DefinitionModel selectedPropertyBalcony;
        public DefinitionModel SelectedPropertyBalcony
        {
            get { return selectedPropertyBalcony; }
            set
            {
                SetProperty(ref selectedPropertyBalcony, value);
            }
        }
        private DefinitionModel selectedPropertyKitchen;
        public DefinitionModel SelectedPropertyKitchen
        {
            get { return selectedPropertyKitchen; }
            set
            {
                SetProperty(ref selectedPropertyKitchen, value);
            }
        }
        private DefinitionModel selectedPropertyToliet;
        public DefinitionModel SelectedPropertyToliet
        {
            get { return selectedPropertyToliet; }
            set
            {
                SetProperty(ref selectedPropertyToliet, value);
            }
        }
        private DefinitionModel selectedPropertyDining;
        public DefinitionModel SelectedPropertyDining
        {
            get { return selectedPropertyDining; }
            set
            {
                SetProperty(ref selectedPropertyDining, value);
            }
        }
        private DefinitionModel selectedPropertyDocument;
        public DefinitionModel SelectedPropertyDocument
        {
            get { return selectedPropertyDocument; }
            set
            {
                SetProperty(ref selectedPropertyDocument, value);
            }
        }
        private DefinitionModel selectedChaletType;
        public DefinitionModel SelectedChaletType
        {
            get { return selectedChaletType; }
            set
            {
                SetProperty(ref selectedChaletType, value);
            }
        }
        private DefinitionModel selectedProximityToTheSea;
        public DefinitionModel SelectedProximityToTheSea
        {
            get { return selectedProximityToTheSea; }
            set
            {
                SetProperty(ref selectedProximityToTheSea, value);
            }
        }
        private DefinitionModel selectedPaymentFacality;
        public DefinitionModel SelectedPaymentFacality
        {
            get { return selectedPaymentFacality; }
            set
            {
                SetProperty(ref selectedPaymentFacality, value);
            }
        }
        private DefinitionModel selectedUsingFor;
        public DefinitionModel SelectedUsingFor
        {
            get { return selectedUsingFor; }
            set
            {
                SetProperty(ref selectedUsingFor, value);
            }
        }
        private DefinitionModel selectedUsingForLand;
        public DefinitionModel SelectedUsingForLand
        {
            get { return selectedUsingForLand; }
            set
            {
                SetProperty(ref selectedUsingForLand, value);
            }
        }
        private DefinitionModel selectedNumUnits;
        public DefinitionModel SelectedNumUnits
        {
            get { return selectedNumUnits; }
            set
            {
                SetProperty(ref selectedNumUnits, value);
            }
        }
        private DefinitionModel selectedNumPartitions;
        public DefinitionModel SelectedNumPartitions
        {
            get { return selectedNumPartitions; }
            set
            {
                SetProperty(ref selectedNumPartitions, value);
            }
        }
        private DefinitionModel selectedOfficies;
        public DefinitionModel SelectedOfficies
        {
            get { return selectedOfficies; }
            set
            {
                SetProperty(ref selectedOfficies, value);
            }
        }
        private DefinitionModel selectedOfficesFloors;
        public DefinitionModel SelectedOfficesFloors
        {
            get { return selectedOfficesFloors; }
            set
            {
                SetProperty(ref selectedOfficesFloors, value);
            }
        }
        private DefinitionModel selectedOfficesNums;
        public DefinitionModel SelectedOfficesNums
        {
            get { return selectedOfficesNums; }
            set
            {
                SetProperty(ref selectedOfficesNums, value);
            }
        }
        private DefinitionModel selectedMinTimeToBookForChaletId;
        public DefinitionModel SelectedMinTimeToBookForChaletId
        {
            get { return selectedMinTimeToBookForChaletId; }
            set
            {
                SetProperty(ref selectedMinTimeToBookForChaletId, value);
            }
        }
        private DefinitionModel selectedLandingStatus;
        public DefinitionModel SelectedLandingStatus
        {
            get { return selectedLandingStatus; }
            set
            {
                SetProperty(ref selectedLandingStatus, value);
            }
        }
        private DefinitionModel selectedPersonType;
        public DefinitionModel SelectedPersonType
        {
            get { return selectedPersonType; }
            set
            {
                SetProperty(ref selectedPersonType, value);
            }
        }
        private decimal? areaFrom;
        public decimal? AreaFrom
        {
            get { return areaFrom; }
            set
            {
                SetProperty(ref areaFrom, value);
            }
        }
        private decimal? areaTo;
        public decimal? AreaTo
        {
            get { return areaTo; }
            set
            {
                SetProperty(ref areaTo, value);
            }
        }
        private decimal? priceFrom;
        public decimal? PriceFrom
        {
            get { return priceFrom; }
            set
            {
                SetProperty(ref priceFrom, value);
            }
        }
        private decimal? priceTo;
        public decimal? PriceTo
        {
            get { return priceTo; }
            set
            {
                SetProperty(ref priceTo, value);
            }
        }
        public int Type { get; set; }
        //public Calendar<CalendarDay> MyCalendar { get; set; } = new Calendar<CalendarDay>();
        private DateTime? _selectedStartDate = DateTime.Today;
        public DateTime? SelectedStartDate
        {
            get => _selectedStartDate;
            set => SetProperty(ref _selectedStartDate, value);
        }
        private DateTime? _selectedMinStartDate = DateTime.Today;
        public DateTime? SelectedMinStartDate
        {
            get => _selectedMinStartDate;
            set => SetProperty(ref _selectedMinStartDate, value);
        }
        private DateTime? _selectedEndDate = DateTime.Today;
        public DateTime? SelectedEndDate
        {
            get => _selectedEndDate;
            set => SetProperty(ref _selectedEndDate, value);
        }
        private DateTime? _nextSelectedStartDate;
        public DateTime? NextSelectedStartDate
        {
            get => _nextSelectedStartDate;
            set => SetProperty(ref _nextSelectedStartDate, value);
        }


        private DateTime? _nextSelectedEndDate ;
        public DateTime? NextSelectedEndDate
        {
            get => _nextSelectedEndDate;
            set => SetProperty(ref _nextSelectedEndDate, value);
        }
        private List<DateTime> _selectedDates;
        public List<DateTime> SelectedDates
        {
            get => _selectedDates;
            set
            {
                this._selectedDates = value;
                this.OnPropertyChanged("SelectedDates");
            }
           // set => SetProperty(ref _selectedDates, value);
        }
        private List<DateTime> _selectedDatesThis;
        public List<DateTime> SelectedDatesThis
        {
            get => _selectedDatesThis;
            set
            {
                this._selectedDatesThis = value;
                this.OnPropertyChanged("SelectedDatesThis");
            }
            // set => SetProperty(ref _selectedDates, value);
        }
        private List<DateTime> _nextSelectedDates;
        public List<DateTime> NextSelectedDates
        {
            get => _nextSelectedDates;
            set
            {
                this._nextSelectedDates = value;
                this.OnPropertyChanged("NextSelectedDates");
            }
           // set => SetProperty(ref _nextSelectedDates, value);
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
        private ObservableCollection<PropertyModel> propertyName;

        public ObservableCollection<PropertyModel> PropertyName
        {
            get { return propertyName; }
            set
            {
                if (propertyName != value)
                {
                    propertyName = value;
                    OnPropertyChanged("PropertyName");
                }
            }
        }
        private PropertyModel selectedpropertyName;

        public PropertyModel SelectedPropertyName
        {
            get { return selectedpropertyName; }
            set { SetProperty(ref selectedpropertyName, value); }
        }
        private ObservableCollection<PropertyModel> seekerpropertyName;

        public ObservableCollection<PropertyModel> SeekerPropertyName
        {
            get { return seekerpropertyName; }
            set
            {
                if (seekerpropertyName != value)
                {
                    seekerpropertyName = value;
                    OnPropertyChanged("PropertyName");
                }
            }
        }
        private PropertyModel selectedseekerpropertyName;

        public PropertyModel SelectedSeekerpropertyName
        {
            get { return selectedseekerpropertyName; }
            set { SetProperty(ref selectedseekerpropertyName, value); }
        }
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
        public PropertyViewModel()
        {
            ShowMorePhoto = false;
            PropertyName = new ObservableCollection<PropertyModel>()
        {
            new PropertyModel() {Property = AppResources.BasicDetails, Id = 1,Edit =true},
            new PropertyModel() {Property = AppResources.PropertyAddress,Id=2 ,Edit =false},
            new PropertyModel() {Property = AppResources.PropertyDetails, Id=3,Edit =false},
            new PropertyModel() {Property = AppResources.Photosoftheproperty, Id=4,Edit =false },
            new PropertyModel() {Property = AppResources.PropertyPricing, Id=5, Edit = false},
            new PropertyModel() {Property = AppResources.Contactinformtation , Id=6,Edit =false},
        };
            SeekerPropertyName = new ObservableCollection<PropertyModel>()
        {
            new PropertyModel() {Property = AppResources.BasicDetails, Id = 1,Edit =true},
            new PropertyModel() {Property = AppResources.PropertyAddress,Id=2 ,Edit =false},
            new PropertyModel() {Property = AppResources.PropertyDetails, Id=3,Edit =false},
            new PropertyModel() {Property = AppResources.Photosoftheproperty, Id=4,Edit =false },
            new PropertyModel() {Property = AppResources.PropertyPricing, Id=5, Edit = false},
            new PropertyModel() {Property = AppResources.AdvertiserData, Id=6, Edit = false},
            new PropertyModel() {Property = AppResources.Contactinformtation , Id=7,Edit =false},
        };
            SelectedSeekerpropertyName = SeekerPropertyName.Where(x => x.Id == 1).FirstOrDefault();
            PropertyMinBook = new ObservableCollection<DefinitionModel>();
            DateTime today = DateTime.Today;
            DateTime firstDayOfNextMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1);
            DateTime lastDayOfNextMonth = new DateTime(today.Year, today.Month, 1).AddMonths(2).AddDays(-1);
            SelectedEndDate= new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-1);
            NextSelectedStartDate = firstDayOfNextMonth;
            NextSelectedEndDate = lastDayOfNextMonth;
            PropertyPhotos = new ObservableCollection<string>();
            PropertyPhotosNext = new ObservableCollection<string>();
            PropertyLayouts = new ObservableCollection<string>();
            PropertyLayoutNext = new ObservableCollection<string>();
            AdvertisementFacilites = new ObservableCollection<AdvertisementFacilites>();
            SelectedDates = new List<DateTime>();
            SelectedDatesThis = new List<DateTime>();
            NextSelectedDates = new List<DateTime>();
            //Areas = new ObservableCollection<AreaModel>();
            //Prices = new ObservableCollection<PriceModel>();
            Keyword = "";
            PropertyProximityToTheSea = new List<DefinitionModel>();
            PropertyTypes = new List<DefinitionModel>();
            PropertyNumbers = new List<DefinitionModel>();
            PropertyStatus = new List<DefinitionModel>();
            PropertyFinished = new List<DefinitionModel>();
            PropertyDocument = new List<DefinitionModel>();
            PropertyPrice = new List<DefinitionModel>();
            PropertyPaymentFacaility = new List<DefinitionModel>();
            PropertyPaymentRentFacaility = new List<DefinitionModel>();
            PropertyPersonTitle = new List<DefinitionModel>();
            PropertyPersonType = new List<DefinitionModel>();
            PropertyBuildingUsing = new List<DefinitionModel>();
            PropertyBuildingUnits = new List<DefinitionModel>();
            PropertyBuildingPartations = new List<DefinitionModel>();
            PropertyChaletType = new List<DefinitionModel>();
            PropertyStatusTypeLand = new List<DefinitionModel>();
            PropertyUsingForLand = new List<DefinitionModel>();
            PropertyAdminOfficeType = new List<DefinitionModel>();
            PropertyFacilites = new ObservableCollection<DefinitionModel>();
            Cities = new ObservableCollection<CityModel>();
            Governments = new ObservableCollection<GovernmentModel>();
            AdvertisementModel = new AdvertisementModel();
            LoadPropertyTypesCommand = new Command(async () => { await ExecuteAllPropertyTypesListCommand(); });
            LoadPropertyTypesSearchCommand = new Command(async () => { await ExecuteAllPropertyTypesListSearchCommand(); });
            ChoosePropertyTypsPageCommand = new Command<DefinitionModel>((item) => ChoosePropertyTypeCommand(item));
            LoadPropertyCitiesCommand = new Command(async () => { await ExecuteAllCitiesListCommand(); });
            LoadPropertyCitiesSearchCommand = new Command(async () => { await ExecuteAllCitiesListSearchCommand(); });
            LoadPropertyGovernmentsCommand = new Command(async () => { await ExecuteAllGovernmentsListCommand(); });
            LoadPropertyNumbersCommand = new Command(async () => { await ExecuteAllPropertyNumberListCommand(); });
            LoadPropertyStatusCommand = new Command(async () => { await ExecuteAllPropertyStatusListCommand(); });
            LoadPropertyFinishedCommand = new Command(async () => { await ExecuteAllPropertyFinishedListCommand(); });
            LoadPropertyFinishedSearchCommand = new Command(async () => { await ExecuteAllPropertyFinishedListSearchCommand(); });
              LoadPropertyDocumentCommand = new Command(async () => { await ExecuteAllPropertyDocumentListCommand(); });
            LoadPropertyPriceCommand = new Command(async () => { await ExecuteAllPropertyPriceListCommand(); });
            ChoosePropertyPriceCommand = new Command<DefinitionModel>((item) => ChoosePropertyPrice(item));
            LoadPropertyPaymentFacilityCommand = new Command(async () => { await ExecuteAllPropertyPaymentFacilitiesIListCommand(); });
            LoadPropertyPersonTitleCommand = new Command(async () => { await ExecuteAllPropertyPersonTitleListCommand(); });
            LoadPropertyPersonTypeCommand = new Command(async () => { await ExecuteAllPropertyPersonTypeListCommand(); });
            LoadPropertyBuildingUsingCommand = new Command(async () => { await ExecuteAllPropertyBuildingUsingListCommand(); });
            LoadPropertyBuildingUnitsCommand = new Command(async () => { await ExecuteAllPropertyBuildingUnitsListCommand(); });
            LoadPropertyBuildingPartationsCommand = new Command(async () => { await ExecuteAllPropertyBuildingPartationsListCommand(); });
            LoadPropertyProximityToTheSeaCommand = new Command(async () => { await ExecuteAllPropertyProximityToTheSeaListCommand(); });
            LoadPropertyChaletTypeCommand = new Command(async () => { await ExecuteAllPropertyChaletTypeCommand(); });
            LoadPropertyStatusTypeForLandCommand = new Command(async () => { await ExecuteAllPropertyStatusTypeForLandCommand(); });
            LoadPropertyUsingForLandCommand = new Command(async () => { await ExecuteAllPropertyUsingForLandCommand(); });
            LoadPropertyAdminTypeCommand = new Command(async () => { await ExecuteAllPropertyAdminTypeCommand(); });
            ChoosePropertyFacilitiesCommand = new Command(async () => { await ExecuteAllPropertyFaclitiesListCommand(); });
            SavePropertyCommand = new Command(async () => { await ExecuteSavePropertyCommand(); });
            SavePropertyInAdsCommand = new Command(async () => { await ExecuteSavePropertyInAdsCommand(); });
            PublishPropertyCommand = new Command(async () => { await ExecuteSavePropertyAfterPaymentCommand(); });
            LoadPropertyPaymentRentFacilityCommand = new Command(async () => { await ExecuteAllPropertyPaymentRentFacilitiesIListCommand(); });
            AdvertiseForEditCommand = new Command(async () => await ExecuteAdvertiseForEditCommand());
            UpdatePropertyCommand= new Command(async () => { await ExecuteUpdatePropertyCommand(); });
            CheckPhoneNumberOtpCommand = new Command(async () => { await ExecuteCheckPhoneNumberOtpCommand(); });
            UpdatePropertyProjectCommand = new Command(async () => { await ExecuteUpdatePropertyProjectCommand(); });
            LoadPropertyMinBookListCommand =new Command(async () => { await ExecuteAllPropertyMinBookListCommand(); });
            GetLatestAdvertiseIdCommand = new Command(async () => { await ExecuteGetLatestAdvertiseId(); });
            //LoadPricesCommand = new Command(LoadLoadPices);
            //LoadAreasCommand = new Command(LoadLoadAreas);
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
                        LastAdvertise = string.Format(AppResources.Adhasbeenactivtedsuccessfully, LastAdvertiseId + 1) ;
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

        private async void ChoosePropertyPrice(DefinitionModel item)
        {
            AdvertisementModel.AgreementStatus = item.Id;
        }

        private async void ChoosePropertyTypeCommand(DefinitionModel item)
        {
            UserDialogs.Instance.ShowLoading();
            Constants.NavigationParamter = item;
            Constants.PackageId = null;
            Constants.Balance = null;
            if (Constants.LoginType == 3)
            {
                switch (item.Id)
                {
                    case 1:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.AddApartmentDetailsPage());
                        break;
                    case 2:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.AddVillaDetailsPage());
                        break;
                    case 3:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.AddChaletDetailsPage());
                        break;
                    case 4:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.AddBuildingDetailsPage());
                        break;
                    case 5:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.AddAdminOfficeDetailsPage());
                        break;
                    case 6:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.AddShopDetailsPage());
                        break;
                    case 7:
                        await Shell.Current.Navigation.PushAsync(new Views.Company.PropertiesAdsCompany.AddLandDetailsPage());
                        break;
                }

            }
            else
            {
                switch (item.Id)
                {
                    case 1:
                             await Shell.Current.Navigation.PushAsync(new Views.PropertiesAds.AddApartmentDetailsPage());
                    break; 
                    case 2:
                             await Shell.Current.Navigation.PushAsync(new Views.PropertiesAds.AddVillaDetailsPage());
                    break;
                    case 3:
                             await Shell.Current.Navigation.PushAsync(new Views.PropertiesAds.AddChaletDetailsPage());
                    break;
                    case 4:
                             await Shell.Current.Navigation.PushAsync(new Views.PropertiesAds.AddBuildingDetailsPage());
                    break;
                    case 5:
                             await Shell.Current.Navigation.PushAsync(new Views.PropertiesAds.AddAdminOfficeDetailsPage());
                    break; 
                    case 6:
                             await Shell.Current.Navigation.PushAsync(new Views.PropertiesAds.AddShopDetailsPage());
                    break;
                    case 7:
                             await Shell.Current.Navigation.PushAsync(new Views.PropertiesAds.AddLandDetailsPage());
                    break;
                }

            }
            UserDialogs.Instance.HideLoading();
        }
        private async Task ExecuteAllPropertyFaclitiesListCommand()
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                ListLength = 15;
                ItemTreshold = 1;
                if (PageIndex == 0)
                {
                    PropertyFacilites.Clear();
                }

                var res = await WebService.GetDefinitionList(new DefinitionsInputModel { Keyword = Keyword, Type = Type, Start = PageIndex * ListLength, Length = ListLength });
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    foreach (var item in res.Result.Definitions)
                    {

                        PropertyFacilites.Add(item);
                    }
                    var list = new ObservableCollection<DefinitionModel>();
                    foreach (var item in PropertyFacilites)
                    {
                        if (item.Avatar.Contains("water"))
                        {
                            item.Avatar = "blueWater.svg";
                            list.Add(item);
                        }
                        else if (item.Avatar.Contains("electry"))
                        {
                            item.Avatar = "blueElectriy.svg";
                            list.Add(item);
                        }
                        else if (item.Avatar.Contains("internet"))
                        {
                            item.Avatar = "blueInternet.svg";
                            list.Add(item);
                        }
                        else if (item.Avatar.Contains("phone"))
                        {
                            item.Avatar = "bluePhone.svg";
                            list.Add(item);
                        }
                        else if (item.Avatar.Contains("gas"))
                        {
                            item.Avatar = "blueGas.svg";
                            list.Add(item);
                        }

                    }
                    //AddDetailsItem.NewFacilites= list;
                    PropertyFacilites = list;
                }
                if (res.Result.Definitions.Count < ListLength)
                {
                    ItemTreshold = -1;
                    return;
                }
                PageIndex++;

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
        private async Task ExecuteAllPropertyMinBookListCommand()
        {
            try
            {

                PropertyMinBook.Clear();
                var res = await WebService.GetDefinitionList(new DefinitionsInputModel { Keyword = Keyword, Type = 11, Start = PageIndex * ListLength, Length = ListLength });
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    foreach (var item in res.Result.Definitions)
                    {

                        PropertyMinBook.Add(item);
                    }
                    SelectedMinTimeToBookForChaletId = PropertyMinBook.FirstOrDefault();
                }
                if (res.Result.Definitions.Count < ListLength)
                {
                    ItemTreshold = -1;
                    return;
                }
                PageIndex++;

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
        private async Task ExecuteAllPropertyTypesListCommand()
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;

               // PropertyTypes.Clear();
              var  PropertyTypesList = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.Apartment,Avatar="apartmentSvg"},
                new DefinitionModel { Id = 2, Name = AppResources.Villa,Avatar="houseSvg"},
                new DefinitionModel { Id = 3, Name = AppResources.ChaletForSummer,Avatar="chaletSvg"},
                new DefinitionModel { Id = 4, Name = AppResources.Building,Avatar="buildingSvg"},
                new DefinitionModel { Id = 5, Name = AppResources.AdminOffice,Avatar="officebuildingSvg"},
                new DefinitionModel { Id = 6, Name = AppResources.Shop,Avatar="shopSvg"},
                new DefinitionModel { Id = 7, Name = AppResources.Land,Avatar="realestateSvg"},
            };
                PropertyTypes.AddRange(PropertyTypesList);
              
                //var res = await WebService.GetPropertyTypeItemsAsync(true);

                //foreach (var item in res)
                //{

                //    PropertyTypes.Add(item);
                //}
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
        private async Task ExecuteAllPropertyTypesListSearchCommand()
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;

                // PropertyTypes.Clear();
                var PropertyTypesList = new List<DefinitionModel>()
            {
                    new DefinitionModel { Id = 0, Name = AppResources.choosepropertyType,Avatar="apartmentSvg"},
                new DefinitionModel { Id = 1, Name = AppResources.Apartment,Avatar="apartmentSvg"},
                new DefinitionModel { Id = 2, Name = AppResources.Villa,Avatar="houseSvg"},
                new DefinitionModel { Id = 3, Name = AppResources.ChaletForSummer,Avatar="chaletSvg"},
                new DefinitionModel { Id = 4, Name = AppResources.Building,Avatar="buildingSvg"},
                new DefinitionModel { Id = 5, Name = AppResources.AdminOffice,Avatar="officebuildingSvg"},
                new DefinitionModel { Id = 6, Name = AppResources.Shop,Avatar="shopSvg"},
                new DefinitionModel { Id = 7, Name = AppResources.Land,Avatar="realestateSvg"},
            };
                PropertyTypes.AddRange(PropertyTypesList);
                SelectedProperty = PropertyTypes.ToList().Where(x => x.Id == 0).FirstOrDefault();
                //var res = await WebService.GetPropertyTypeItemsAsync(true);

                //foreach (var item in res)
                //{

                //    PropertyTypes.Add(item);
                //}
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
        private async Task ExecuteAllCitiesListCommand()
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                ListLength = 15;
                ItemTreshold = 1;
                if (PageIndex == 0)
                {
                    Cities.Clear();
                }
              //  Cities.Add(new CityModel { Id=0,Name=AppResources.Proivnce});
                var res = await WebService.GetAllCities(new CitiesInputModel { Keyword = Keyword,GovermentId= SelectGovernment!=null?SelectGovernment.Id:0, Start = PageIndex * ListLength, Length = ListLength });
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    foreach (var item in res.Result.Cities)
                    {

                        Cities.Add(item);
                    }
                }
                if (res.Result.Cities.Count < ListLength)
                {
                    ItemTreshold = -1;
                    return;
                }
                PageIndex++;

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
        private async Task ExecuteAllCitiesListSearchCommand()
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                ListLength = 15;
                ItemTreshold = 1;
                if (PageIndex == 0)
                {
                    Cities.Clear();
                }
                //  Cities.Add(new CityModel { Id=0,Name=AppResources.Proivnce});
                var res = await WebService.GetAllCities(new CitiesInputModel { Keyword = Keyword, GovermentId = SelectGovernment != null ? SelectGovernment.Id : 0, Start = PageIndex * ListLength, Length = ListLength });
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    Cities.Add(new CityModel { Id=0,Name=AppResources.Proivnce});
                    foreach (var item in res.Result.Cities)
                    {

                        Cities.Add(item);
                    }
                    SelectCity = Cities.FirstOrDefault();
                }
                if (res.Result.Cities.Count < ListLength)
                {
                    ItemTreshold = -1;
                    return;
                }
                PageIndex++;

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
        private async Task ExecuteAllGovernmentsListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                //ListLength = 15;
                //ItemTreshold = 1;
                //if (PageIndex == 0)
                //{
                //    Governments.Clear();
                //}

                var res = await WebService.GetAllGovernments(new GovernmentsInputModel { Keyword = Keyword, Start = PageIndex * ListLength, Length = 30 });
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Error);
                }
                else if (res?.Result?.Success == true)
                {
                    foreach (var item in res.Result.Governorates.OrderBy(x=>x.Id))
                    {

                        Governments.Add(item);
                    }
                }
                if (res.Result.Governorates.Count < ListLength)
                {
                    ItemTreshold = -1;
                    return;
                }
              //  PageIndex++;

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
        
        private async Task ExecuteAllPropertyNumberListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                //    PropertyNumbers.Clear();
                PropertyNumbers = new List<DefinitionModel>();
                  var   items = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 0, Name = "0"},
                new DefinitionModel { Id = 1, Name = "1"},
                new DefinitionModel { Id = 2, Name = "2" },
                new DefinitionModel { Id = 3, Name = "3" },
                new DefinitionModel { Id = 4, Name = "4+" },
            };
                PropertyNumbers.AddRange(items);
               
               // SelectedPropertyNumbers = PropertyNumbers.FirstOrDefault();
                //SelectedPropertyRooms = PropertyNumbers.FirstOrDefault();
               // SelectedPropertyReception = PropertyNumbers.FirstOrDefault();
              //  SelectedPropertyDining = PropertyNumbers.FirstOrDefault();
               // SelectedPropertyBalcony = PropertyNumbers.FirstOrDefault();
              // SelectedPropertyKitchen = PropertyNumbers.FirstOrDefault();
               // SelectedPropertyToliet = PropertyNumbers.FirstOrDefault();
               // SelectedProximityToTheSea = PropertyNumbers.FirstOrDefault();
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
        private async Task ExecuteAllPropertyStatusListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                //  PropertyStatus.Clear();
                PropertyStatus = new List<DefinitionModel>();
                var PropertyStatusItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.New},
                new DefinitionModel { Id = 2, Name = AppResources.Used},
                new DefinitionModel { Id = 3, Name = AppResources.Renewed },

            };
                PropertyStatus.AddRange(PropertyStatusItems);

                // SelectedPropertyStatus = PropertyStatus.FirstOrDefault();
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
        private async Task ExecuteAllPropertyFinishedListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                //     PropertyFinished.Clear();
                PropertyFinished = new List<DefinitionModel>();
                var  PropertyFinishingItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.Without},
                new DefinitionModel { Id = 2, Name = AppResources.SemiFinished},
                new DefinitionModel { Id = 3, Name = AppResources.Full },
                    new DefinitionModel { Id = 4, Name = AppResources.HighQuality },

            };
                PropertyFinished.AddRange(PropertyFinishingItems);
                //  SelectedPropertyFinished = PropertyFinished.FirstOrDefault();
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
        private async Task ExecuteAllPropertyFinishedListSearchCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                //   PropertyFinished.Clear();
                PropertyFinished = new List<DefinitionModel>();
                var PropertyFinishingSearchItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.Without},
                new DefinitionModel { Id = 2, Name = AppResources.Half},
                new DefinitionModel { Id = 4, Name = AppResources.Full },
                    //new DefinitionModel { Id = 4, Name = AppResources.HighQuality },

            };
                PropertyFinished.AddRange(PropertyFinishingSearchItems);
                //  SelectedPropertyFinished = PropertyFinished.FirstOrDefault();
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
        private async Task ExecuteAllPropertyDocumentListCommand()
        {
            try
            {

                //  PropertyDocument.Clear();
                PropertyDocument = new List<DefinitionModel>();
                var  PropertyDocumentItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.Registered},
                new DefinitionModel { Id = 2, Name = AppResources.Unregistered},
                new DefinitionModel { Id = 3, Name = AppResources.Registerable },
                    new DefinitionModel { Id = 4, Name = AppResources.Unregisterable },

            };
                PropertyDocument.AddRange(PropertyDocumentItems);
                // SelectedPropertyDocument = PropertyDocument.FirstOrDefault();
            }
            catch (Exception ex)
            {
                
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }


        }
        private async Task ExecuteAllPropertyPriceListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                // PropertyPrice.Clear();
                PropertyPrice = new List<DefinitionModel>();
                var PropertyPriceItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.Sell},
                new DefinitionModel { Id = 2, Name = AppResources.Rent},
            };
                PropertyPrice.AddRange(PropertyPriceItems);
                // SelectedAgreementStatus = PropertyPrice.FirstOrDefault();
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
        private async Task ExecuteAllPropertyPaymentFacilitiesIListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                // PropertyPaymentFacaility.Clear();
                PropertyPaymentFacaility = new List<DefinitionModel>();
                var  PropertyPaymentFacilityItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.Allowed},
                new DefinitionModel { Id = 2, Name = AppResources.NotAllowed},
            };
                PropertyPaymentFacaility.AddRange(PropertyPaymentFacilityItems);
                // SelectedPaymentFacality = PropertyPaymentFacaility.FirstOrDefault();

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
        private async Task ExecuteAllPropertyPaymentRentFacilitiesIListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                //  PropertyPaymentFacaility.Clear();
                PropertyPaymentRentFacaility = new List<DefinitionModel>();
                var PropertyPaymentRentFacilityItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.monthly},
                new DefinitionModel { Id = 2, Name = AppResources.midterm},
                 new DefinitionModel { Id = 3, Name = AppResources.annual},
            };
                PropertyPaymentRentFacaility.AddRange(PropertyPaymentRentFacilityItems);

                // SelectedPaymentFacality = PropertyPaymentFacaility.FirstOrDefault();
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
        private async Task ExecuteAllPropertyPersonTitleListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                // PropertyPersonTitle.Clear();
                PropertyPersonTitle = new List<DefinitionModel>();
                var PropertyTitleItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.mr},
                new DefinitionModel { Id = 2, Name = AppResources.ms},
            };
                PropertyPersonTitle.AddRange(PropertyTitleItems);
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
        private async Task ExecuteAllPropertyPersonTypeListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                //  PropertyPersonType.Clear();
                PropertyPersonType = new List<DefinitionModel>();
                PropertyPersonType.Add(new DefinitionModel { Id=0,Name=AppResources.OwnerBroker});
                var PropertyPersonTypeItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.Owner},
                new DefinitionModel { Id = 2, Name = AppResources.Broker},
            };

                PropertyPersonType.AddRange(PropertyPersonTypeItems);
                SelectedPersonType = PropertyPersonType.FirstOrDefault();
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
        private async Task ExecuteAllPropertyBuildingUsingListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                // PropertyBuildingUsing.Clear();
                PropertyBuildingUsing = new List<DefinitionModel>();
                var   PropertyBuildingUsingForItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 5, Name = AppResources.Residential},
                new DefinitionModel { Id = 6, Name = AppResources.Commercial},
            };
                PropertyBuildingUsing.AddRange(PropertyBuildingUsingForItems);
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
        public List<DefinitionModel>GetPropertyNumbers()
        {
            return  new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 0, Name = "0"},
                new DefinitionModel { Id = 1, Name = "1"},
                new DefinitionModel { Id = 2, Name = "2" },
                new DefinitionModel { Id = 3, Name = "3" },
                new DefinitionModel { Id = 4, Name = "4+" },
            };
        }
        private async Task ExecuteAllPropertyBuildingUnitsListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                // PropertyBuildingUnits.Clear();
                //var res = await WebService.GetPropertyNumbersAsync();
                //foreach (var item in res)
                //{
                //    PropertyBuildingUnits.Add(item);
                //}
                PropertyBuildingUnits = new List<DefinitionModel>();
                PropertyBuildingUnits.AddRange(GetPropertyNumbers());
               // SelectedNumUnits = PropertyBuildingUnits.FirstOrDefault();
               // SelectedOfficesFloors = PropertyBuildingUnits.FirstOrDefault();
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
        private async Task ExecuteAllPropertyBuildingPartationsListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                // PropertyBuildingPartations.Clear();
                PropertyBuildingPartations = new List<DefinitionModel>();
                PropertyBuildingPartations.AddRange( GetPropertyNumbers());
                //SelectedNumPartitions = PropertyBuildingPartations.FirstOrDefault();
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
        private async Task ExecuteAllPropertyProximityToTheSeaListCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                PropertyProximityToTheSea = new List<DefinitionModel>();
                var PropertyProximityToTheSeaTypeItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources._100m},
                new DefinitionModel { Id = 2, Name = AppResources._500m},
                new DefinitionModel { Id = 2, Name = AppResources._500mto1km},
                new DefinitionModel { Id = 2, Name = AppResources._1kmto5km},
            };
                PropertyProximityToTheSea.AddRange(PropertyProximityToTheSeaTypeItems);
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
        private async Task ExecuteAllPropertyChaletTypeCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                //   PropertyChaletType.Clear();
                PropertyChaletType = new List<DefinitionModel>();
                  var PropertyChaletTypeItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.Chalet},
                new DefinitionModel { Id = 2, Name = AppResources.Villa},
            };
                PropertyChaletType.AddRange(PropertyChaletTypeItems);
                // SelectedChaletType = PropertyChaletType.FirstOrDefault();
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
        private async Task ExecuteAllPropertyStatusTypeForLandCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                // PropertyStatusTypeLand.Clear();
                PropertyStatusTypeLand = new List<DefinitionModel>();
                var  PropertyStatusForLandItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.Empty},
                new DefinitionModel { Id = 2, Name = AppResources.Used},
            };
                PropertyStatusTypeLand.AddRange(PropertyStatusForLandItems);
                
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
        private async Task ExecuteAllPropertyUsingForLandCommand()
        {
            try
            {
            //    if (IsBusy) return;
            //    IsBusy = true;
                // PropertyUsingForLand.Clear();
                PropertyUsingForLand = new List<DefinitionModel>();
               var  PropertyUsingForLandItems = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.Buildings},
                new DefinitionModel { Id = 2, Name = AppResources.Industrial},
                  new DefinitionModel { Id = 3, Name = AppResources.Agriculture},
                    new DefinitionModel { Id = 4, Name = AppResources.Investment},
            };
                PropertyUsingForLand.AddRange(PropertyUsingForLandItems);
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
        private async Task ExecuteAllPropertyAdminTypeCommand()
        {
            try
            {
                //if (IsBusy) return;
                //IsBusy = true;
                // PropertyAdminOfficeType.Clear();
                PropertyAdminOfficeType = new List<DefinitionModel>();
                var    PropertyAdminTypeItemsList = new List<DefinitionModel>()
            {
                new DefinitionModel { Id = 1, Name = AppResources.Company},
                new DefinitionModel { Id = 2, Name = AppResources.Factory},
            };
                PropertyAdminOfficeType.AddRange(PropertyAdminTypeItemsList);
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
        private async Task ExecuteSavePropertyInAdsCommand()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                if (IsBusy) return;
                IsBusy = true;
                AdvertisementModel.SeekerId = Constants.SeekerId;
                AdvertisementModel.BrokerPersonId = Constants.BrokerId;
                AdvertisementModel.OwnerId = Constants.OwnerId;
                AdvertisementModel.CompanyId = Constants.CompanyId;
                AdvertisementModel.DurationId = null;
                foreach (var item in AdvertisementModel.MediaFiles)
                {
                    AdvertisementModel.PhotosList.Add(await uploadFile(item));
                }
                foreach (var item in AdvertisementModel.MediaFilesLayout)
                {
                    AdvertisementModel.LayoutsList.Add(await uploadFile(item));
                }
                AdvertisementModel.AdvertisementBookings = new List<DateTime>();
                foreach (var item in SelectedDates)
                {
                    AdvertisementModel.AdvertisementBookings.Add(item);
                }

                foreach (var item in NextSelectedDates)
                {
                    AdvertisementModel.AdvertisementBookings.Add(item);
                }

                //if (string.IsNullOrEmpty(AdvertisementModel.MobileNumber))
                //{
                //    ShowMessege(AppResources.Alert, AppResources.InvalidPhone);
                //}
                //else if (!string.IsNullOrEmpty(AdvertisementModel.MobileNumber) && (AdvertisementModel.MobileNumber.Length != 11 || !AdvertisementModel.MobileNumber.StartsWith("01")))
                //{
                //    ShowMessege(AppResources.Alert, AppResources.phoneNumberformat);

                //}
                if (!string.IsNullOrEmpty(AdvertisementModel.SecondMobileNumber) || AdvertisementModel.ContactRegisterInTheAccount == true)
                {
                    if (Constants.NavigationProject != null)
                    {
                        var PhotoList = new List<string>();
                        var LayoutList = new List<string>();
                        var ProjectDetails = Constants.NavigationProject as ProjectModel;
                        //ProjectDetails.Advertisements.Clear();
                        ProjectDetails.Advertisements.Add(AdvertisementModel);
                        foreach (var item in ProjectDetails.PhotosList)
                        {
                            PhotoList.Add(await CheckPhoto(item));
                        }
                        foreach (var item in ProjectDetails.LayoutsList)
                        {
                            LayoutList.Add(await CheckPhoto(item));
                        }
                        ProjectDetails.PhotosList = PhotoList;
                        ProjectDetails.LayoutsList = LayoutList;
                        var res = await WebService.ManagaProject(ProjectDetails);
                        if (!res.Success)
                            ShowMessege(AppResources.Alert, res?.Error);
                        else if (res?.Result?.Success != true)
                        {
                            ShowMessege(AppResources.Alert, res?.Result?.Error);
                        }
                        else if (res?.Result?.Success == true)
                        {
                            ShowMessege(AppResources.Alert, AppResources.SuccessFully);
                            //   Application.Current.MainPage = new AppShell();
                            Constants.ProjectId = res.Result.ProjectId;
                            await Shell.Current.Navigation.PushAsync(new EditProjectPage());
                        }

                    }
                    else
                    {
                        var res = await WebService.ManageAdvertisement(AdvertisementModel);
                        if (res.result.success != true)
                        {
                            ShowMessege(AppResources.Alert, res?.result.error);
                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                            await Shell.Current.Navigation.PushAsync(new AddsPage());
                        }
                    }
                }
                else
                {
                    ShowMessege(AppResources.Alert, AppResources.InvalidPhone);
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
        private async Task ExecuteUpdatePropertyCommand()
        {
            try
            {
                var PhotoList = new List<string>();
                var LayoutList = new List<string>();
                UserDialogs.Instance.ShowLoading();
                //if (IsBusy) return;
                //IsBusy = true;
             


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
                AdvertisementModel.AdvertisementBookings = new List<DateTime>();
                foreach (var item in SelectedDates)
                {
                    AdvertisementModel.AdvertisementBookings.Add(item) ;
                }
             
                foreach (var item in NextSelectedDates)
                {
                    AdvertisementModel.AdvertisementBookings.Add(item);
                }
                AdvertisementModel.IsEdited = true;
                AdvertisementModel.PhotosList = PhotoList;
                AdvertisementModel.LayoutsList = LayoutList;
                AdvertisementModel.AdvertisementFacilitesList = new List<int>();
                if (AdvertisementModel.FacilitesApi.Count > 0)
                {
                    foreach (var item in AdvertisementModel.FacilitesApi.Where(x=>x.IsSelected==true))
                    {
                      
                        AdvertisementModel.AdvertisementFacilitesList.Add(item.Id);
                    }
                }
                if (!string.IsNullOrEmpty(AdvertisementModel.SecondMobileNumber) || AdvertisementModel.ContactRegisterInTheAccount == true)
                {
                    var check = await WebService.CheckPropertyStatus(AdvertisementModel.Id);
                    if (check.Result.Status == true)
                    {
                        AdvertisementModel.CityId = null;
                        var res = await WebService.ManageAdvertisement(AdvertisementModel);
                        if (res.result.success != true)
                        {
                            ShowMessege(AppResources.Alert, res?.result.error);
                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                            //  Application.Current.MainPage = new AppShell();
                            await Shell.Current.Navigation.PushAsync(new AddsPage());
                        }
                    }
                    else
                    {
                        Constants.NavigationAdvertiserModel = AdvertisementModel;
                        Constants.NavigationParamter = new DefinitionModel { Id = AdvertisementModel.Type };
                        if (Constants.LoginType == 3)
                            await Shell.Current.Navigation.PushAsync(new PaymentCompanyPage());
                        else
                            await Shell.Current.Navigation.PushAsync(new PaymentPage());
                    }
                }
                else
                {
                    ShowMessege(AppResources.Alert, AppResources.InvalidPhone);

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
        private async Task ExecuteUpdatePropertyProjectCommand()
        {
            try
            {
                var PhotoList = new List<string>();
                var LayoutList = new List<string>();
                UserDialogs.Instance.ShowLoading();
                //if (IsBusy) return;
                //IsBusy = true;



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
                AdvertisementModel.AdvertisementBookings = new List<DateTime>();
                foreach (var item in SelectedDates)
                {
                    AdvertisementModel.AdvertisementBookings.Add(item);
                }

                foreach (var item in NextSelectedDates)
                {
                    AdvertisementModel.AdvertisementBookings.Add(item);
                }
                AdvertisementModel.IsEdited = true;
                AdvertisementModel.PhotosList = PhotoList;
                AdvertisementModel.LayoutsList = LayoutList;
                AdvertisementModel.AdvertisementFacilitesList = new List<int>();
                if (AdvertisementModel.FacilitesApi.Count > 0)
                {
                    foreach (var item in AdvertisementModel.FacilitesApi.Where(x => x.IsSelected == true))
                    {

                        AdvertisementModel.AdvertisementFacilitesList.Add(item.Id);
                    }
                }
                if (string.IsNullOrEmpty(AdvertisementModel.MobileNumber))
                {
                    ShowMessege(AppResources.Alert, AppResources.InvalidPhone);
                }
                else if (!string.IsNullOrEmpty(AdvertisementModel.MobileNumber) && (AdvertisementModel.MobileNumber.Length != 11 || !AdvertisementModel.MobileNumber.StartsWith("01")))
                {
                    ShowMessege(AppResources.Alert, AppResources.phoneNumberformat);

                }
                else
                {
                    
                        AdvertisementModel.CityId = null;
                        var res = await WebService.ManageAdvertisement(AdvertisementModel);
                        if (res.result.success != true)
                        {
                            ShowMessege(AppResources.Alert, res?.result.error);
                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                            //  Application.Current.MainPage = new AppShell();
                            await Shell.Current.Navigation.PushAsync(new AddsPage());
                        }
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

        async Task<string>   CheckPhoto(string photo)
        {
            return  photo.Replace("https://brokerapi.nahrdev.website/Resources/UploadFiles/", "");
        }
        public async Task<string> uploadFile(MediaFile _mediaFile)
        {

            if (_mediaFile == null)
            {
                //await Application.Current.MainPage.DisplayAlert("Error", "There was an error when trying to get your image.", "OK");
                return null;
            }
            else
            {
                var uri = $"{Constants.ApiURL}/api/Upload/UploadMobile";
                var content = new MultipartFormDataContent();

                content.Add(new StreamContent(_mediaFile.GetStream()),
                    "\"file\"",
                    $"\"{_mediaFile.Path}\"");

                var httpClient = new HttpClient();
                var httpResponseMessage = await httpClient.PostAsync(uri, content);
                if (httpResponseMessage.IsSuccessStatusCode == true)
                {
                    return Path.GetFileName(_mediaFile.Path);
                }
                else
                {
                    return null;
                }

            }
        }
        private async Task ExecuteSavePropertyCommand()
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;
                if (!string.IsNullOrEmpty(AdvertisementModel.SecondMobileNumber) || AdvertisementModel.ContactRegisterInTheAccount == true)
                {
                    AdvertisementModel.AdvertisementBookings = new List<DateTime>();
                    foreach (var item in SelectedDates)
                    {
                        AdvertisementModel.AdvertisementBookings.Add(item);
                    }

                    foreach (var item in NextSelectedDates)
                    {
                        AdvertisementModel.AdvertisementBookings.Add(item);
                    }
                    foreach (var item in AdvertisementModel.MediaFilesLayout)
                    {
                        AdvertisementModel.LayoutsList.Add(await uploadFile(item));
                    }
                    AdvertisementModel.SeekerId = Constants.SeekerId;
                    AdvertisementModel.BrokerPersonId = Constants.BrokerId;
                    AdvertisementModel.OwnerId = Constants.OwnerId;
                    AdvertisementModel.CompanyId = Constants.CompanyId;
                    Constants.NavigationAdvertiserModel = AdvertisementModel;
                    Constants.NavigationParamter = new DefinitionModel { Id = AdvertisementModel.Type };
                    if (Constants.LoginType == 3)
                        await Shell.Current.Navigation.PushAsync(new PaymentCompanyPage());
                    else
                        await Shell.Current.Navigation.PushAsync(new PaymentPage());
                }
              
                else
                {
                    
                    ShowMessege(AppResources.Alert, AppResources.InvalidPhone);
                }

                //var res = await WebService.CreateAdvertisement(AdvertisementModel);
                //if (res.result.success != null)
                //{
                //    ShowMessege(AppResources.Alert, res?.result.error);
                //}
                //else
                //{
                //    App.Current.MainPage = new AppShell();
                //}
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
        private async Task ExecuteSavePropertyAfterPaymentCommand()
        {
            try
            {
                if (Constants.IsPaidWithWallet == true)
                {
                    UserDialogs.Instance.HideLoading();
                    await Shell.Current.Navigation.PopPopupAsync();
                    Application.Current.MainPage = new AppShell();

                }
                else
                {
                    await Shell.Current.Navigation.PopPopupAsync();
                    // Application.Current.MainPage = new AppShell();
                    Constants.PaymentStatus = 0;
                    UserDialogs.Instance.HideLoading();

                }
               
                  

              
              
                //if (res.result.success != true)
                //{
                //    ShowMessege(AppResources.Alert, res?.result.error);
                //}
                //else
                //{
                //    if (Constants.IsPaidWithWallet == true)
                //    {
                //        UserDialogs.Instance.HideLoading();
                //        await Shell.Current.Navigation.PopPopupAsync();
                //         Application.Current.MainPage = new AppShell();
                        
                //    }
                //    else
                //    {
                //        await Shell.Current.Navigation.PopPopupAsync();
                //        // Application.Current.MainPage = new AppShell();
                //        Constants.PaymentStatus = 0;
                //        UserDialogs.Instance.HideLoading();

                //    }
                    
                      
                //}
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
        private async Task ExecuteAdvertiseForEditCommand()
        {
            try
            {
                Device.BeginInvokeOnMainThread(async() => {
                UserDialogs.Instance.ShowLoading();
                
                var advertise = await WebService.GetAdvertiseForEdit(Convert.ToInt32(Constants.NavigationParamter));
                if (!advertise.Success)
                    ShowMessege(AppResources.Alert, advertise?.Error);
                else if (advertise?.Result?.Success != true)
                {
                    ShowMessege(AppResources.Alert, advertise?.Result?.Error);
                }
                else if (advertise?.Result?.Success == true)
                {
                
                        AdvertisementModel = advertise.Result.Advertisement;
                        SelectedDates = new List<DateTime>();
                       var  ThisNextSelectedDates = new List<DateTime>();
                        var ThisSelectedDates = new List<DateTime>();
                        SelectedDatesThis = new List<DateTime>();
                        if (AdvertisementModel.AdvertisementBookings.Count > 0)
                        {
                            int currentMonth = DateTime.Now.Month;
                            int nextMonth = DateTime.Now.AddMonths(1).Month;
                         
                            foreach (var item in AdvertisementModel.AdvertisementBookings.Distinct())
                            {
                                if (item.Month == currentMonth)
                                {
                            //        SelectedDatesThis = new List<DateTime>
                            //{
                            //    new DateTime(2023,7,5),
                            //    new DateTime(2023,7,19),
                            //    new DateTime(2023,7,11),
                            //};

                                     ThisSelectedDates.Add(new DateTime(item.Year, item.Month, item.Day));
                                }
                                else
                                {
                                    if (item.Month == nextMonth)
                                    {
                                      //  NextSelectedDates.Add(item);
                                        ThisNextSelectedDates.Add(new DateTime(item.Year, item.Month, item.Day));
                                    }
                                }

                            }

                        }
                        this.SelectedDates =ThisSelectedDates;
                        this.NextSelectedDates = ThisNextSelectedDates;
                        //if (AdvertisementModel.AgreementStatus == 1)
                        //{
                        //    LoadPropertyPaymentFacilityCommand.Execute(true);
                        //}
                        //else
                        //{
                        //    LoadPropertyPaymentRentFacilityCommand.Execute(true);
                        //}
                        SelectedAgreementStatus = PropertyPrice.Where(x => x.Id == AdvertisementModel.AgreementStatus).FirstOrDefault();
                        SelectGovernment = Governments.Where(x => x.Id == AdvertisementModel.GovernorateId).FirstOrDefault();
                    SelectedPropertyStatus = PropertyStatus.Where(x => x.Id == AdvertisementModel.BuildingStatus).FirstOrDefault();
                        SelectedPropertyFinished = PropertyFinished.Where(x => x.Id == AdvertisementModel.Decoration).FirstOrDefault();
                    SelectedPropertyRooms = PropertyNumbers.Where(x => x.Id == AdvertisementModel.Rooms).FirstOrDefault();
                    SelectedPropertyReception = PropertyNumbers.Where(x => x.Id == AdvertisementModel.Reception).FirstOrDefault();
                    SelectedPropertyDining = PropertyNumbers.Where(x => x.Id == AdvertisementModel.Dinning).FirstOrDefault();
                    SelectedPropertyBalcony = PropertyNumbers.Where(x => x.Id == AdvertisementModel.Balcony).FirstOrDefault();
                    SelectedPropertyKitchen = PropertyNumbers.Where(x => x.Id == AdvertisementModel.Kitchen).FirstOrDefault();
                    SelectedPropertyToliet = PropertyNumbers.Where(x => x.Id == AdvertisementModel.Toilet).FirstOrDefault();
                    SelectedPropertyDocument = PropertyDocument.Where(x => x.Id == AdvertisementModel.Document).FirstOrDefault();
                    SelectedTitle = PropertyPersonTitle.Where(x => x.Id == AdvertisementModel.MrMrs).FirstOrDefault();
                    SelectedPersonType = PropertyPersonType.Where(x => x.Id == AdvertisementModel.AdvertiseMaker).FirstOrDefault();
                    SelectedChaletType = PropertyChaletType.Where(x => x.Id == AdvertisementModel.ChaletType).FirstOrDefault();
                    SelectedProximityToTheSea = PropertyProximityToTheSea.Where(x => x.Id == AdvertisementModel.ProximityToTheSea).FirstOrDefault();
                    SelectedUsingFor = PropertyBuildingUsing.Where(x => x.Id == AdvertisementModel.UsingFor).FirstOrDefault();
                        SelectedUsingForLand= PropertyUsingForLand.Where(x=>x.Id== AdvertisementModel.UsingFor).FirstOrDefault();
                        SelectedNumUnits = PropertyBuildingUnits.Where(x => x.Id == AdvertisementModel.NumUnits).FirstOrDefault();
                    SelectedNumPartitions = PropertyBuildingPartations.Where(x => x.Id == AdvertisementModel.NumPartitions).FirstOrDefault();
                    SelectedOfficies = PropertyAdminOfficeType.Where(x => x.Id == AdvertisementModel.Officies).FirstOrDefault();
                    SelectedOfficesFloors = PropertyBuildingUnits.Where(x => x.Id == AdvertisementModel.OfficesFloors).FirstOrDefault();
                        SelectedOfficesNums = PropertyBuildingUnits.Where(x => x.Id == AdvertisementModel.OfficesNum).FirstOrDefault();
                        SelectedMinTimeToBookForChaletId = PropertyMinBook.Where(x => x.Id == AdvertisementModel.MinTimeToBookForChaletId).FirstOrDefault();
                        SelectedLandingStatus = PropertyStatusTypeLand.Where(x => x.Id == AdvertisementModel.LandingStatus).FirstOrDefault();
                        SelectedPaymentFacality = PropertyPaymentFacaility.Where(x => x.Id == AdvertisementModel.PaymentFacility).FirstOrDefault();
                        if (AdvertisementModel.Rent == null)
                        {
                            SelectedPaymentFacality = PropertyPaymentFacaility.Where(x => x.Id == AdvertisementModel.PaymentFacility).FirstOrDefault();

                        }
                        else
                        {
                            SelectedPaymentFacality = PropertyPaymentRentFacaility.Where(x => x.Id == AdvertisementModel.Rent).FirstOrDefault();
                        }
                        foreach (var item in AdvertisementModel.PhotosList.Take(3))
                        {
                            PropertyPhotos.Add(item);
                        }
                        foreach (var item in AdvertisementModel.PhotosList.Skip(3))
                        {
                            PropertyPhotosNext.Add(item);
                        }
                       
                        foreach (var item in AdvertisementModel.LayoutsList.Take(3))
                        {
                            PropertyLayouts.Add(item);
                        }
                        foreach (var item in AdvertisementModel.LayoutsList.Skip(3))
                        {
                            PropertyLayoutNext.Add(item);
                        }
                        var list = new List<AdvertisementFacilites>();
                        foreach (var item in AdvertisementModel.FacilitesApi)
                        {
                            if (item.Avatar.Contains("water"))
                            {
                                item.Avatar = "blueWater.svg";
                                list.Add(item);
                            }
                            else if (item.Avatar.Contains("electry"))
                            {
                                item.Avatar = "blueElectriy.svg";
                                list.Add(item);
                            }
                            else if (item.Avatar.Contains("internet"))
                            {
                                item.Avatar = "blueInternet.svg";
                                list.Add(item);
                            }
                            else if (item.Avatar.Contains("phone"))
                            {
                                item.Avatar = "bluePhone.svg";
                                list.Add(item);
                            }
                            else if (item.Avatar.Contains("gas"))
                            {
                                item.Avatar = "blueGas.svg";
                                list.Add(item);
                            }

                        }
                        //AddDetailsItem.NewFacilites= list;
                        AdvertisementModel.FacilitesApi = list;
                        if (PropertyPhotosNext[0].Contains("AddPhoto"))
                        {
                            ShowMorePhoto = false;
                        }
                        else
                        {
                            ShowMorePhoto = true;
                        }
                        
                }
                UserDialogs.Instance.HideLoading();
                });
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
        private async Task ExecuteCheckPhoneNumberOtpCommand()
        {
            try
            {
                var res = await WebService.CheckPhoneNumberOtp();
                if (!res.Success)
                    ShowMessege(AppResources.Alert, res?.Error);
                else if (res?.Result?.IsSuccess != true)
                {
                    ShowMessege(AppResources.Alert, res?.Result?.Message);
                }
                else if (res?.Result?.IsSuccess == true)
                {
                    Constants.UserVerifyCode = Convert.ToString(res.Result.Otp);


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

        async Task<List<string>>  CheckPhoto(List<string> PhotosList)
        {
            switch (PhotosList.Count)
            {
                case 1:
                    PhotosList.Add("AddPhoto.png");
                    PhotosList.Add("AddPhoto.png");
                    PhotosList.Add("AddPhoto.png");
                    PhotosList.Add("AddPhoto.png");
                    PhotosList.Add("AddPhoto.png");
                   
                    break;
                    case 2:
                    PhotosList.Add("AddPhoto.png");
                    PhotosList.Add("AddPhoto.png");
                    PhotosList.Add("AddPhoto.png");
                    PhotosList.Add("AddPhoto.png");
                    break;
                case 3:
                    PhotosList.Add("AddPhoto.png");
                    PhotosList.Add("AddPhoto.png");
                    PhotosList.Add("AddPhoto.png"); 
                    break;
                case 4:
                    PhotosList.Add("AddPhoto.png");
                    PhotosList.Add("AddPhoto.png");
                    break;
                case 5:
                    PhotosList.Add("AddPhoto.png");
                    break;
            }
            return  PhotosList;
        }
    }
}


