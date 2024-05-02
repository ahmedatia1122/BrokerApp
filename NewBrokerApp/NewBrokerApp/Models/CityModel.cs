using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
   public class CityModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class CitiesInputModel
    {

        public string Keyword { get; set; }
       public int GovermentId { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
    }
    public partial class CitiesResponseModel
    {
        public CitiesResponse Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }

    public partial class CitiesResponse
    {
        public CitiesResponse()
        {
            Cities = new List<CityModel>();
        }
        public List<CityModel> Cities { get; set; }
        public string Error { get; set; }
        public bool Unauthorize { get; set; }
        public bool Success { get; set; }
    }
}
