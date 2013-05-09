using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Search
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                name: "Details",
                url: "{controller}/{action}/{strap}"
 

            );

            routes.MapRoute(
              name: "Search",
              url: "{controller}/Search/",
              defaults: new { controller = "Parcel", action = "Search" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Parcel", action = "Search", id = UrlParameter.Optional }
            );



        }
    }
}