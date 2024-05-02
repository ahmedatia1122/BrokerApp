using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class UpdateUserPasswordModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }

    }
    public class UpdatePasswordResponseModel
    {
        public UpdatePasswordResponseModel()
        {
            Result = new UpdatePasswordResponse();
        }
        public UpdatePasswordResponse Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }
    public class UpdatePasswordResponse
    {
        public string Msg { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }
    }
}
