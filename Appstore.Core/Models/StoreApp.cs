using System.Collections.Generic;
using Newtonsoft.Json;


namespace Appstore.Core.Models
{
    public class StoreApp
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("ImageName")]
        public string ImageName { get; set; }

        [JsonProperty("Price")]
        public float Price { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("Screenshots")]
        public IEnumerable<string> Screenshots { get; set; }

        [JsonProperty("appInformation")]
        public IEnumerable<Dictionary<string, string>> AppInformation { get; set; }
    }
}
