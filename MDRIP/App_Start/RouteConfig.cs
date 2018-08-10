using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MDRIP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "LandingPage", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "map",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Visualisation", action = "Map", id = UrlParameter.Optional }
            );
        }
    }
}
