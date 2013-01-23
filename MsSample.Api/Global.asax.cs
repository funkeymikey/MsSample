using System;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MsSample.Api
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //this needs to be first
            RouteTable.Routes.MapHubs();

            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                            name: "DefaultApi",
                            routeTemplate: "{controller}/{id}",
                            defaults: new { id = RouteParameter.Optional }
                        );
        }

        protected void Application_PreRequestHandlerExecute()
        {
            //enable the CORS requests, but signal R automatically adds these if necessary, so check for existence first
            if (!Request.Url.LocalPath.StartsWith("/signalr", StringComparison.InvariantCultureIgnoreCase))
            {
                if (String.IsNullOrWhiteSpace(Response.Headers["Access-Control-Allow-Origin"]))
                    Response.Headers["Access-Control-Allow-Origin"] = "*";
                if (String.IsNullOrWhiteSpace(Response.Headers["Access-Control-Allow-Credentials"]))
                    Response.Headers["Access-Control-Allow-Credentials"] = "true";
                if (String.IsNullOrWhiteSpace(Response.Headers["Access-Control-Allow-Methods"]))
                    Response.Headers["Access-Control-Allow-Methods"] = "GET, POST, OPTIONS";
                if (String.IsNullOrWhiteSpace(Response.Headers["Access-Control-Allow-Headers"]))
                    Response.Headers["Access-Control-Allow-Headers"] = "Content-Type, Accept, X-Requested-With";
            }

        }
    }
}