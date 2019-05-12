﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TutorSearch.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API

            // Маршруты Web API
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Index", id = RouteParameter.Optional }
            );
        }
    }
}
