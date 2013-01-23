using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MsSample.Api.Hubs
{
    [HubName("restaurantHub")]
    public class RestaurantHub : Hub
    {
        public void Added()
        {
            // tell all the clients to update because one has been added 
            Clients.All.refreshList();
        }
    }
}