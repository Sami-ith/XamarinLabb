using System;
namespace test.Models
{
    public class City
    {
            public string Name{ get; set; }
            public string ImageUrl { get; set; }
            public double Temp { get; set; }
           
            public override string ToString()
            {
                return Name;
            }
    }
    
}
