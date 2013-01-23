using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MsSample.Api.Hubs
{
    [HubName("restaurantHub")]
    public class RestaurantHub : Hub
    {
        public void Send(string msg)
        {
            // Call the addMessage method on all clients            
            Clients.All.addMessage(msg);
        }
    }
}