using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GibddService.Controllers;
using System.Dynamic;
using GibddService.Helpers;
using GibddService.Models;

namespace GibddService
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.RegisterHomeRoutes();
            routes.RegisterAccountRoutes();

            //В самом конце
            routes.RegisterDefaultRoute();
        }

        public static void RegisterHomeRoutes(this RouteCollection routes)
        {
            routes.MapActionFor<HomeController>(e => e.Index(), string.Empty);
            routes.MapActionFor<HomeController>(e => e.Contact(), "contact");
            routes.MapActionFor<HomeController>(e => e.About(), "about");
        }

        public static void RegisterAccountRoutes(this RouteCollection routes)
        {
            routes.MapActionFor<AccountController>(e => e.Login(null), "login");
            routes.MapActionFor<AccountController>(e => e.Login(null, null), "login");
            routes.MapActionFor<AccountController>(e => e.Register(), "register");
            routes.MapActionFor<AccountController>(e => e.Register(null), "register");
            routes.MapActionFor<AccountController>(e => e.LogOff(), "logout");
        }

        public static void RegisterDefaultRoute(this RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional});
        }
    }
}
