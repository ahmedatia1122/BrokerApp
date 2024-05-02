using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class PersonDetailsResponseModel
    {
        public PersonDetailsResponseModel()
        {
            Result=new PersonDetailsResult();
        }
        public PersonDetailsResult Result { get; set; }


        public object TargetUrl { get; set; }


        public bool Success { get; set; }


        public object Error { get; set; }


        public bool UnAuthorizedRequest { get; set; }


        public bool Abp { get; set; }
    }

    public partial class PersonDetailsResult
    {
        public PersonDetailsResult()
        {
            Details = new PersonDetailsModel();
        }
        public PersonDetailsModel Details { get; set; }


        public bool? Success { get; set; }


        public string Error { get; set; }


        public bool? Sucess { get; set; }
    }

    public partial class PersonDetailsModel
    {

        public string SecondMobile { get; set; }


        public bool IsWhatsApp { get; set; }
        public bool IsWhatsApped { get; set; }
        

        public long Id { get; set; }


        public string Name { get; set; }


        public string PhoneNumber { get; set; }


        public string EmailAddress { get; set; }
        public string Avatar { get; set; }
        public MediaFile PrfilAvatar { get; set; }
    }
    public class PersonDetailsInput
    {
        public long Id { get; set; }
        public string SecondMobile { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmailAddress { get; set; }
        public string UserPhoneNumber { get; set; }
        public string Avatar { get; set; }
        public bool IsWhatsApp { get; set; }

    }
}