using System;
using System.Collections.Generic;
using test.ViewModels;

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
    }
}
