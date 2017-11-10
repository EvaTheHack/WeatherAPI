using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using static Weather.Core.WeatherConfig;

namespace Weather.Core
{
    public class WeatherAPI
    {
        private readonly ILogger logger;
        private static string City = String.Empty;
        private const string APIKEY = "e01f0e649d73dee0e906699d27e66a37";
        private string APIURL = "http://api.openweathermap.org/data/2.5/weather?q=" + City + "&mode=json&units=metric&APPID=" + APIKEY ; //не работает !!!

        public WeatherAPI(ILogger logger, string city)
        {
            this.logger = logger;
            City = city;
        }

        private string GetJsonFromAPI(string city)
        {
            var wc = new WebClient();
            return wc.DownloadString(GetAPIURL(city));
        }

        public WeatherConfig GetWeather()
        {
            return JsonConvert.DeserializeObject<WeatherConfig>(GetJsonFromAPI(City));
        }

        private string GetAPIURL(string city)
        {
            return "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=json&units=metric&APPID=" + APIKEY;
        }
    }
}
