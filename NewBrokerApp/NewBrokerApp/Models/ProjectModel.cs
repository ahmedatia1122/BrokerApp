using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace NewBrokerApp.Models
{
    public class ProjectResponse
    {
        public ProjectResponse()
        {
            Result = new ProjectResponseModel();
        }
        public ProjectResponseModel Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }
    public class ProjectResponseModel
    {
        public ProjectResponseModel()
        {
            Projects = new List<ProjectModel>();
        }
        public List<ProjectModel> Projects { get; set; }
        public long? ProjectId { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
    public partial class ProjectModel
    {
        public ProjectModel()
        {
            MediaFiles = new List<MediaFile>();
            MediaFilesLayout = new List<MediaFile>();
            Advertisements = new List<AdvertisementModel>();
            PhotosList = new List<string>();
            LayoutsList = new List<string>();
        }
        public List<string> PhotosList { get; set; }
        public List<string> LayoutsList { get; set; }
        public List<MediaFile> MediaFiles { get; set; }
        public List<MediaFile> MediaFilesLayout { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public long? DurationId { get; set; }
        public bool? FeaturedAd { get; set; }
        public long? CompanyId { get; set; }
        public bool IsPublish { get; set; }
        public bool? IsApprove { get; set; }
        public List<AdvertisementModel> Advertisements { get; set; }
        public List<long> AdvertisementsInput { get; set; }
        public long Id { get; set; }
    }
    public partial class ProjectResponseDetails
    {
        public ProjectResponseDetails()
        {
            Result = new DetailsResult();
        }
        public DetailsResult Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }

    public partial class DetailsResult
    {
        public DetailsResult()
        {
            Details = new ProjectModel();
        }
        public ProjectModel Details { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }
    }
    public partial class DeleteProjectResponse
    {
        public Result Result { get; set; }

        public object TargetUrl { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }

        public bool UnAuthorizedRequest { get; set; }

        public bool Abp { get; set; }
    }

    public partial class Result
    {
        public string Msg { get; set; }

        public string Error { get; set; }

        public bool Success { get; set; }
    }


}
