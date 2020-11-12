using System;
using System.Collections.Generic;
using test.ViewModels;
using test.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using test.Models;
namespace test.Views
{
    public partial class ManageCitiesPage : ContentPage
    {
        List<City> cities;
        public ManageCitiesPage()
        {
            InitializeComponent();
            BindingContext = new ManageCitiesViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ManageCitiesViewModel();
        }
        public void plusButtonClick(object sender, EventArgs e)
        {

            Navigation.PushAsync(new SearchViewPage());
        }
        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            City selectedItem = e.SelectedItem as City;
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            City tappedItem = e.Item as City;
            string Cname = tappedItem.Name.ToString();
            Preferences.Set("CurrentCity",value:Cname);
            
            Application.Current.MainPage.Navigation.PopAsync(true);
        }
        
    }
}
