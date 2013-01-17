using System.Data.Entity;

namespace MsSample.Core.Data
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public RestaurantContext() : base("MsSampleConnection") { }

    }
}
