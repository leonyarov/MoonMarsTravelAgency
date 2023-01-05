using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MoonMarsTravelAgency
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
            //name: "Payment",
            //url: "{controller}/{action}/{card}/{op}",
            //defaults: new { controller = "Home", action = "Index",card = UrlParameter.Optional ,op = UrlParameter.Optional }
        
        }
    }
}
