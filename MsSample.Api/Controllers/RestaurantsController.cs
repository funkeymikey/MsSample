using System.Collections.Generic;
using System.Web.Http;
using MsSample.Core;

namespace MsSample.Api.Controllers
{
    public class RestaurantsController : ApiController
    {
        public RestaurantsManager _manager = new RestaurantsManager();

        // GET api/values
        public IEnumerable<Restaurant> Get()
        {
            return _manager.GetRestaurants();
        }

        // GET api/values/5
        public Restaurant Get(int id)
        {
            return _manager.GetRestaurantById(id);
        }

        // POST api/values
        public void Post([FromBody]Restaurant newRestaurant)
        {
            _manager.AddRestaurant(newRestaurant);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Restaurant updated)
        {
            _manager.UpdateRestaurant(id, updated);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _manager.RemoveRestaurant(id);
        }
    }
}