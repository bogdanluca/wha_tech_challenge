using System.Web.Mvc;
using System.Web.Routing;

namespace WhaTechChallenge
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("BetHistory", "BetHistory/{action}", new {controller = "BetHistory", action = "{action}"});
            routes.MapRoute("Default", "", new {controller = "BetHistory", action = "Settled"});
        }
    }
}