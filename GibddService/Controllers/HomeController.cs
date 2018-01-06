using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using DataLayer.Models;
using DataLayer.Models.UserRoles;
using DataLayer.Repositories;
using Microsoft.AspNet.Identity;

namespace GibddService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Marks()
        {
            var model = MarkRepository.Get();
            return View(model);
        }

        public ActionResult Test()
        {
            return View("Index");
        }
    }
}