using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
        void Commit();
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(i => i.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
            _context.SaveChanges();
            return newRestaurant;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private static readonly List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "The House of Kobe" },
                new Restaurant { Id = 2, Name = "LJ's and Kat" },
                new Restaurant { Id = 3, Name = "King's Contrivance" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        
        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public void Commit()
        {
            // ... no op
        }
    }
}
