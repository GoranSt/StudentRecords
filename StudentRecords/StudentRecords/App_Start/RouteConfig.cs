﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentRecords
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // added for attribute routing
            routes.MapMvcAttributeRoutes();
            // ends here

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}