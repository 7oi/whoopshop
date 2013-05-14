using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bordspil.DAL;
using Bordspil.ViewsModels;
using Bordspil.Models;

namespace Bordspil.DAL
{
    public class HomeController : Controller
    {

        GameRepository db = new GameRepository(new AppDataContext());

        public ActionResult Index()
        {
            var gameType = db.GetGameType();
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
        
    }
}
