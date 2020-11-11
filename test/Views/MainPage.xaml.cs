using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using test.ViewModels;
using test.Models;
using test.Views;
using Xamarin.Essentials;

namespace test
{
    public partial class MainPage : ContentPage
    {
        
        WeatherData currentWeather;
        public MainPage()
        {
            InitializeComponent();
            // Preferences.Set("CurrentCity", value: "London");
            //Preferences.Get("my_key", "default_value");
            var CurrentCity=Preferences.Get("CurrentCity", "Stockholm");
            currentWeather = new WeatherViewModel(CurrentCity).current;
            BindingContext = currentWeather;

        }
       

         public void ToolbarItem_Clicked(object sender, EventArgs e)
        {

             Navigation.PushAsync(new ManageCitiesPage());
        }


    }

        
    }

