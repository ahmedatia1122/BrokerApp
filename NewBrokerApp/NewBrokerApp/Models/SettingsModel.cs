using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class SettingsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string About { get; set; }
        public string Avatar { get; set; }
    }
    public class SettingsResponse
    {
        public SettingsResponceModel result { get; set; }
        public ErrorModel error { get; set; }
        public bool success { get; set; }
    }
    public class SettingsResponceModel
    {
        public SettingsModel setting { get; set; }
        public string error { get; set; }
        public bool Unauthorize { get; set; }
        public bool success { get; set; }
    }
    public partial class CheckUserResponse
    {
        public CheckUserResponse()
        {
            Result = new CheckUserResult();
        }

        public CheckUserResult Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }

    public partial class CheckUserResult
    {
        public bool Exist { get; set; }

        public string Error { get; set; }

        public bool? Success { get; set; }

        public bool? Sucess { get; set; }
    }

}
