using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class DiscountsResponseModel
    {
        public DiscountsResponseModel()
        {
            Result=new DiscountResult();
        }
        public DiscountResult Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }

    public partial class DiscountResult
    {
        public Discount Discount { get; set; }

        public string Error { get; set; }

        public bool Success { get; set; }
    }

    public partial class Discount
    {
        public decimal? Percentage { get; set; }

        public decimal? FixedAmount { get; set; }
    }

}