using NewBrokerApp.Helpers;
using NewBrokerApp.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class AddModel
    {
        public AddModel()
        {
            Result=new AddResult();
        }
        public AddResult Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }
    public partial class AddResult
    {
        public AddResult()
        {
            Advertisements=new List<Advertisement>();
        }
        public List<Advertisement> Advertisements { get; set; }
        public bool? Success { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        public bool? Sucess { get; set; }
    }
    public class Advertisement
    {
        public Advertisement()
        {
            Photos = new List<string>();
        }
        public string Title { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsPublish { get; set; }
        public long ViewCount { get; set; }
        public List<string> Photos { get; set; }
        public long Id { get; set; }
        public string IsplayImage { get; set; }
        public string IsStopImage { get; set; }
        public string Price { get; set; }
        public bool? IsApproved { get; set; }
        public string StatusPublish { get; set; }
        public string ImageStatusPublish { get; set; }
        public string StatusApproved { get; set; }
        public bool? FeaturedAd { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
        public string BackgroundImage { get; set; }
        public bool? IsCompany { get; set; }
        public string CompanyLogo { get; set; }
        public string BackgroundImagee
        {
            get
            {
                return FeaturedAd == false || FeaturedAd == null ? "Pin_Bluee.png" : "goldpin.png";
            }
        }
    public int? ExpireStatus { get; set; }
        

        public bool IsNoCompany
        {
            get
            {
                return IsCompany == true  ? false :true;
            }
        }
        public int CompanyWidth => IsCompany == true ? 150 : 120;
        public int CompanyHeight => IsCompany == true ? 150 : 120;
        public int ZIndex => FeaturedAd == true ? 1 : 0;
        public string AdStatus => ExpireStatus == (int)AdsStatus.NotExpired && IsApproved==true ? AppResources.adActive : ExpireStatus == (int)AdsStatus.Expired ? AppResources.Expired: IsApproved == false? AppResources.rejected : AppResources.Pending;
        public string AdStatusColor=> ExpireStatus == (int)AdsStatus.NotExpired && IsApproved == true ? "#35950c" : ExpireStatus == (int)AdsStatus.Expired ? "#FF0000" : "#0b5394";
    }
    // public enum EnumExpireStatus
    public enum AdsStatus
    {
        Pending = 1,
        NotExpired = 2,
        Expired = 3,
    }
    public class AddInputModel
    {
        public int? BrokerId { get; set; }
        public int? SeekerId { get; set; }
        public int? OwnerId { get; set; }
        public int? CompanyId { get; set; }

    }
    public class FavouritesInputModel
    {
        public int UserId { get; set; }
      

    }
    public class AdvertisementInputModel
    {
    public string Name { get; set; }
    public int? AgreementStatus { get; set; }
        public int? Type { get; set; }
        public long? CityId { get; set; }
        //public string Compound { get; set; }
        public string StreetOrCompund { get; set; }
        public int? Rooms { get; set; }
        public string Area { get; set; }
        public int? Decoration { get; set; }
        public bool? Furnished { get; set; }
        public bool? Parking { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public decimal? AreaFrom { get; set; }
        public decimal? AreaTo { get; set; }
        public long? CompanyIdLocation { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
    public class DeleteAddResponse
    {
        public DeleteAddResponse()
        {
            Result = new DeleteAddResult();
        }
        public DeleteAddResult Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }
    public class ChangeAddStatusResponse
    {
        public ChangeAddStatusResponse()
        {
            Result = new ActiveAddResult();
        }
        public ActiveAddResult Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }

    public partial class DeleteAddResult
    {
      
        public string Message { get; set; }

      
        public string Error { get; set; }

      
        public bool? Success { get; set; }


        public bool? Sucess { get; set; }
    }
    public partial class ActiveAddResult
    {
        public long? AdvertiseId { get; set; }
        public bool? ActiveStatus { get; set; }

        public string Message { get; set; }


        public string Error { get; set; }


        public bool? Success { get; set; }


        public bool? Sucess { get; set; }
    }
    public partial class CheckPropertyStatusResponse
    {
        public CheckPropertyStatusResponse()
        {
            Result = new CheckPropertyStatusResult();
        }


        public CheckPropertyStatusResult Result { get; set; }

       
        public object TargetUrl { get; set; }

       
        public bool Success { get; set; }

       
        public string Error { get; set; }

     
        public bool UnAuthorizedRequest { get; set; }

      
        public bool Abp { get; set; }
    }

    public partial class CheckPropertyStatusResult
    {
       
        public bool? Status { get; set; }

      
        public string Error { get; set; }

      
        public bool? Success { get; set; }

      
        public bool? Sucess { get; set; }
    }


}

