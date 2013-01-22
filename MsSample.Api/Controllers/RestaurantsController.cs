using MsSample.Core;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MsSample.Api.Controllers
{
    
    public class RestaurantsController : ApiController
    {
        private RestaurantsManager _manager = new RestaurantsManager();

        // GET Restaurants
        public HttpResponseMessage Get()
        {
            IQueryable<Restaurant> restaurants = _manager.GetRestaurants();

            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.OK, restaurants);
            //response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:55186"); //to allow the request to be used from other domains
            //response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-Requested-With");
            //response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            //response.Headers.Add("Access-Control-Allow-Credentials", "true");
            return response;
        }

        // GET Restaurants/5
        public HttpResponseMessage Get(int id)
        {
            Restaurant restuarant = _manager.GetRestaurantById(id);
            if (restuarant == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, restuarant);
        }

        // POST Restaurants
        public HttpResponseMessage Post([FromBody]Restaurant newRestaurant)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            _manager.AddRestaurant(newRestaurant);

            //build the response with the location
            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, Url.Route(null, new { id = newRestaurant.RestaurantId }));

            return response;
        }

        // PUT Restaurants/5
        public void Put(int id, [FromBody]Restaurant updated)
        {
            if (!_manager.HasId(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _manager.UpdateRestaurant(id, updated);
        }

        // DELETE Restaurants/5
        public void Delete(int id)
        {
            if (!_manager.HasId(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _manager.RemoveRestaurant(id);

        }
    }
}