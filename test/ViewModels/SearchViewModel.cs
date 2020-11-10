using System;
using System.Collections.Generic;
using System.Linq;

namespace test.ViewModels
{
    public class SearchViewModel
    {
        public List<String> CityNames { get; set; }
        public  List<string> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";
            return CityNames.Where(f => f.ToLowerInvariant().Contains(normalizedQuery)).ToList();
        }
        public SearchViewModel()
        {
            CityNames = new List<string>
            {
            "Stockholm",
            "Götoborg",
            "Malmö",
            "Avesta",
            "Karlstad",
            "Örebro"
        };
        }
    }
}
