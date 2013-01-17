using MsSample.Core.Data;
using System.Linq;

namespace MsSample.Core
{
    public class RestaurantsManager
    {
        private RestaurantContext _db = new RestaurantContext();

        public IQueryable<Restaurant> GetRestaurants()
        {
            return _db.Restaurants.AsQueryable();
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _db.Restaurants.SingleOrDefault(rest => rest.RestaurantId == id);
        }

        public int AddRestaurant(Restaurant newRestaurant)
        {
            _db.Restaurants.Add(newRestaurant);
            _db.SaveChanges();
            return newRestaurant.RestaurantId;
        }

        public void UpdateRestaurant(int id, Restaurant updated)
        {
            Restaurant r = _db.Restaurants.Single(rest => rest.RestaurantId == id);
            _db.Restaurants.Remove(r);
            _db.Restaurants.Add(updated);
            _db.SaveChanges();
        }

        public void RemoveRestaurant(int id)
        {
            Restaurant r = _db.Restaurants.Single(rest => rest.RestaurantId == id);
            _db.Restaurants.Remove(r);
            _db.SaveChanges();
        }
    }
}
