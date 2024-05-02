using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class ChartResponseModel
    {
        public ChartResponseModel()
        {
            Result=new ChartResult();
        }
        public ChartResult Result { get; set; }
        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }
    public partial class ChartResult
    {
        public ChartResult()
        {
            Counts = new List<double>();
        }
        public List<double> Counts { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }
    }
    public class dataChart
    {
        public int Day { get; set; }
        public int Value { get; set; }
    }

}