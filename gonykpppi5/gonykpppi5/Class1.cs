using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace gonyk5
{

    public class Main
    {
        public double temp { get; set; }
    }

    public class Rain
    {
        [JsonPropertyName("1h")]
        public double _1h { get; set; }
    }

    public class WeatherResultRoot
    {
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    public class Sys
    {
        public string country { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
    }
}