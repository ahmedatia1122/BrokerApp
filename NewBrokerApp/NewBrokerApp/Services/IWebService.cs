using NewBrokerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewBrokerApp.Services
{
  public  interface IWebService
    {
        Task<LoginResponseModel> Login(LoginModel loginModel);
        Task<PersonDetailsResponseModel> GetBrokerSettings(long userId);
        Task<PersonDetailsResponseModel> GetSeekerSettings(long userId);
        Task<PersonDetailsResponseModel> GetOwnerSettings(long userId);
        Task<CompanyDetailsResponseModel> GetCompanySettings(long userId);
        Task<DefinitionsResponseModel> GetDefinitionList(DefinitionsInputModel input);
        Task<RegisterResponse> RegisterBroker(RegisterModel registerModel);
        Task<RegisterResponse> RegisterCompany(RegisterModel registerModel);
        Task<RegisterResponse> RegisterOwner(RegisterModel registerModel);
        Task<RegisterResponse> RegisterSeeker(RegisterModel registerModel);
        Task<AdvertisementResponse> ManageAdvertisement(AdvertisementModel advertisementModel);
        Task<CitiesResponseModel> GetAllCities(CitiesInputModel input);
        Task<DurationResponseModel> GetAllDurations(DurationsInputModel input);
        Task<CheckUserResponse> CheckIsEmailOrPhoneExist(string EmailOrPhone);
        Task<AddModel> GetAllAdds(AddInputModel  input);
        Task<DeleteAddResponse> DeleteAdd(long AddId);
        Task<ChangeAddStatusResponse> ChangeAddStatus(long AddId);
        Task<DeleteAddResponse> ClearAllAdds();
        Task<AddViewerResponse> CreateAddViewer(AddViewerModel input);
        Task<CreateFavouriteResponse> CreateFavourite(CreateFavouriteInput input);
        Task<AddDetailsResponse> GetAddDetails(long AddId);

        Task<FavouriteResponseModel> GetAllFavourites(FavouritesInputModel input);
        Task<AddModel> GetAllAdvertisements(AdvertisementInputModel input);
        Task<ContactUsResponse> CreateContanctUs(ContactUsInput input);
        Task<UpdateResponse> UpdateSeekerDetail(PersonDetailsInput input);
        Task<UpdateResponse> UpdateBrokerDetail(PersonDetailsInput input);
        Task<UpdateResponse> UpdateOwnerDetail(PersonDetailsInput input);
        Task<UpdateResponse> UpdateCompanyDetail(CompanyDetailsModel input);
        Task<UpdatePasswordResponseModel> ChangePassword(UpdateUserPasswordModel model);
        Task<RateusModel> CreateRate(RateUsInput model);
        Task<SponsorsResponseModel> GetAllSponsors();
        Task<DeleteAccountResponse> DeleteAccount();
        Task<UpdateResponse> DeleteFavourite(long FavouriteId);
        Task<SocialMediaReponse> GetAllSocialMedia();
        Task<DiscountsResponseModel> GetDiscounts(string discount);
        Task<AdvertisementForEditResponse> GetAdvertiseForEdit(long Id);
        Task<ChartResponseModel> GetChart();
        Task<AppoimentPointsResponse> GetPoint();
        Task<CheckPropertyStatusResponse> CheckPropertyStatus(long Id);
        Task<GovernmentsResponseModel> GetAllGovernments(GovernmentsInputModel input);
        Task<ProjectResponse> ManagaProject(ProjectModel projectModel);
        Task<ProjectResponse> GetAllProjectForCompanyId();
        Task<DeleteProjectResponse> DeleteProject(long ProjectId);
        Task<ProjectResponseDetails> GetProjectDetails(long Id);
        Task<GetLastAdvertiseResponse> GetLastAdvertise();
        Task<ProjectResponseDetails> DurationToProjectAds();
        Task<PackageResponse> GetAllPackages();
        Task<VerifyOtpResponse> CheckPhoneNumberOtp();
        Task<VerifyOtpResponse> CheckPhoneNumberOtp(string MobileNumber);
        Task<VerifyOtpResponse> CheckPhoneNumberOtpForUpdatePhone(string MobileNumber);
        
        Task<PackageResponse> GetCompanyPackageDetails(long userId);
        Task<ProjectResponse> PlaceDurationToAds(ProjectModel input);
        Task<PaymentResponseModel> GetPaymentUrl(PaymentInput input);
        Task<ForgetPasswordPesponse> ForgetPassword(ForgetPasswordInput input);
        Task<NotificationModelResponse> GetAllNotification();
        Task<PackageHistoryRosponseModel> GetCompanyWalletPackageDetails(long userId);
        Task<CompanyBalanceRivalResponse> UpdateCompanyBalanceRival(int balance);
        Task<UpdateResponse> DeleteFavouriteByAdvertiserId(long AdvertiserId);
    }
}
