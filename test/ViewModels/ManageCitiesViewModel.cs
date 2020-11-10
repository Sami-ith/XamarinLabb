using System;
using System.Collections.Generic;
using Xamarin.Forms;
using test.Models;
using test.ViewModels;
namespace test.ViewModels
{
    public class ManageCitiesViewModel
    {
        public List<City> Cities { get; set; }
        

        public  ManageCitiesViewModel()
            {
            Cities = new List<City>();
            Cities.Add(new City
            {
                Name = "Göteborg",
                ImageUrl="https://openweathermap.org/img/wn/10d.png",
                Temp = 12

            }) ; ;

            Cities.Add(new City
            {
                Name = "Stockholm",
                ImageUrl = "https://openweathermap.org/img/wn/10d.png",
                Temp=13

            });

        }
    }
}
