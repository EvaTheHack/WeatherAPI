using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Weather.Core
{
    public class WeatherConfig
    {
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public string name { get; set; }
    }

    public class Weather
    {
        public string main { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
    }
               
}

