using System;
using System.Collections.Generic;
using test.ViewModels;
using test.Models;
using Xamarin.Forms;

namespace test.Views
{
    public partial class SearchViewPage : ContentPage
    {
        public SearchViewModel searchView;
        public SearchViewPage()
        {
            InitializeComponent();
            searchView = new SearchViewModel();
            BindingContext = searchView;
        }

        

        void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            searchResults.ItemsSource = searchView.GetSearchResults(searchBar.Text);
               
            
        }
        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            searchResults.ItemsSource = searchView.GetSearchResults(e.NewTextValue);
        }
        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string selectedItem = e.SelectedItem as string;
        }

        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            string tappedItem = e.Item as string;
            ListItem manageCity = new ListItem();
            manageCity.City= tappedItem.ToString();
            
            await App.Database.SaveItemAsync(manageCity);
            await Application.Current.MainPage.Navigation.PopAsync(true);
        }
    }
}
