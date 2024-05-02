using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public partial class PackageResponse
    {
        public PackageResponse()
        {
            Result = new PackageResponseModel();
        }
        public PackageResponseModel Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }

    public class PackageResponseModel
    {
        public PackageResponseModel()
        {
            Packages = new List<PackageModel>();
         
        }
        public List<PackageModel> Packages { get; set; }
        public PackageModel Details { get; set; }

        public string Error { get; set; }

        public bool Success { get; set; }
    }

    public partial class PackageModel
    {
        public string Name { get; set; }

        public long Price { get; set; }

        public long Points { get; set; }
        public int? CompanyBalance { get; set; }
        public int? BrolerPoints { get; set; }
        
        public long Id { get; set; }
    }

}
