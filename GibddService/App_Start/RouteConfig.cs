using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GibddService.Controllers;
using System.Dynamic;
using DataLayer.Models;
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
            routes.RegisterUserRoutes();
            routes.RegisterConfirmedUserRoutes();
            routes.RegisterGibddStaffRoutes();
            //В самом конце
            routes.RegisterDefaultRoute();
        }

        public static void RegisterHomeRoutes(this RouteCollection routes)
        {
            routes.MapActionFor<HomeController>(e => e.Index(), string.Empty);
            routes.MapActionFor<HomeController>(e => e.Contact(), "contact");
            routes.MapActionFor<HomeController>(e => e.About(), "about");
            routes.MapActionFor<HomeController>(e => e.Marks(), "marks");
            routes.MapActionFor<HomeController>(e => e.Test(), "test");
        }

        public static void RegisterAccountRoutes(this RouteCollection routes)
        {
            routes.MapActionFor<AccountController>(e => e.Login(null), "login");
            routes.MapActionFor<AccountController>(e => e.Login(null, null), "login");
            routes.MapActionFor<AccountController>(e => e.Register(), "register");
            routes.MapActionFor<AccountController>(e => e.Register(null), "register");
            routes.MapActionFor<AccountController>(e => e.LogOff(), "logout");
        }

        public static void RegisterUserRoutes(this RouteCollection routes)
        {
            routes.MapActionFor<UserController>(e => e.ChangeUserInfo((UserInfo)null), "change-user-info");
            routes.MapActionFor<UserController>(e => e.ChangeUserInfo(), "change-user-info");
        }

        public static void RegisterConfirmedUserRoutes(this RouteCollection routes)
        {
            routes.MapActionFor<ConfirmedUserController>(e => e.GetRegisterVehicles(), "get-register-vehicles");
            routes.MapActionFor<ConfirmedUserController>(e => e.RegisterVehicle((RegisterVehicleViewModel)null), "reguster-vehicle");
            routes.MapActionFor<ConfirmedUserController>(e => e.RegisterVehicle(), "reguster-vehicle");
            //routes.MapActionFor<ConfirmedUserController>(e => e.ChangeUserInfo((string)null), "change-user-info");
        }

        public static void RegisterGibddStaffRoutes(this RouteCollection routes)
        {
            routes.MapActionFor<GibddStaffController>(e => e.GetUnconfirmedUsers(), "unconfirmed-users");
            routes.MapActionFor<GibddStaffController>(e => e.ConfirmUser(null), "confirm-user");
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
