using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class ContactUsModel
    {
    }
    public class ContactUsInput
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Attachment { get; set; }
    }
    public class ContactUsResponse{

        public ContactUsResponse()
        {
            Result = new ContactUsResult();
        }
        public ContactUsResult Result { get; set; }

   
    public object TargetUrl { get; set; }

   
    public bool Success { get; set; }

   
    public string Error { get; set; }


    public bool UnAuthorizedRequest { get; set; }


    public bool Abp { get; set; }
}

public partial class ContactUsResult
{
   
    public long? ContactUsId { get; set; }


    public bool? Success { get; set; }

  
    public string Error { get; set; }


    public bool? Sucess { get; set; }
}

}
