using NewBrokerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBrokerApp.Models
{
public partial class DefinitionModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Avatar { get; set; }
    public int Id { get; set; }
}
    public class DefinitionsInputModel
    {
    
        public string Keyword { get; set; }
        public int Type { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
    }
public partial class DefinitionsResponseModel
{
    public DefinitionsResponse Result { get; set; }

    public object TargetUrl { get; set; }

    public bool Success { get; set; }

    public string Error { get; set; }

    public bool UnAuthorizedRequest { get; set; }

    public bool Abp { get; set; }
}

public partial class DefinitionsResponse
{
    public DefinitionsResponse()
    {
        Definitions = new List<DefinitionModel>();
    }
    public List<DefinitionModel> Definitions { get; set; }
    public string Error { get; set; }
    public bool Unauthorize { get; set; }
    public bool Success { get; set; }
}
    public partial class AreaModel
    {
        public decimal Name { get; set; }

        public string Description { get; set; }

        public string Avatar { get; set; }
        public int Id { get; set; }
    } 
    public partial class PriceModel
    {
        public decimal Name { get; set; }

        public string Description { get; set; }

        public string Avatar { get; set; }
        public int Id { get; set; }
    }
    public class PropertyModel
    {
        public string Property { get; set; }
        public int Id { get; set; }
        public bool Edit { get; set; }
    }
}