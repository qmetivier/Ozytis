using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GestionBateaux
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GestionPersonnes",
                url: "{controller}/{hiddenAction}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { hiddenAction = "hiddenAction" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{type}",
                defaults: new { controller = "Home", action = "Index", type = "Index" }
            );
        }
    }
}
