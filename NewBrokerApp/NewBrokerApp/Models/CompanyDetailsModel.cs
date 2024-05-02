using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class CompanyDetailsResponseModel
    {
        public CompanyDetailsResponseModel()
        {
            Result=new CompanyDetailsResult();
        }
        public CompanyDetailsResult Result { get; set; }


        public object TargetUrl { get; set; }


        public bool Success { get; set; }


        public string Error { get; set; }


        public bool UnAuthorizedRequest { get; set; }


        public bool Abp { get; set; }
    }

    public partial class CompanyDetailsResult
    {
        public CompanyDetailsResult()
        {
            Details = new CompanyDetailsModel();
        }
        public CompanyDetailsModel Details { get; set; }


        public bool? Success { get; set; }


        public string Error { get; set; }


        public bool? Sucess { get; set; }
    }

    public partial class CompanyDetailsModel
    {

        public string SecondMobile { get; set; }

        public bool IsWhatsApped { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Avatar { get; set; }
        public string Logo { get; set; }

        public string BwLogo { get; set; }

        public string CommericalAvatar { get; set; }

        public bool IsSponser { get; set; }

        public bool IsActive { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public string Snapchat { get; set; }

        public string Tiktok { get; set; }

        public string Website { get; set; }

        public string AboutAr { get; set; }

        public string AboutEn { get; set; }

        public string About { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
        public MediaFile PictureLogo { get; set; }

        public MediaFile PictureBwLogo { get; set; }
        public MediaFile PictureCommericalAvatar { get; set; }
        public MediaFile PictureAvatar { get; set; }
        public long? PackageId { get; set; }
        public int? Balance { get; set; }
        public bool? IsPackageRenwed { get; set; }
        
    }
    public class CompanyDetailsInput
    {
        public long Id { get; set; }

        public string SecondMobile { get; set; }        
        public string Logo { get; set; }

        public string BwLogo { get; set; }

        public string CommericalAvatar { get; set; }

        public string About { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public string Snapchat { get; set; }

        public string Tiktok { get; set; }

        public string Website { get; set; }

        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public string UserEmailAddress { get; set; }

        public string UserPhoneNumber { get; set; }

        public long? PackageId { get; set; }
        
    }
}