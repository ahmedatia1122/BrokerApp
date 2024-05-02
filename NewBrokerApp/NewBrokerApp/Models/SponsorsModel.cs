using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public partial class SponsorsResponseModel
    {
        public SponsorsResponseModel()
        {
            Result = new SponsorsResponseResult();
        }
        public SponsorsResponseResult Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }

    public partial class SponsorsResponseResult
    {
        public SponsorsResponseResult()
        {
            Sponsors = new List<SponsorModel>();
        }
        public List<SponsorModel> Sponsors { get; set; }

        public string Error { get; set; }

        public bool Success { get; set; }
    }

    public partial class SponsorModel
    {
        public string SecondMobile { get; set; }

        public long UserId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public long Id { get; set; }
        public string Photo { get; set; }
    }
    public class DeleteAccountResponse
    {
        public DeleteAccountResponse()
        {
            Result = new DeleteAccountResult();
        }
        public DeleteAccountResult Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }
    public partial class DeleteAccountResult
    {

        public string Message { get; set; }


        public string Error { get; set; }


        public bool? Success { get; set; }


        public bool? Sucess { get; set; }
    }
    public class ButtonModel
    {
        public string ButtonText { get; set; }
        public int PropertyId { get; set; }
        public int ArgumentId { get; set; }
    }

}