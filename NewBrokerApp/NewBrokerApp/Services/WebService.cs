using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using Polly;
using RestSharp;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using Xamarin.Forms;
using NewBrokerApp.Resources;
using Xamarin.Essentials;
using DevExpress.Utils.Commands;
using System.Globalization;
using System.Threading;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NewBrokerApp.Services
{
    public class WebService : IWebService
    {
        public WebService()
        {
          
        }
     
      
        HttpClient httpClient = new HttpClient();
        private void SendAsync<T>(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }
      

        public async Task<LoginResponseModel> Login(LoginModel loginModel)
        {
            LoginResponseModel result = new LoginResponseModel();
            try
            {
                //  AddingHeaders();

                var json = JsonConvert.SerializeObject(loginModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/TokenAuth/AuthenticateInMobile");
                request.Content = content;
                var response = await httpClient.SendAsync<LoginResponseModel>(request);
                if (response.Value != null)
                {
                    result = response.Value;
                }
                if (result?.result?.accessToken != null)
                {
                    Constants.TokenH = result?.result?.accessToken;
                    httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", Constants.TokenH);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<RegisterResponse> RegisterBroker(RegisterModel registerModel)
        {
            RegisterResponse result = new RegisterResponse();
            try
            {
                AddingHeaders();

                var json = JsonConvert.SerializeObject(registerModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/BrokerPerson/CreateBrokerPerson");
                request.Content = content;
                var response = await httpClient.SendAsync<RegisterResponse>(request);
                if (response.Value != null)
                {
                    result = response.Value;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<RegisterResponse> RegisterSeeker(RegisterModel registerModel)
        {
            RegisterResponse result = new RegisterResponse();
            try
            {
                AddingHeaders();

                var json = JsonConvert.SerializeObject(registerModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Seeker/CreateSeeker");
                request.Content = content;
                var response = await httpClient.SendAsync<RegisterResponse>(request);
                if (response.Value != null)
                {
                    result = response.Value;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<RegisterResponse> RegisterOwner(RegisterModel registerModel)
        {
            RegisterResponse result = new RegisterResponse();
            try
            {
                AddingHeaders();

                var json = JsonConvert.SerializeObject(registerModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Owner/CreateOwner");
                request.Content = content;
                var response = await httpClient.SendAsync<RegisterResponse>(request);
                if (response.Value != null)
                {
                    result = response.Value;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<RegisterResponse> RegisterCompany(RegisterModel registerModel)
        {
            RegisterResponse result = new RegisterResponse();
            try
            {
                AddingHeaders();

                var json = JsonConvert.SerializeObject(registerModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Company/CreateCompany");
                request.Content = content;
                var response = await httpClient.SendAsync<RegisterResponse>(request);
                if (response.Value != null)
                {
                    result = response.Value;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<DefinitionsResponseModel> GetDefinitionList(DefinitionsInputModel input)
        {
            DefinitionsResponseModel result = new DefinitionsResponseModel();
            try
            {

                AddingHeaders();
                var json = JsonConvert.SerializeObject(new
                {
                    keyword = input.Keyword,
                    type = input.Type,
                    start = input.Start,
                    length = input.Length,
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Common/GetAllDefinitions");
                request.Content = content;
                var response = await httpClient.
                        SendAsync<DefinitionsResponseModel>(request);

                result = response.Value;
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<AdvertisementResponse> ManageAdvertisement(AdvertisementModel advertisementModel)
        {
            AdvertisementResponse result = new AdvertisementResponse();
            try
            {
                AddingHeaders();
                advertisementModel.CityId = null;
                var json = JsonConvert.SerializeObject(advertisementModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Advertisement/CreateAdvertisement");
                request.Content = content;
                var response = await httpClient.SendAsync<AdvertisementResponse>(request);
                if (response.Value != null)
                {
                    result = response.Value;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        void AddingHeaders()
        {
            string lang = string.Empty;
            if (Constants.SelectedIndex != 1)
                lang = "en";
            else
                lang = "ar";
            if (!httpClient.DefaultRequestHeaders.Contains("LanguageCode"))
                httpClient.DefaultRequestHeaders.Add("LanguageCode", lang);
            else
            {
                httpClient.DefaultRequestHeaders.Remove("LanguageCode");
                httpClient.DefaultRequestHeaders.Add("LanguageCode", lang);

            }
            if (!httpClient.DefaultRequestHeaders.Contains("X-Requested-With"))
                httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            if (!string.IsNullOrEmpty(Constants.TokenH))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.TokenH);
        }

        public async Task<CitiesResponseModel> GetAllCities(CitiesInputModel input)
        {

            CitiesResponseModel result = new CitiesResponseModel();
            try
            {

                AddingHeaders();
                var json = JsonConvert.SerializeObject(new
                {
                    keyword = input.Keyword,
                    start = input.Start,
                    length = input.Length,
                    governorateId=input.GovermentId
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Common/GetAllCities");
                request.Content = content;
                var response = await httpClient.
                        SendAsync<CitiesResponseModel>(request);

                result = response.Value;
            }
            catch (Exception ex)
            {
            }
            return result;

        }
        public async Task<PersonDetailsResponseModel> GetBrokerSettings(long userId)
        {
            PersonDetailsResponseModel result = new PersonDetailsResponseModel();
            try
            {
                AddingHeaders();

                var values = new JObject();
                values.Add("UserId", userId);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/BrokerPerson/GetBrokerPersonDetails");
                var response = await httpClient.
                        SendAsync<PersonDetailsResponseModel>(request);

                if (response.Value != null)
                {
                    result = response.Value;
                }
                else
                {
                    SignOut();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<PersonDetailsResponseModel> GetSeekerSettings(long userId)
        {
            PersonDetailsResponseModel result = new PersonDetailsResponseModel();
            try
            {
                AddingHeaders();

                var values = new JObject();
                values.Add("UserId", userId);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Seeker/GetSeekerDetails");
                var response = await httpClient.
                        SendAsync<PersonDetailsResponseModel>(request);

                if (response.Value != null)
                {
                    result = response.Value;
                }
                else
                {
                    SignOut();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<PersonDetailsResponseModel> GetOwnerSettings(long userId)
        {
            PersonDetailsResponseModel result = new PersonDetailsResponseModel();
            try
            {
                AddingHeaders();

                var values = new JObject();
                values.Add("UserId", userId);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Owner/GetOwnerDetails");
                var response = await httpClient.
                        SendAsync<PersonDetailsResponseModel>(request);

                if (response.Value != null)
                {
                    result = response.Value;
                }
                else
                {
                    SignOut();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<CompanyDetailsResponseModel> GetCompanySettings(long userId)
        {
            CompanyDetailsResponseModel result = new CompanyDetailsResponseModel();
            try
            {
                AddingHeaders();

                var values = new JObject();
                values.Add("UserId", userId);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Company/GetCompanyDetails");
                var response = await httpClient.
                        SendAsync<CompanyDetailsResponseModel>(request);

                if (response.Value != null)
                {
                    result = response.Value;
                }
                else
                {
                    SignOut();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        private async void SignOut()
        {
            Application.Current.Properties.Remove("TokenAccess");
            await Application.Current.SavePropertiesAsync();
            Constants.TokenH = null;
            //Application.Current.MainPage = new NavigationPage(new CustomerLoginPage());
            // await Shell.Current.Navigation.PushAsync(new OnBoardingPage());
            //await Shell.Current.GoToAsync($"//{nameof(Views.LoginPage)}");
            return;
        }
        public async Task<DurationResponseModel> GetAllDurations(DurationsInputModel input)
        {

            DurationResponseModel result = new DurationResponseModel();
            try
            {

                AddingHeaders();
                var json = JsonConvert.SerializeObject(new
                {
                    Type = input.Type,
                    IsPublish = input.IsPublish,
                    start = input.Start,
                    length = input.Length,
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Common/GetAllDurations");
                request.Content = content;
                var response = await httpClient.
                        SendAsync<DurationResponseModel>(request);

                result = response.Value;
            }
            catch (Exception ex)
            {
            }
            return result;

        }

        public async Task<CheckUserResponse> CheckIsEmailOrPhoneExist(string EmailOrPhone)
        {
            CheckUserResponse result = new CheckUserResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("phoneOrEmail", EmailOrPhone);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Common/IsEmailOrPhoneExist", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<CheckUserResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;

        }

        public async Task<AddModel> GetAllAdds(AddInputModel input)
        {
            AddModel result = new AddModel();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("brokerId", Constants.BrokerId);
                    values.Add("seekerId", Constants.SeekerId);
                    values.Add("ownerId", Constants.OwnerId);
                    values.Add("companyId", Constants.CompanyId);

                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/GetAllAdsByUserIdApi", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<AddModel>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<DeleteAddResponse> DeleteAdd(long AddId)
        {
            DeleteAddResponse result = new DeleteAddResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    HttpContent content = new StringContent(AddId.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/DeleteAdById", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<DeleteAddResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<ChangeAddStatusResponse> ChangeAddStatus(long AddId)
        {

            ChangeAddStatusResponse result = new ChangeAddStatusResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    HttpContent content = new StringContent(AddId.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/ChangeActiveStatus", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<ChangeAddStatusResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<DeleteAddResponse> ClearAllAdds()
        {
            DeleteAddResponse result = new DeleteAddResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("brokerId", Constants.BrokerId);
                    values.Add("seekerId", Constants.SeekerId);
                    values.Add("ownerId", Constants.OwnerId);
                    values.Add("companyId", Constants.CompanyId);

                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/ClearAllByUserId", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<DeleteAddResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<AddViewerResponse> CreateAddViewer(AddViewerModel input)
        {
            AddViewerResponse result = new AddViewerResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("deviceToken", input.DeviceToken);
                    values.Add("userId", input.UserId);
                    values.Add("advertisementId", input.AdvertisementId);


                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/CreateViewApi", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<AddViewerResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<CreateFavouriteResponse> CreateFavourite(CreateFavouriteInput input)
        {
            CreateFavouriteResponse result = new CreateFavouriteResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("userId", input.UserId);
                    values.Add("advertisementId", input.AdvertisementId);


                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/CreateFavoriteApi", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<CreateFavouriteResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<AddDetailsResponse> GetAddDetails(long AddId)
        {
            AddDetailsResponse result = new AddDetailsResponse();
            try
            {
               
                using (HttpClient client = new HttpClient())

                {
                   
                    string lang = string.Empty;
                    if (Constants.SelectedIndex != 1)
                        lang = "en";
                    else
                        lang = "ar";
                    if (!client.DefaultRequestHeaders.Contains("LanguageCode"))
                        client.DefaultRequestHeaders.Add("LanguageCode", lang);
                    else
                    {
                        client.DefaultRequestHeaders.Remove("LanguageCode");
                        client.DefaultRequestHeaders.Add("LanguageCode", lang);

                    }
                    var values = new JObject();
                    values.Add("advertiseId", AddId);
                    values.Add("userId",(!string.IsNullOrEmpty(Constants.UserId)? Convert.ToInt32(Constants.UserId):0));
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/GetAdvertiseDetails", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<AddDetailsResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<FavouriteResponseModel> GetAllFavourites(FavouritesInputModel input)
        {
            FavouriteResponseModel result = new FavouriteResponseModel();
            try
            {
                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("userId", input.UserId);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/GetAllFavoritesForUser", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<FavouriteResponseModel>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<AddModel> GetAllAdvertisements(AdvertisementInputModel input)
        {
            AddModel result = new AddModel();
            try
            {
                var json = JsonConvert.SerializeObject(input);
                var contetnt = new StringContent(json, Encoding.UTF8, "application/json");



                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Advertisement/GetAllAdvertisements");
                request.Content = contetnt;


                var response = await httpClient.
             SendAsync<AddModel>(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = response.Value;
                }
                else
                {
                    Debug.WriteLine(response.Error.Message);
                }
                //using (HttpClient client = new HttpClient())

                //{
                //    var values = new JObject();
                //    values.Add("Name", input.Name);
                //    values.Add("AgreementStatus", input.AgreementStatus);
                //    values.Add("type", input.Type);
                //    values.Add("cityId", input.CityId);
                //    values.Add("streetOrCompund", input.StreetOrCompund);
                //    values.Add("rooms", input.Rooms);
                //    values.Add("decoration", input.Decoration);
                //    values.Add("furnished", input.Furnished);
                //    values.Add("parking", input.Parking);
                //    values.Add("priceFrom", input.PriceFrom);
                //    values.Add("priceTo", input.PriceTo);
                //    values.Add("areaFrom", input.AreaFrom);
                //    values.Add("areaTo", input.AreaTo);
                //    values.Add("companyId", input.CompanyIdLocation);
                //    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                //    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/GetAllAdvertisements", content);
                //    var company = response.Content.ReadAsStringAsync().Result;
                //    if (response.IsSuccessStatusCode)
                //    {
                //        result = JsonConvert.DeserializeObject<AddModel>(company);
                //    }

                //}

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<ContactUsResponse> CreateContanctUs(ContactUsInput input)
        {
            ContactUsResponse result = new ContactUsResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("emailAddress", input.Email);
                    values.Add("emailSubject", input.Subject);
                    values.Add("attachmentPath", input.Attachment);
                    values.Add("userId", Constants.UserId);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/ContactUs/CreateContactUs", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<ContactUsResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<UpdateResponse> UpdateSeekerDetail(PersonDetailsInput input)
        {
            UpdateResponse result = new UpdateResponse();
            try
            {
                try
                {
                    AddingHeaders();
                    using (HttpClient client = new HttpClient())

                    {
                        var values = new JObject();
                        values.Add("id", input.Id);
                        values.Add("secondMobile", input.SecondMobile);
                         values.Add("avatar", input.Avatar);
                        values.Add("userName", input.UserName);
                        values.Add("userSurname", input.UserName);
                        values.Add("userEmailAddress", input.UserEmailAddress);
                        values.Add("userPhoneNumber", input.UserPhoneNumber);
                        values.Add("isWhatsApped", input.IsWhatsApp);


                        HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                        var response = await client.PostAsync($"{Constants.ApiURL}/api/Seeker/UpdateSeeker", content);
                        var company = response.Content.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode)
                        {
                            result = JsonConvert.DeserializeObject<UpdateResponse>(company);
                        }

                    }

                }
                catch (Exception ex)
                {

                }
                
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<UpdateResponse> UpdateBrokerDetail(PersonDetailsInput input)
        {
            UpdateResponse result = new UpdateResponse();
            try
            {
                AddingHeaders();
                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("id", input.Id);
                    values.Add("secondMobile", input.SecondMobile);
                    values.Add("avatar", input.Avatar);
                    values.Add("userName", input.UserName);
                    values.Add("userSurname", input.UserName);
                    values.Add("userEmailAddress", input.UserEmailAddress);
                    values.Add("userPhoneNumber", input.UserPhoneNumber);
                    values.Add("isWhatsApped", input.IsWhatsApp);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}api/BrokerPerson/UpdateBrokerPerson", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<UpdateResponse>(company);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public async Task<UpdateResponse> UpdateOwnerDetail(PersonDetailsInput input)
        {
            UpdateResponse result = new UpdateResponse();
            try
            {
                AddingHeaders();
                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("id", input.Id);
                    values.Add("secondMobile", input.SecondMobile);
                    values.Add("avatar", input.Avatar);
                    values.Add("userName", input.UserName);
                    values.Add("userSurname", input.UserName);
                    values.Add("userEmailAddress", input.UserEmailAddress);
                    values.Add("userPhoneNumber", input.UserPhoneNumber);
                    values.Add("isWhatsApped", input.IsWhatsApp);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Owner/UpdateOwner", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<UpdateResponse>(company);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<UpdateResponse> UpdateCompanyDetail(CompanyDetailsModel input)
        {
            UpdateResponse result = new UpdateResponse();
            try
            {
                AddingHeaders();
                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("id", input.Id);
                    values.Add("secondMobile", input.SecondMobile);
                    values.Add("logo", input.Logo);
                    values.Add("bwLogo", input.BwLogo);
                    values.Add("about", input.About);
                    values.Add("latitude", input.Latitude);
                    values.Add("longitude", input.Longitude);
                    values.Add("facebook", input.Facebook);
                    values.Add("instagram", input.Instagram);
                    values.Add("snapchat", input.Snapchat);
                    values.Add("tiktok", input.Tiktok);
                    values.Add("website", input.Website);
                    values.Add("commericalAvatar", input.CommericalAvatar);
                    values.Add("userName", input.Name);
                    values.Add("userSurname", input.Name);
                    values.Add("userEmailAddress", input.EmailAddress);
                    values.Add("userPhoneNumber", input.PhoneNumber);
                    values.Add("packageId", input.PackageId);
                    values.Add("balance", input.Balance);
                    values.Add("isPackageRenwed", input.IsPackageRenwed);
                    
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Company/UpdateCompany", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<UpdateResponse>(company);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<UpdatePasswordResponseModel> ChangePassword(UpdateUserPasswordModel model)
        {
            UpdatePasswordResponseModel result = new UpdatePasswordResponseModel();
            try
            {

                AddingHeaders();
                var json = JsonConvert.SerializeObject(new
                {
                    currentPassword = model.CurrentPassword,
                    newPassword = model.NewPassword,
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Common/UpdateUserPassword");
                request.Content = content;
                var response = await httpClient.
                        SendAsync<UpdatePasswordResponseModel>(request);

                result = response.Value;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<RateusModel> CreateRate(RateUsInput model)
        {
            RateusModel result = new RateusModel();
            try
            {

                AddingHeaders();
                var json = JsonConvert.SerializeObject(new
                {
                    userId = model.UserId,
                    userRate = model.UserRate,
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/RateUs/CreateRate");
                request.Content = content;
                var response = await httpClient.
                        SendAsync<RateusModel>(request);

                result = response.Value;
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<SponsorsResponseModel> GetAllSponsors()
        {
            SponsorsResponseModel result = new SponsorsResponseModel();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("keyword","");
                    values.Add("start",0);
                    values.Add("length", 0);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Common/GetAllSponsors", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<SponsorsResponseModel>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }
        public async Task<DeleteAccountResponse> DeleteAccount()
        {
            DeleteAccountResponse result = new DeleteAccountResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("userId", Constants.UserId);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Common/DeleteAccountApi", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<DeleteAccountResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<UpdateResponse> DeleteFavourite(long FavouriteId)
        {
            UpdateResponse result = new UpdateResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                   
                    HttpContent content = new StringContent(FavouriteId.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/DeleteFavorite", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<UpdateResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result; 
        }

        public async Task<SocialMediaReponse> GetAllSocialMedia()
        {
            SocialMediaReponse result = new SocialMediaReponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("keyword", "");
                    values.Add("start", 0);
                    values.Add("length", 20);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Common/GetAllSocialContacts", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<SocialMediaReponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }
        public async Task<DiscountsResponseModel> GetDiscounts( string discount)
        {
            DiscountsResponseModel result = new DiscountsResponseModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var values = new JObject();
                    values.Add("Keyword", discount);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Common/GetDiscountPrecentageAndFixedAmount", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<DiscountsResponseModel>(company);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<AdvertisementForEditResponse> GetAdvertiseForEdit(long Id)
        {
            AdvertisementForEditResponse result = new AdvertisementForEditResponse();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var values = new JObject();
                    values.Add("advertiseId", Id);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/GetAdvertiseDetailsForEdit", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<AdvertisementForEditResponse>(company);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<ChartResponseModel> GetChart()
        {
            ChartResponseModel result = new ChartResponseModel();
            try
            {
                //using (HttpClient client = new HttpClient())
                //{
                //    var values = new JObject();
                //    values.Add("advertiseId",Convert.ToInt64(Constants.NavigationParamter));
                //    values.Add("durationByDays", 30);
                //    values.Add("interval", 2);
                //    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                //    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/GetViewsForChartApi", content);
                //    var company = response.Content.ReadAsStringAsync().Result;
                //    if (response.IsSuccessStatusCode)
                //    {
                //        result = JsonConvert.DeserializeObject<ChartResponseModel>(company);
                //    }
                //}
                var options = new RestClientOptions("https://brokerapi.nahrdev.website")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/Advertisement/GetViewsForChartApi", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                var body = string.Format(@"{0}" + "\n" + @"  ""advertisementId"": {1}," + "\n" + @"  ""durationByDays"": 90," + "\n" + @"  ""interval"": 5" + "\n" + @"{2}", "{", Convert.ToInt64(Constants.NavigationParamter),"}");
                request.AddStringBody(body, DataFormat.Json);
                RestResponse response = await client.ExecuteAsync(request);
                result = JsonConvert.DeserializeObject<ChartResponseModel>(response.Content);
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<AppoimentPointsResponse> GetPoint()
        {
            AppoimentPointsResponse result = new AppoimentPointsResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("brokerId", Constants.BrokerId);
                    values.Add("seekerId", Constants.SeekerId);
                    values.Add("ownerId", Constants.OwnerId);
                    values.Add("companyId", Constants.CompanyId);

                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/GetAdsPointsByUserIdApi", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<AppoimentPointsResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<CheckPropertyStatusResponse> CheckPropertyStatus(long Id)
        {
            CheckPropertyStatusResponse result = new CheckPropertyStatusResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    HttpContent content = new StringContent(Id.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/CheckStatus", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<CheckPropertyStatusResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<GovernmentsResponseModel> GetAllGovernments(GovernmentsInputModel input)
        {
            GovernmentsResponseModel result = new GovernmentsResponseModel();
            try
            {
                AddingHeaders();
                var json = JsonConvert.SerializeObject(new
                {
                    keyword = input.Keyword,
                    start = input.Start,
                    length = input.Length,
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Common/GetAllGovernorates");
                request.Content = content;
                var response = await httpClient.SendAsync<GovernmentsResponseModel>(request);
                result = response.Value;
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<ProjectResponse> ManagaProject(ProjectModel projectModel)
        {
            ProjectResponse result = new ProjectResponse();
            try
            {
                AddingHeaders();
                projectModel.IsPublish = true;
                projectModel.IsApprove = true;
                projectModel.FeaturedAd = true;
                var json = JsonConvert.SerializeObject(projectModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Project/ManagaProject");
                request.Content = content;
                var response = await httpClient.SendAsync<ProjectResponse>(request);
                if (response.Value != null)
                {
                    result = response.Value;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<ProjectResponse> GetAllProjectForCompanyId()
        {
            ProjectResponse result = new ProjectResponse();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var values = new JObject();
                    values.Add("keyword", "");
                    values.Add("userId", 0);
                    values.Add("companyId", Constants.CompanyId);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Project/GetAllProjects", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<ProjectResponse>(company);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<DeleteProjectResponse> DeleteProject(long ProjectId)
        {
            DeleteProjectResponse result = new DeleteProjectResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {
                    var values = new JObject();
                    values.Add("projectId", ProjectId);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Project/DeleteProject", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<DeleteProjectResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }
        public async Task<ProjectResponseDetails> GetProjectDetails(long Id)
        {
            ProjectResponseDetails result = new ProjectResponseDetails();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var values = new JObject();
                    values.Add("projectId", Id);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Project/GetProjectDetails", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<ProjectResponseDetails>(company);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<ProjectResponseDetails> DurationToProjectAds()
        {
            ProjectResponseDetails result = new ProjectResponseDetails();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var data = Constants.NavigationProject as ProjectModel;
                    var values = new JObject();
                    values.Add("projectId", data.Id);
                    values.Add("durationId", data.DurationId);
                    values.Add("isPublish", true);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Project/PlaceDurationToProjectAds", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<ProjectResponseDetails>(company);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<GetLastAdvertiseResponse> GetLastAdvertise()
        {
            GetLastAdvertiseResponse result = new GetLastAdvertiseResponse();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://brokerapi.nahrdev.website/api/Advertisement/GetLastAdvertiseId");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                result = JsonConvert.DeserializeObject<GetLastAdvertiseResponse>(await response.Content.ReadAsStringAsync());

                return result;

                //var options = new RestClientOptions("https://brokerapi.nahrdev.website")
                //{
                //    MaxTimeout = -1,
                //};
                //var client = new RestClient(options);
                //var request = new RestRequest("/api/Advertisement/GetLastAdvertiseId", Method.Get);
                //RestResponse response = await client.ExecuteAsync(request);
                //result = JsonConvert.DeserializeObject<GetLastAdvertiseResponse>(response.Content);

                //return result;
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }
        public async Task<PackageResponse> GetAllPackages()
        {
            PackageResponse result = new PackageResponse();
            try
            {

                AddingHeaders();
                var json = JsonConvert.SerializeObject(new
                {
                    keyword = "",
                    start = 0,
                    length = 0,
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Common/GetAllPackages");
                request.Content = content;
                var response = await httpClient.
                        SendAsync<PackageResponse>(request);

                result = response.Value;
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<VerifyOtpResponse> CheckPhoneNumberOtp()
        {
            VerifyOtpResponse result = new VerifyOtpResponse();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                  
                    var values = new JObject();
                    values.Add("phoneNumber", Constants.UserMobileNumber);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/TokenAuth/CheckPhoneNumberOtp", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<VerifyOtpResponse>(company);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<VerifyOtpResponse> CheckPhoneNumberOtp(string mobileNumber)
        {
            VerifyOtpResponse result = new VerifyOtpResponse();
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    var values = new JObject();
                    values.Add("phoneNumber", mobileNumber);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/TokenAuth/CheckPhoneNumberOtp", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<VerifyOtpResponse>(company);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<PackageResponse> GetCompanyPackageDetails(long userId)
        {
            PackageResponse result = new PackageResponse();
            try
            {
                AddingHeaders();

                var values = new JObject();
                values.Add("UserId", userId);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Company/GetCompanyPackageDetailsApi");
                var response = await httpClient.
                        SendAsync<PackageResponse>(request);

                if (response.Value != null)
                {
                    result = response.Value;
                }
               
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<PackageHistoryRosponseModel> GetCompanyWalletPackageDetails(long userId)
        {
            PackageHistoryRosponseModel result = new PackageHistoryRosponseModel();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post,$"{Constants.ApiURL}/api/Company/GetCompanyPackageDetailsApi?UserId={userId}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
          var company=      await response.Content.ReadAsStringAsync();
                //  var response = await client.SendAsync(request);
              
                if (response.IsSuccessStatusCode != null)
                {
                    result = JsonConvert.DeserializeObject<PackageHistoryRosponseModel>(company);
                  //  var response = await httpClient.SendAsync<PackageHistoryRosponseModel>(request);
                }

            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<ProjectResponse> PlaceDurationToAds(ProjectModel input)
        {
            ProjectResponse result = new ProjectResponse();
            try
            {
                AddingHeaders();
                var json = JsonConvert.SerializeObject(new
                {
                    ads = input.AdvertisementsInput,
                    durationId = input.DurationId,
                    isPublish = input.IsPublish,
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Advertisement/PlaceDurationToAds");
                request.Content = content;
                var response = await httpClient.SendAsync<ProjectResponse>(request);
                if (response.Value != null)
                {
                    result = response.Value;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<ForgetPasswordPesponse> ForgetPassword(ForgetPasswordInput input)
        {
            ForgetPasswordPesponse result = new ForgetPasswordPesponse();
            try
            {
                AddingHeaders();
                var json = JsonConvert.SerializeObject(input);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/TokenAuth/ForgetPassword");
                request.Content = content;
                var response = await httpClient.SendAsync<ForgetPasswordPesponse>(request);
                
                    result = response.Value;
                
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<PaymentResponseModel> GetPaymentUrl(PaymentInput input)
        {
            PaymentResponseModel result = new PaymentResponseModel();
            try
            {

                AddingHeaders();
                var json = JsonConvert.SerializeObject(input);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/TokenAuth/GetPaymentUrl");
                request.Content = content;
                var response = await httpClient.
                        SendAsync<PaymentResponseModel>(request);

                result = response.Value;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<NotificationModelResponse> GetAllNotification()
        {
            NotificationModelResponse result = new NotificationModelResponse();
            try
            {
                AddingHeaders();

                var values = new JObject();
                values.Add("UserId", Constants.UserId);
                HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Common/GetAllNotificationsForUserApi");
                request.Content = content;
                var response = await httpClient.SendAsync<NotificationModelResponse>(request);

                if (response.Value != null)
                {
                    result = response.Value;
                }

            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<CompanyBalanceRivalResponse> UpdateCompanyBalanceRival(int balance)
        {

            CompanyBalanceRivalResponse result = new CompanyBalanceRivalResponse();
            try
            {
                AddingHeaders();

                var values = new JObject();
                values.Add("id", Constants.CompanyId);
                values.Add("rivalBalance", balance);
                HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.ApiURL}/api/Company/CompanyBalanceRivalApi");
                request.Content = content;
                var response = await httpClient.SendAsync<CompanyBalanceRivalResponse>(request);

                if (response.Value != null)
                {
                    result = response.Value;
                }

            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<UpdateResponse> DeleteFavouriteByAdvertiserId(long AdvertiserId)
        {
            UpdateResponse result = new UpdateResponse();
            try
            {

                using (HttpClient client = new HttpClient())

                {

                    HttpContent content = new StringContent(AdvertiserId.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/Advertisement/DeleteFavoriteByAdId", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<UpdateResponse>(company);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<VerifyOtpResponse> CheckPhoneNumberOtpForUpdatePhone(string MobileNumber)
        {
            VerifyOtpResponse result = new VerifyOtpResponse();
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    var values = new JObject();
                    values.Add("phoneNumber", MobileNumber);
                    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{Constants.ApiURL}/api/TokenAuth/CheckPhoneNumberOtpForUpdatePhone", content);
                    var company = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<VerifyOtpResponse>(company);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
