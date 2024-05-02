using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
  public  class AppoimentPointsResponse
    {
        public PointsResult Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }

    public partial class PointsResult
    {
        public PointsResult()
        {
            Advertisements = new List<AdvertisementPoint>();
        }
        public List<AdvertisementPoint> Advertisements { get; set; }
        public long? TotalPoints { get; set; }
        public bool? Success { get; set; }
        public string Error { get; set; }
        public bool? Sucess { get; set; }
    }

    public partial class AdvertisementPoint
    {
       
        public long Id { get; set; }
        public string Title { get; set; }
        public long Points { get; set; }
    }

}

