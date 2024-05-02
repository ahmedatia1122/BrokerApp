using NewBrokerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class RegisterModel : BindableViewModel
    {
        private long? _userId;
        public long? UserId
        {
            get { return _userId; }
            set => SetProperty(ref _userId, value);
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set => SetProperty(ref _userName, value);
        }
        private string _userSurname;
        public string UserSurname
        {
            get { return _userSurname; }
            set => SetProperty(ref _userSurname, value);
        }
        private string _userEmailAddress;
        public string UserEmailAddress
        {
            get { return _userEmailAddress; }
            set => SetProperty(ref _userEmailAddress, value);
        }
        private string _userPhoneNumber;
        public string UserPhoneNumber
        {
            get { return _userPhoneNumber; }
            set => SetProperty(ref _userPhoneNumber, value);
        }
        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set => SetProperty(ref _userPassword, value);
        }
        private string _confirmUserPassword;
        public string ConfirmUserPassword
        {
            get { return _confirmUserPassword; }
            set => SetProperty(ref _confirmUserPassword, value);
        }
        private string _avatar;
        public string Avatar
        {
            get { return _avatar; }
            set => SetProperty(ref _avatar, value);
        }
        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set => SetProperty(ref _birthDate, value);
        }
        private string _aboutAr;
        public string AboutAr
        {
            get { return _aboutAr; }
            set => SetProperty(ref _aboutAr, value);
        }
        private string _aboutEn;
        public string AboutEn
        {
            get { return _aboutEn; }
            set => SetProperty(ref _aboutEn, value);
        }
        private int? _gender;
        public int? Gender
        {
            get { return _gender; }
            set => SetProperty(ref _gender, value);
        }

    }
    public class RegisterResponse
    {
        public string message { get; set; }
        public ErrorModel error { get; set; }
        public RegisterResponseModel result { get; set; }
        public bool success { get; set; }
    }
    public class RegisterResponseModel
    {
        public RegisterModel customer { get; set; }
        public string customerId { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
    }
    public class UpdateResponse
    {
        public string message { get; set; }
        public string error { get; set; }
        public UpdateResponseModel result { get; set; }
        public bool success { get; set; }
    }
    public class UpdateResponseModel
    {
        public object brokerPerson { get; set; }
        public int brokerPersonId { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
    }

}
