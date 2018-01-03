using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace GibddService.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ActionLinkFor<T>(this HtmlHelper helper, string name,
            Expression<Func<T, ActionResult>> expression, object routeValues = null, object htmlAttributes = null) where T : Controller
        {
            return helper.ActionLink(name, expression, routeValues, htmlAttributes);
        }

        public static MvcHtmlString ActionLinkAsyncFor<T>(this HtmlHelper helper, string name,
            Expression<Func<T, Task<ActionResult>>> expression, object routeValues = null, object htmlAttributes = null) where T : Controller
        {
            return helper.ActionLink(name, expression, routeValues, htmlAttributes);
        }

        private static MvcHtmlString ActionLink<T, T1>(this HtmlHelper helper, string name,
            Expression<Func<T, T1>> expression, object routeValues, object htmlAttributes)
        {
            var controller = typeof(T).Name.Replace("Controller", string.Empty);//TODO - поменять реализацию
            var action = ((MethodCallExpression)expression.Body).Method.Name;
            return helper.ActionLink(name, action, controller, routeValues, htmlAttributes);
        }

        public static MvcForm BeginFormFor<T>(this HtmlHelper helper,
            Expression<Func<T, ActionResult>> expression, FormMethod formMethod, object routeValues = null) where T : Controller
        {
            return helper.BeginForm(expression, formMethod, routeValues);
        }

        public static MvcForm BeginFormAsyncFor<T>(this HtmlHelper helper,
            Expression<Func<T, Task<ActionResult>>> expression, FormMethod formMethod, object routeValues = null) where T : Controller
        {
            return helper.BeginForm(expression, formMethod, routeValues);
        }

        private static MvcForm BeginForm<T, T1>(this HtmlHelper helper,
            Expression<Func<T, T1>> expression, FormMethod formMethod, object routeValues)
        {
            var controller = typeof(T).Name.Replace("Controller", string.Empty);//TODO - поменять реализацию
            var action = ((MethodCallExpression)expression.Body).Method.Name;
            return helper.BeginForm(action, controller, formMethod, routeValues);
        }
    }
}