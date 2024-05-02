using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class DurationModel
    {
        public int Id { get; set; }
        public int Period { get; set; }
        public decimal Amount { get; set; }
        public int? Type { get; set; }
        public bool IsPublish { get; set; }
    }
    public class DurationsInputModel
    {
        public int Type { get; set; }
        public bool IsPublish { get; set; } = true;
        public int Start { get; set; }
        public int Length { get; set; }
    }
    public  class DurationResponseModel
    {
        public DurationResponseModel()
        {
            Result = new DurationResult();
        }
        public DurationResult Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public object Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }

    public partial class DurationResult
    {
        public DurationResult()
        {
            Durations = new List<DurationModel>();
        }
        public List<DurationModel> Durations { get; set; }

      
        public string Error { get; set; }

      
        public bool? Success { get; set; }

    }
   

}
