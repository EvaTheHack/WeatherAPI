using Newtonsoft.Json;

namespace Weather.Core
{
    public class WeatherMain
    {
        [JsonProperty("main")]
        public static string main { get; set; }
    }
}
