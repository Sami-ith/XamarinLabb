﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PropertyChanged;
using test.Models;
using Xamarin.Essentials;

namespace test.ViewModels
{
    
    public class WeatherViewModel: INotifyPropertyChanged
    {
        RestService _restService;

        public event PropertyChangedEventHandler PropertyChanged;

        WeatherData current;
        public string CurrentCity { get; set; }
        
        public WeatherViewModel(string cityName)
        {
            CurrentCity = cityName;
            _restService = new RestService();
            //current = new WeatherData();
            //Task<WeatherData> task = Task.Run(GetData);
            //current = task.Result;
            this.Current= new WeatherData();
            Task<WeatherData> task = Task.Run(GetData);
            this.Current= task.Result;
            

        }
        public WeatherData Current
        {
            set
            {
                if (current != value)
                {
                    current = value;

                    if (PropertyChanged != null)
                    {
                        OnPropertyChanged("current");
                    }
                }

            }
            get
            {
                return current;

            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
