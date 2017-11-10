using Newtonsoft.Json;

namespace Weather.Core
{
    public class CityConfig
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
