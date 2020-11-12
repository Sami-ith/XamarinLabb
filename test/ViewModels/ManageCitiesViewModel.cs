using System;
using System.Collections.Generic;
using Xamarin.Forms;
using test.Models;
using test.ViewModels;
using List;
using System.Threading.Tasks;

namespace test.ViewModels
{
    public class ManageCitiesViewModel
    {
        public List<City> Cities { get; set; }
       
        public List<ListItem> myList { get; set; }
        public  ManageCitiesViewModel()
            {
            Cities = new List<City>();
            var task = Task.Run(App.Database.GetItemsAsync);
            myList = task.Result;
            
            foreach (ListItem c in myList)
            {
                
                Cities.Add(new City
                {
                    Name = c.City,
                    ImageUrl = "https://openweathermap.org/img/wn/10d.png",
                    Temp = 12,
                   

                })  ;

            }
           
        }
        
        
    }
}
