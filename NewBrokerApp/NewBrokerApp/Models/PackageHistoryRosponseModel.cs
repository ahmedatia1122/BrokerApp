using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class PackageHistoryRosponseModel
    {
        public PackageHistoryRosponseModel()
        {
            Result = new PackageHistoryResult();
        }
        [JsonProperty("result")]
        public PackageHistoryResult Result { get; set; }

        [JsonProperty("targetUrl")]
        public object TargetUrl { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("unAuthorizedRequest")]
        public bool UnAuthorizedRequest { get; set; }

        [JsonProperty("__abp")]
        public bool Abp { get; set; }
    }

    public partial class PackageHistoryResult
    {
        public PackageHistoryResult()
        {
            Details = new PackageHistoryDetails();
            PackagesHistory = new List<PackagesHistory>();
        }
        [JsonProperty("details")]
        public PackageHistoryDetails Details { get; set; }

        [JsonProperty("packagesHistory")]
        public List<PackagesHistory> PackagesHistory { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }

    public partial class PackageHistoryDetails
    {
        [JsonProperty("companyBalance")]
        public long CompanyBalance { get; set; }

        [JsonProperty("brolerPoints")]
        public long BrolerPoints { get; set; }
    }

    public partial class PackagesHistory
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("subscriptionDate")]
        public DateTime SubscriptionDate { get; set; }
    }
}