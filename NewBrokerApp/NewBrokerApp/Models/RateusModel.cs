using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class RateusModel
    {
        public RateusModel()
        {
            Result = new RateResult();
        }
        public RateResult Result { get; set; }


        public object TargetUrl { get; set; }


        public bool Success { get; set; }


        public string Error { get; set; }


        public bool UnAuthorizedRequest { get; set; }


        public bool Abp { get; set; }
    }

    public partial class RateResult
    {

        public long? RateId { get; set; }


        public bool? Success { get; set; }


        public string Error { get; set; }


        public bool? Sucess { get; set; }

    }
    public  class RateUsInput
    {
        public int UserRate { get; set; }
        public long UserId { get; set; }
    }
}
