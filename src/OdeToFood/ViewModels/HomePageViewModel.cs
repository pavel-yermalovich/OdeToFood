using System.Collections.Generic;
using OdeToFood.Entities;

namespace OdeToFood.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
