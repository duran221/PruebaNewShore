using APIAerolineasNewShore.App_Start;
using Business.IServices;
using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;

namespace APIAerolineasNewShore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de inyección de dependencias:
            var container = new UnityContainer();
            container.RegisterType<IControlFlight, ControlFlight>();
            config.DependencyResolver = new UnityResolver(container);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
