using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class SocialMediaModel
    {
        public string SocialName { get; set; }
        public string SocialValue { get; set; }
        public string Avatar { get; set; }
    }
    public class SocialMediaReponse
    {
        public SocialMediaReponse()
        {
            Result=new SocialResult();
        }

        public SocialResult Result { get; set; }

       
        public object TargetUrl { get; set; }

        
        public bool Success { get; set; }

     
        public string Error { get; set; }


        public bool UnAuthorizedRequest { get; set; }

    
        public bool Abp { get; set; }
    }

    public partial class SocialResult
    {
        public SocialResult()
        {
            SocialContacts = new List<SocialMediaModel>();
        }
        public List<SocialMediaModel> SocialContacts { get; set; }

      
        public string Error { get; set; }

       
        public bool? Success { get; set; }

        public bool? Sucess { get; set; }
    }
}

