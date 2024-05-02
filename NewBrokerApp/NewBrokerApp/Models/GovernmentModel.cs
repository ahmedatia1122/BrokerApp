using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
   public class GovernmentModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class GovernmentsInputModel
    {

        public string Keyword { get; set; }
       
        public int Start { get; set; }
        public int Length { get; set; }
    }
    public partial class GovernmentsResponseModel
    {
        public GovernoratesResponse Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }

    public partial class GovernoratesResponse
    {
        public GovernoratesResponse()
        {
            Governorates = new List<GovernmentModel>();
        }
        public List<GovernmentModel> Governorates { get; set; }
        public string Error { get; set; }
        public bool Unauthorize { get; set; }
        public bool Success { get; set; }
    }
}
