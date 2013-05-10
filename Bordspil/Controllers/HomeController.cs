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
            ViewBag.Message = "Þetta msg kemur úr HomeController.cs";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Þetta msg kemur úr Homecontroller.cs";

            return View();
        }
    }
}
