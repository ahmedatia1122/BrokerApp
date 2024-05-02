using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace NewBrokerApp.Models
{
    public class AdvertisementModel
    {
        public AdvertisementModel()
        {
            AdvertisementFacilitesList = new List<int>();
            MediaFiles=new List<MediaFile>();
            MediaFilesLayout = new List<MediaFile>();
            PhotosList = new List<string>();
            LayoutsList = new List<string>();
            AdvertisementBookings = new List<DateTime>();
            FacilitesApi = new List<AdvertisementFacilites>();
        }
        public long Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public long? CityId { get; set; }
        public long? GovernorateId { get; set; }
        public string Compound { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public double? Longitudes { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int? FloorsNumber { get; set; }
        public int? Document { get; set; }
        public string Area { get; set; }
        public decimal? BuildingArea { get; set; }
          public int? ChaletType { get; set; }
        public int? ProximityToTheSea { get; set; }
        
        public int AgreementStatus { get; set; }
        public int? BuildingStatus { get; set; }
       public int? LandingStatus { get; set; }
      //  public int? Finishing { get; set; }
        public int? Decoration { get; set; }
        
        public int? UsingFor { get; set; }
        public decimal? StreetWidth { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public DateTime? BuildingDate { get; set; }
        public int? Rooms { get; set; }
        public int? Reception { get; set; }
        public int? Dining { get; set; }
        public long? Dinning { get; set; }
        public int? Balcony { get; set; }
        public int? Kitchen { get; set; }
        public int? Toilet { get; set; }
        public int? NumUnits { get; set; }
        public int? NumPartitions { get; set; }
        public int? OfficesNum { get; set; }
        public int? OfficesFloors { get; set; }
        public long? DurationId { get; set; }
        // public DurationDto Duration { get; set; }
        public long? SeekerId { get; set; }
        // public SeekerDto Seeker { get; set; }
        public long? OwnerId { get; set; }
        // public OwnerDto Owner { get; set; }
        public long? CompanyId { get; set; }
        // public CompanyDto Company { get; set; }
        public long? BrokerPersonId { get; set; }
        // public BrokerPersonDto BrokerPerson { get; set; }
        public bool IsPublish { get; set; }
        public bool? IsApprove { get; set; }
        public string Description { get; set; }
        public bool? FeaturedAd { get; set; }
        public decimal Price { get; set; }
        public int? PaymentFacility { get; set; }
        public int? MrMrs { get; set; }
        public string AdvertiseMakerName { get; set; }
        public int? AdvertiseMaker { get; set; }
        public string MobileNumber { get; set; }
        public bool IsWhatsApped { get; set; }
        public string SecondMobileNumber { get; set; }
        public bool ContactRegisterInTheAccount { get; set; }
        public bool? Furnished { get; set; }
        public bool? Elevator { get; set; }
        public bool? Parking { get; set; }
        public decimal? ParkingSpace { get; set; }
        public bool? Garden { get; set; }
        public decimal? GardenArea { get; set; }
        public bool? Pool { get; set; }
        public bool? Shop { get; set; }
        public int? ShopsNumber { get; set; }
        public List<int> AdvertisementFacilitesList { get; set; }
        public bool? AirConditioner { get; set; }
        public List<string> PhotosList { get; set; }
        public List<string> LayoutsList { get; set; }
        public List<MediaFile> MediaFiles { get; set; }
        public List<MediaFile> MediaFilesLayout { get; set; }
        public int? Officies { get; set; }
        public int? ChaletRentType { get; set; }
        public decimal? ChaletRentValue { get; set; }
        public int? NumOfMonths { get; set; }
        public List<DateTime> AdvertisementBookings { get; set; }
        public List<AdvertisementFacilites> FacilitesApi { get; set; }
        public decimal? DownPayment { get; set; }
        public decimal? MonthlyInstallment { get; set; }
        public decimal? YearlyInstallment { get; set; }
        public decimal? NumOfYears { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? MinTimeToBookForChaletId { get; set; }
        public bool? IsEdited { get; set; } = false;
        public int? Rent { get; set; }
        public string IsImage { get; set; }
        public string TypeName { get; set; }
        public long? ProjectId { get; set; }
    }
    public partial class AdvertisementFacilites
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Avatar { get; set; }

      //  public bool IsChecked { get; set; }
        //private bool isChecked;

        //public bool IsChecked
        //{
        //    get
        //    {
        //        return isChecked;
        //    }
        //    set
        //    {
        //        if (value != this.isChecked)
        //        {
        //            this.isChecked = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}
   
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    



        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class AdvertisementResponse
    {
        public string message { get; set; }
        public ErrorModel error { get; set; }
        public AdvertisementResponseModel result { get; set; }
        public bool success { get; set; }
    }
    public class AdvertisementResponseModel
    {
        public long? AdvertisementId { get; set; }
        public object Advertisement { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
    }
    public partial class AdvertisementForEditResponse
    {
        public AdvertisementForEditModel Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }
    public partial class AdvertisementForEditModel
    {
        public long? AdvertisementId { get; set; }

        public AdvertisementModel Advertisement { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }
    }
    public class GetLastAdvertiseResponse 
    {
        public GetLastAdvertiseResponse()
        {
            Result = new ResultLastAdvertise();
        }
        public ResultLastAdvertise Result { get; set; }
    public object TargetUrl { get; set; }
    public bool Success { get; set; }
    public string Error { get; set; }
    public bool UnAuthorizedRequest { get; set; }
    public bool Abp { get; set; }
}

public partial class ResultLastAdvertise
    {
    public long Id { get; set; }
    public bool? Success { get; set; }
    public string Error { get; set; }
    public bool? Sucess { get; set; }
}

}
