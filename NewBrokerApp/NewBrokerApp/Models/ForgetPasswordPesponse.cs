using NewBrokerApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class ForgetPasswordPesponse
    {
        public ForgetPasswordPesponse()
        {
            Error = new ForgetPasswordError();
        }

        public string Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public ForgetPasswordError Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }
    public class ForgetPasswordError
    {
        public long Code { get; set; }
        public string Message { get; set; }
        public object Details { get; set; }
        public object ValidationErrors { get; set; }
    }
    public partial class ForgetPasswordResult
    {
        public bool Sucess { get; set; }
        public string Error { get; set; }
    }
    public class ForgetPasswordInput : BindableViewModel
    {

        private string _userNameOrEmailAddress;
        public string UserNameOrEmailAddress
        {
            get { return _userNameOrEmailAddress; }
            set => SetProperty(ref _userNameOrEmailAddress, value);
        }
      
    }

}
