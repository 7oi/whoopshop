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

       
        public ActionResult Game(int? id)
        {
            
            if (id == null)
            {
                return RedirectToAction("About"); // var gert til að prufa hvort væri að koma inn null, þarf að búa til view til að búa til leik
            }
            GamesStoreViewModel modelDB = new GamesStoreViewModel();
            modelDB.Game = (from game in db.Games
                              where game.gameType.gameTypeID.Equals(id.Value)
                              select game);
            modelDB.GameType = (from type in db.GameTypes
                                where type.gameTypeID.Equals(id.Value)
                                select type);
            modelDB.UserProfile = (from user in db.UserProfiles
                                   select user);
            return View(modelDB);
        }

    }
}
