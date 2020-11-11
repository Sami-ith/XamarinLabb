using System;
using System.IO;
using List;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace test
{
    public partial class App : Application

    {
        public static string FolderPath { get; private set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
        
        // Setup database for .forms
        static ListItemDatabase database;
        public static ListItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ListItemDatabase();
                }
                return database;
            }
        }
    }
}
