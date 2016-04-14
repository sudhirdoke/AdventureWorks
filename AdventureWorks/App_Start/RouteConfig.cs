﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdventureWorks
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //name: "Products",
            //url: "Products/Index",
            //defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional });

            //routes.MapRoute(
            //name: "ProductDetails",
            //url: "Products/ProductDetails/{id}",
            //defaults: new { controller = "Products", action = "ProductDetails", id = UrlParameter.Optional });


        }
    }
}
