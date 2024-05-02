using NewBrokerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class LoginModel : BindableViewModel
    {
        private string _userPassword;
        public string Password
        {
            get { return _userPassword; }
            set => SetProperty(ref _userPassword, value);
        }
        private string _userEmailAddress;
        public string UserNameOrEmailAddress
        {
            get { return _userEmailAddress; }
            set => SetProperty(ref _userEmailAddress, value);
        }
        private bool _rememberClient;
        public bool RememberClient
        {
            get { return _rememberClient; }
            set => SetProperty(ref _rememberClient, value);
        }
        private string _RegistrationDevice;
        public string RegistrationDevice
        {
            get { return _RegistrationDevice; }
            set => SetProperty(ref _RegistrationDevice, value);
        }
    }
    public class LoginResponseModel
    {
        public LoginResponseModel()
        {
            error = new ErrorModel();
        }
        public string message { get; set; }
        public ErrorModel error { get; set; }
        public UserLoginResponseModel result { get; set; }
        public bool success { get; set; }
    }
    public class UserLoginResponseModel
    {
        public string accessToken { get; set; }
        public string encryptedAccessToken { get; set; }
        public string errors { get; set; }
        public string error { get; set; }
        public int expireInSeconds { get; set; }
        public bool waitingForActivation { get; set; }
        public bool success { get; set; }
        public bool HasAddress { get; set; }
        public long userId { get; set; }
        public long? LoginType { get; set; }

    }
    public class ErrorModel
    {
        public List<ValidiationRegisterModel> validationErrors { get; set; }
        public string message { get; set; }
        public string details { get; set; }
    }
    public class ValidiationRegisterModel
    {
        public string message { get; set; }
        public List<string> members { get; set; }
    }

}

