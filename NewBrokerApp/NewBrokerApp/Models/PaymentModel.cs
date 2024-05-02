using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class PaymentModel
    {
    }
    public partial class PaymentResponseModel
    {
        public PaymentResponseModel()
        {
            Result = new PaymentResult();
        }
        public PaymentResult Result { get; set; }

        public object TargetUrl { get; set; }
        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }

    public partial class PaymentResult
    {
        public string Url { get; set; }
        public bool? IsSuccess { get; set; }
        public bool? Sucess { get; set; }
        public string Error { get; set; }
    }
    public class PaymentInput
    {
        public long UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
