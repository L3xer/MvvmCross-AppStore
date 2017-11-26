using System.Collections.Generic;
using Newtonsoft.Json;


namespace Appstore.Core.Models
{
    public class AppCategory
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("apps")]
        public IEnumerable<StoreApp> Apps { get; set; }
    }
}
