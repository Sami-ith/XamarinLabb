﻿using SQLite;

namespace test
{
    public class ListItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string City { get; set; }
        // public string Weather { get; set; }
    }
}

