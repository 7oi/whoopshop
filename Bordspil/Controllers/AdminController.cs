using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bordspil.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserStats(int userId)
        {
            return View();
        }

        public ActionResult GameStats(int gameId)
        {
            return View();
        }

    }
}
