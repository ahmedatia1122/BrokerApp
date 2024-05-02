using NewBrokerApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
   public class NotificationModel
    {
       
        public string Description { get; set; }

     
        public string Date { get; set; }

        
        public long Id { get; set; }
    }
    public class NotificationModelResponse
    {
        public NotificationModelResponse()
        {
            Result = new NotificationResult();
        }
        [JsonProperty("result")]
        public NotificationResult Result { get; set; }

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
    
}

public partial class NotificationResult
{
    public NotificationResult()
    {
        Notifications = new List<NotificationModel>();
    }
  
    public List<NotificationModel> Notifications { get; set; }

    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("error")]
    public string Error { get; set; }
}



