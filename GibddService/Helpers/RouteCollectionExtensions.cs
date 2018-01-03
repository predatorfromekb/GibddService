﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace GibddService.Helpers
{
    public static class RouteCollectionExtensions
    {
        public static Dictionary<Type, string> Dict = new Dictionary<Type, string>
        {
            {typeof(Task<ActionResult>), "_Async"},
            {typeof(ActionResult), string.Empty}
        };
        public static void MapActionFor<T>(this RouteCollection routes,
            Expression<Func<T, ActionResult>> expression, string url) where T : Controller
        {
            routes.MapAction(expression, url);
        }

        public static void MapActionFor<T>(this RouteCollection routes,
            Expression<Func<T, Task<ActionResult>>> expression, string url) where T : Controller
        {
            routes.MapAction(expression, url);
        }

        private static void MapAction<T, T1>(this RouteCollection routes,
            Expression<Func<T, T1>> expression, string url)
        {
            var controller = typeof(T).Name.Replace("Controller", string.Empty);//TODO - поменять реализацию
            var action = ((MethodCallExpression)expression.Body).Method.Name;
            var defaults = new { controller, action };
            var name = $"{controller}_{action}_{Dict[typeof(T1)]}";
            routes.MapRoute(name, url, defaults);
        }
    }
}