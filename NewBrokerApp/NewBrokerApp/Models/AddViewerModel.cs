using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
    public class AddViewerModel
    {
        public string DeviceToken { get; set; }
        public long UserId { get; set; }
        public long AdvertisementId { get; set; }
    }
    public class AddViewerResponse
    {
        public AddViewerResponse()
        {
            Result = new AddViewerResult();
        }
        public AddViewerResult Result { get; set; }
        public object TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool Abp { get; set; }
    }
    public partial class AddViewerResult
    {
        public long? ViewId { get; set; }
        public object AdView { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
        public bool? Sucess { get; set; }
    }

}
