using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UlabInventory.Web.MVC.Main
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            var settings=config.Formatters.JsonFormatter.SerializerSettings;
            settings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            settings.ContractResolver=new CamelCasePropertyNamesContractResolver();
            settings.Formatting=Formatting.Indented;
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
