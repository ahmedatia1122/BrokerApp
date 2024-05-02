using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace NewBrokerApp.Models
{
    public partial class VerifyOtpResponse
    {
        public VerifyOtpResponseModel Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }
    public partial class VerifyOtpResponseModel
    {
        public string Message { get; set; }

        public long Otp { get; set; }

        public bool IsSuccess { get; set; }
    }

}
