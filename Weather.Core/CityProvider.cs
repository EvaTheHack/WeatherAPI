using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Weather.Core
{
    public class CityProvider
    {
        private static string DEFAULT_CITIES_FILE_NAME = "city.list.json";

        public List<CityConfig> GetListCitiesByFirstLetters(string firstLetters)
        {
            var cities = GetCitiesFromLocalFile();
            return cities.Where(city => city.Name.StartsWith(firstLetters)).ToList();
        }

        private List<CityConfig> GetCitiesFromLocalFile()
        {
            var sr = new StreamReader(DEFAULT_CITIES_FILE_NAME);
            var jsonString = sr.ReadToEnd();

            return JsonConvert.DeserializeObject<List<CityConfig>>(jsonString);
        }
    }
}
