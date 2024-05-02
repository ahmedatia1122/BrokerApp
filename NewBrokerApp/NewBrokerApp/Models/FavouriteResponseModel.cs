using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class FavouriteResponseModel
    {
        public FavouriteResponseModel()
        {
            Result=new FavouriteResponseResult();
        }
        public FavouriteResponseResult Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }
    public partial class FavouriteResponseResult
    {
        public FavouriteResponseResult()
        {
            Favorites = new List<Favourite>();
        }
        public List<Favourite> Favorites { get; set; }
        public bool? Success { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        public bool? Sucess { get; set; }
    }
    public class Favourite
    {
        public Favourite()
        {
            Photos = new List<string>();
        }
        public string Title { get; set; }
        public long? Longitude { get; set; }
        public long? Latitude { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsPublish { get; set; }
        public long ViewCount { get; set; }
        public List<string> Photos { get; set; }
        public long Id { get; set; }
        public string IsplayImage { get; set; }
        public string IsStopImage { get; set; }
        public string Price { get; set; }
        public long AdvertisementId { get; set; }
        public string MobileNumber { get; set; }
        public bool IsWhatsApped { get; set; }
  

    }

   

}

