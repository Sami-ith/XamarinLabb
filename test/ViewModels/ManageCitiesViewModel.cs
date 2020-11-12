using System;
using System.Collections.Generic;
using Xamarin.Forms;
using test.Models;
using test.ViewModels;
using List;
using System.Threading.Tasks;
using System.Linq;

namespace test.ViewModels
{
    public class ManageCitiesViewModel
    {
        public List<City> Cities { get; set; }
        public WeatherData weather;
        public List<ListItem> myList { get; set; }
        
        public  ManageCitiesViewModel()
            {
            Cities = new List<City>();
            
            var task = Task.Run(App.Database.GetItemsAsync);
            myList = task.Result;
            
            foreach (var item in myList)
            {
                if (item != null)
                {
                    //string cName = c.City.ToString();
                    weather = new WeatherViewModel(item.City).current;
                   var icon = weather.Weather[0].Icon;
                    var temp = weather.Main.Temperature;
                    Cities.Add(new City
                    {

                        Name = item.City,
                        ImageUrl =icon,
                        //"https://openweathermap.org/img/wn/10d.png",

                        Temp = temp


                    });
                }


            }
            
           
        }
       
        
    }
}
