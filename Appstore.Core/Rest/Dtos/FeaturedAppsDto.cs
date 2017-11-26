using System.Collections.Generic;
using Newtonsoft.Json;
using Appstore.Core.Models;

namespace Appstore.Core.Rest.Dtos
{
    public class FeaturedAppsDto
    {
        [JsonProperty("categories")]
        public IEnumerable<AppCategory> Categories { get; set; }
    }
}
