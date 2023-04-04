using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace gonyk5
{
    public class WeatherModel
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public WeatherResultRoot WeatherResult { get; set; }
        public string Error { get; set; }

        public void PrintResult()
        {
            Console.WriteLine($"Error: {this.Error}");
            Console.WriteLine($"Message {this.Message}");
            Console.WriteLine($"StatusCode: {this.StatusCode}");

            if (this.Error == null)
            {
                Console.WriteLine($"weather.id: {this.WeatherResult.weather[0].id}");
                Console.WriteLine($"weather.main: {this.WeatherResult.weather[0].main}");
                Console.WriteLine($"weather.description: {this.WeatherResult.weather[0].description}");
                Console.WriteLine($"main.temp: {this.WeatherResult.main.temp}");
                Console.WriteLine($"wind.speed: {this.WeatherResult.wind.speed}");
                Console.WriteLine($"dt: {this.WeatherResult.dt}");
                Console.WriteLine($"sys.country: {this.WeatherResult.sys.country}");
                Console.WriteLine($"timezone: {this.WeatherResult.timezone}");
                Console.WriteLine($"id: {this.WeatherResult.id}");
                Console.WriteLine($"name: {this.WeatherResult.name}");
                Console.WriteLine($"cod: {this.WeatherResult.cod}");
            }
        }
    }

    public class ClientWeather
    {

        private readonly string key;
        private readonly HttpClient client;
        private WeatherModel Weathermodel;

        public ClientWeather(string key)
        {
            this.client = new HttpClient();
            this.key = key;
        }

        public async Task<WeatherModel> Get()
        {
            string city = "Snihurivka";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric" +
            $"&appid={this.key}";

            try
            {
                HttpResponseMessage response = await client.GetAsync($"{url}");
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                WeatherResultRoot weatherData = JsonSerializer.Deserialize<WeatherResultRoot>(json);

                return new WeatherModel
                {
                    Message = "Data retrieved successfully",
                    StatusCode = response.StatusCode,
                    WeatherResult = weatherData,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new WeatherModel
                {
                    Message = "Error retrieving data",
                    StatusCode = HttpStatusCode.InternalServerError,
                    WeatherResult = null,
                    Error = ex.Message
                };
            }
        }

        public async Task<WeatherModel> Post(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric" +
            $"&appid={this.key}";
            Dictionary<string, string> requestData = new Dictionary<string, string>() { { "city", city } };
            try
            {
                FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);
                HttpResponseMessage response = await client.PostAsync(url, requestBody);
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                WeatherResultRoot weatherData = JsonSerializer.Deserialize<WeatherResultRoot>(json);

                return new WeatherModel
                {
                    Message = "Data retrieved successfully",
                    StatusCode = response.StatusCode,
                    WeatherResult = weatherData,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new WeatherModel
                {
                    Message = "Error retrieving data",
                    StatusCode = HttpStatusCode.InternalServerError,
                    WeatherResult = null,
                    Error = ex.Message
                };
            }
        }


    }
}