using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using test.Models;
using Xamarin.Essentials;

namespace test.ViewModels
{
    public class WeatherViewModel
    {
        RestService _restService;
        public WeatherData current { get; set; }
        public string CurrentCity { get; set; }
       
        public WeatherViewModel(string cityName)
        {
            CurrentCity = cityName;
            _restService = new RestService();
            current = new WeatherData();
            Task<WeatherData> task = Task.Run(GetData);
            current = task.Result;


        }



        public async Task<WeatherData> GetData()
        {
           
           var weatherData = await _restService.GetWeatherDataAsync(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
            weatherData.Weather[0].Icon = "https://openweathermap.org/img/w/" + weatherData.Weather[0].Icon + ".png";
            
           // current = weatherData;
            return weatherData;
            
            
        }

        string GenerateRequestUri(string endpoint)

        {
            
            string requestUri = endpoint;
            requestUri += $"?q={CurrentCity}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += "&APPID=66a30c555a6df8f344653385a12fa8a0";
            return requestUri;
        }


    }

    }
