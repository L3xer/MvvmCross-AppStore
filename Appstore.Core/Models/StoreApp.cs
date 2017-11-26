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
    }
}
