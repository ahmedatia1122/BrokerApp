using NewBrokerApp.Resources;
using System;
using System.Collections.Generic;

namespace NewBrokerApp.Models
{
    public class AddDetailsModel
    {
        public string Title { get; set; }
        public string GovernorateName { get; set; }
        public int Type { get; set; }
        //public int PropertyId { get; set; }
        //public Definition Property { get; set; }
        public long? CityId { get; set; }
        //public CityDto City { get; set; }
        public string Compound { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? FloorsNumber { get; set; }
        public string Area { get; set; }
        public decimal? BuildingArea { get; set; }
        public int? ChaletType { get; set; }

        public string BuildingStatus { get; set; }
        public string LandingStatus { get; set; }
        public int? UsingFor { get; set; }
        public decimal? StreetWidth { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public DateTime? BuildingDate { get; set; }
        public int? Rooms { get; set; }
        public int? Reception { get; set; }
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
        //public OwnerDto Owner { get; set; }
        public long? CompanyId { get; set; }
        //public CompanyDto Company { get; set; }
        public long? BrokerPersonId { get; set; }
        //public BrokerPersonDto BrokerPerson { get; set; }
        public bool IsPublish { get; set; }
        public bool? IsApprove { get; set; }
        public string Description { get; set; }
        public bool? FeaturedAd { get; set; }
        public string Price { get; set; }
        public int? PaymentFacility { get; set; }
        // public MrMrsType? MrMrs { get; set; }
        public string AdvertiseMakerName { get; set; }
        public string AdvertiseMaker { get; set; }
        public string MobileNumber { get; set; }
        public string IsWhatsApped { get; set; }
        public bool? WhatsApped { get; set; }
        public string SecondMobileNumber { get; set; }
        public bool ContactRegisterInTheAccount { get; set; }

        public decimal? ParkingSpace { get; set; }
        public string Garden { get; set; }
        public decimal? GardenArea { get; set; }
        public string Pool { get; set; }
        public string Shop { get; set; }
        public int? ShopsNumber { get; set; }
        public int? Dinning { get; set; }
        public int? Rent { get; set; }
        public string DiningRoom { get; set; }
        public string Decoration { get; set; }
        public string Document { get; set; }
        public double? ViewsCount { get; set; }
        public string AgreementStatus { get; set; }
        public string Furnished { get; set; }
        public string Elevator { get; set; }
        public string Parking { get; set; }
        public string PropertyFor { get; set; }
       public bool? ShowChalet { get; set; }
        public Facilite[] Facilites { get; set; }
        public Facilite[] NewFacilites { get; set; }

        public Uri[] Photos { get; set; }
        public Uri[] Layouts { get; set; }

        public string DocumentName { get; set; }

        public bool? ShowMonth { get; set; }
        public int? numOfMonths { get; set; }
        public bool ShowSellOrRent { get; set; }
        public long? Id { get; set; }
        public List<DateTime> AdvertisementBookings { get; set; }
        public int? AgreementStatusId { get; set; }
        public string RentValue { get; set; }
        public bool IsCompany { get; set; }

        public string CompanyLogo { get; set; }

        public string CompanyAbout { get; set; }

        public string CompanyFacebook { get; set; }

        public string CompanyInstagram { get; set; }

        public string CompanySnapchat { get; set; }

        public string CompanyTiktok { get; set; }

        public string CompanyWebsite { get; set; }
        public double? CompanyLatitude { get; set; }
        public double? CompanyLongitude { get; set; }
        
        public long? DownPayment { get; set; }

        public long? MonthlyInstallment { get; set; }

        public long? YearlyInstallment { get; set; }

        public long? NumOfYears { get; set; }

        public DateTime? DeliveryDate { get; set; }
      
        public string ShowRentValue { get; set; }
        public int? ChaletRentType { get; set; }
        public int? Officies { get; set; }
        public string CompanyName { get; set; }
        public string UsingForString { get; set; }
        //  public String BuildingDatestring { get { return BuildingDate != null ? BuildingDate.ToString("dd-MM-yyyy") : ""; } }
        public string UsingForName 
        {
            get
            {
                if (UsingFor != null)
                {
                    return UsingFor == 1 ? AppResources.Buildings : UsingFor == 2 ? AppResources.Industrial : UsingFor == 3 ? AppResources.Agriculture : UsingFor == 4 ? AppResources.Investment : UsingFor == 5 ? AppResources.Residential : UsingFor == 6 ? AppResources.Commercial : "";

                }
                else
                {
                    return "";
                }


            }
        }

        public bool IsFavourite { get; set; }
        public string ShowImage { get { return IsFavourite == true ? "fav.png" : "heart.png"; } }
         
        public string OfficeType
        {
            get
            {

                return Officies == 1 ? AppResources.Company : Officies == 2 ? AppResources.Factory : "";

            }
        }
        //public string RentValueName
        //{
        //    get
        //    {

        //        return Rent == 3 ? AppResources.monthly : Rent == 4 ? AppResources.midterm : Rent == 5 ? AppResources.annual :"";

        //    }
        //}

    }

    public partial class Facilite
    {
        
        public string Name { get; set; }

        public object Description { get; set; }

        public string Avatar { get; set; }
        public string AvatarSvg { get; set; }
        public string IsChecked { get; set; }
    }
    public partial class AddDetailsResult
    {
        public AddDetailsResult()
        {
            Details = new AddDetailsModel();
        }
        public AddDetailsModel Details { get; set; }

      
        public bool? Success { get; set; }

        public string Error { get; set; }

   
        public bool? Sucess { get; set; }
    }
    public partial class AddDetailsResponse
    {
        public AddDetailsResult Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }
}
