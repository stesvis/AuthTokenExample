using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;

namespace AuthTokenExample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, UnityContainer unityContainer)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // These two lines fix some Exceptions when returning complex JSON objects
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

            config.DependencyResolver = new ApiDependencyResolver(unityContainer);
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
        }
    }
}