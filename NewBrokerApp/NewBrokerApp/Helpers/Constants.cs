using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace NewBrokerApp.Helpers
{
    public class Constants
    {
        public static string ApiURL = "https://brokerapi.nahrdev.website";
        public static object NavigationParamter;
        public static object NavigationProject;
        public static object FeaturePrice;
        public static int SelectedIndex = 0;
        public static string TokenH = string.Empty;
        public static string UserId = string.Empty;
        public static int LoginType = 0;
        public static string UserEmail = string.Empty;
        public static string UserMobileNumber = string.Empty;
        public static string UserVerifyCode = string.Empty;
        public static long? BrokerId;
        public static long? SeekerId;
        public static long? OwnerId;
        public static long? CompanyId;
        public static int? PropertyType = 0;
        public static int? CityId = 0;
        public static int? Rooms = 0;
        public static int? FinishedId = 0;
        public static bool? Parking;
        public static bool? Furnished;
        public static bool? SearchPropetry;
        public static string Street;
        public static decimal AreaFrom;
        public static decimal AreaTo;
        public static decimal PriceFrom;
        public static decimal PriceTo;
        public static int? ArgmentStatus = 0;
        public static object NavigationAdvertiserModel;
        public static object AdvertisementParamter;
        public static bool ShowMobile;
        public static bool ShowEmail;
        public static int TotalPrice;
        public static long? PackageId;
        public static int? Balance;
        public static string title;
        public static int screenHeigth { get; set; }
        public static int PaymentStatus { get; set; }
        public static string TypeName { get; set; }
        public static string Longitude { get; set; }
        public static string Latitude { get; set; }
        public static string MobileNumber { get; set; }
        public static long? CompanyIdLocation = 0;
        public static object ProjectId;
        public static double? Companylat = 0;
        public static double? Companylong = 0;
        public static string DeviceToken { get; set; }
        public static int CompanyBalance;
        public static bool NoInternet { get; set; }
        public static bool BackToPaymentCompany { get; set; } = false;
        public static bool IsPaidWithWallet { get; set; } = false;
        public static bool? UpdateMobile { get; set; }
        public static bool? VerifySecondMobile { get; set; }=true;
        public static bool IsFavourite { get; set; } 
        
    }
}
