using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bordspil.Models;
using Bordspil.ViewsModels;

namespace Bordspil.Controllers
{
    public class HomeController : Controller
    {
        AppDataContext db = new AppDataContext();

        public ActionResult Index()
        {
            var gameType = (from c in db.GameTypes
                            orderby c.gameTypeID ascending
                            select c).Take(15);
            if (gameType == null)
            {
                return View();
            }
            
            return View(gameType);
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
        
        public ActionResult UserList()
        {
            var userlist = (from u in db.UserProfiles
                        orderby u.UserId ascending
                        select u);
            return View(userlist);
        }

    }
}
