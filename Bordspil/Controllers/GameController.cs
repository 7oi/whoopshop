using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bordspil.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewGame(int type)
        {
            return View();
        }

        public ActionResult Play(int gameID)
        {
            return View();
        }

        public ActionResult View(int gameID)
        {
            return View();
        }
    }
}
