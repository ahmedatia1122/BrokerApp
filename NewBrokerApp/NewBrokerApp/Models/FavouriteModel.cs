using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class FavouriteModel
    {

    }
    public class CreateFavouriteInput
    {
        public long UserId { get; set; }
        public long AdvertisementId { get; set; }
    }
    public class CreateFavouriteResponse
    {
        public CreateFavouriteResponse()
        {
            Result = new CreateFavouriteResult();
        }
        public CreateFavouriteResult Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }
    public partial class CreateFavouriteResult
    {
        public long? FavoriteId { get; set; }
        public object AdFavorite { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public bool? Success { get; set; }
        public bool? Sucess { get; set; }
    }

}
