using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace G3_PhotoSharingApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // primer rute: /slika/2
            routes.MapRoute(
                name: "PhotoRoute",
                url: "slika/{id}",
                defaults: new { controller = "Photo", action = "Display" },
                constraints: new { id = "[0-9]+" });

            // primer rute: /slika/naziv/jagode
            routes.MapRoute(
                name: "PhotoTitleRoute",
                url: "slika/naziv/{title}",
                defaults: new { controller = "Photo", action = "DisplayByTitle" }
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
