using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
  public  class CompanyBalanceRivalResponse
    {
        public CompanyBalanceRivalResponse()
        {
            Result = new CompanyBalanceRivalResult();
        }
        [JsonProperty("result")]
        public CompanyBalanceRivalResult Result { get; set; }

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

    public partial class CompanyBalanceRivalResult
    {
        [JsonProperty("companyId")]
        public long CompanyId { get; set; }

        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
    

}

