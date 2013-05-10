using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bordspil.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Online edit
            // Andri og Viktor biðja að heilsa frá ganginum.
            // hvað er í gangi?
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Game()
        {
            ViewBag.Message = "This is the Risk.";

            return View();
        }

    }
}
