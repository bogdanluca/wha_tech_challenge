using System.Web.Mvc;
using System.Web.Routing;

namespace WhaTechChallenge
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Bets", "Bets/{action}", new {controller = "Bets", action = "{action}"});
            routes.MapRoute("Default", "", new {controller = "Bets", action = "Settled"});
        }
    }
}