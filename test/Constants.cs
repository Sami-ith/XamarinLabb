using System;
using System.IO;
namespace test
{
    public static class Constants
    {
        public static string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        public static string OpenWeatherMapAPIKey = "66a30c555a6df8f344653385a12fa8a0";
        public const string DatabaseFilename = "database.db";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}

  
    

