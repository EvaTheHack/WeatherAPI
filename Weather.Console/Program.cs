using System;
using Weather.Core;

namespace Weather.Console
{
    class Program
    {
        const string EXIT = "exit";
        static ILogger logger = new ConsoleLogger();

        static void Main(string[] args)
        {
            string request = String.Empty;
            while ((request = SetComand()) != EXIT)
                ProcessRequest(request);
        }

        private static string SetComand()
        {
            logger.ShowLine("");
            logger.ShowLine("Choose number of command\n1. Get weather by city name\n2. Get list cities by first char\nIf you want close program, write command \"exit\"");
            var request = System.Console.ReadLine();

            return request;
        }

        private static void ProcessRequest(string request)
        {
            switch (request)
            {
                case "1":
                    GetWeather();
                    break;
                case "2":
                    GetListCitiesByFirstChar();
                    break;
                default:
                    HasError();
                    break;
            }
        }

        private static void GetWeather()
        {
            try
            {
                logger.ShowLine("Set city name:");
                var city = System.Console.ReadLine();

                var wa = new WeatherAPI(logger, city);
                var wc = wa.GetWeather();

                logger.Show("In " + wc.name + " temperature is " + wc.main.temp + Environment.NewLine +
                                                                  wc.weather[0].main + Environment.NewLine +
                                        "Humidity is " + wc.main.humidity + "%" + Environment.NewLine +
                                   "Speed of wind is " + wc.wind.speed + " mps" + Environment.NewLine);

            }
            catch
            {
                HasError();
            }
        }

        private static void GetListCitiesByFirstChar()
        {
            logger.ShowLine("Please enter the first letters of the city:");

            var firstLetters = System.Console.ReadLine();
            var cities = new CityProvider();
            var sortedCities = cities.GetListCitiesByFirstLetters(firstLetters);

            foreach (CityConfig city in sortedCities)
                logger.Show($"{city.Name}; ");
        }

        private static void HasError()
        {
            logger.Show("Uncorrect request or problem with conection\n");
        }
    }
}