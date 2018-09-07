using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace G3_PhotoSharingApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "PhotoApi",
                routeTemplate: "api/photos/{id}",
                defaults: new { controler = "PhotoApi",
                                action = "GetPhotoId"
                              },
                constraints: new {id = "[0-9]+"}
            );

            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
              );

            var json = config.Formatters.JsonFormatter;

            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.Objects;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
