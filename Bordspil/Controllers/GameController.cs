using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bordspil.Models;
using Bordspil.ViewsModels;

namespace Bordspil.Controllers
{
    public class GameController : Controller
    {
        private AppDataContext db = new AppDataContext();

        //
        // GET: /Game/

        public ActionResult Index()
        {
            var activeGames = (from games in db.Games
                               where games.gameActive == true
                               select games).Take(10);
            return View(activeGames.ToList());
        }

        //
        // GET: /Game/Details/5

        public ActionResult Details(int id = 0)
        {
            
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        //
        // GET: /Game/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Game/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        //
        // GET: /Game/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        //
        // POST: /Game/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        //
        // GET: /Game/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        //
        // POST: /Game/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Game(string name)
        {

            if (name == null)
            {
                return RedirectToAction("About"); // var gert til að prufa hvort væri að koma inn null, þarf að búa til view til að búa til leik
            }
            GamesStoreViewModel modelDB = new GamesStoreViewModel();
            modelDB.Game = (from game in db.Games
                            where game.gameType.gameTypeName.Equals(name)
                            select game);
            modelDB.GameType = (from type in db.GameTypes
                                where type.gameTypeName.Equals(name)
                                select type);
            modelDB.UserProfile = (from user in db.UserProfiles
                                   select user);
            return View(modelDB);
        }

        public ActionResult Play(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Game");
            }
            if (User.Identity.IsAuthenticated.Equals(false))
            {
                RedirectToAction("Acount/Login");
            }
            GamesStoreViewModel modelDB = new GamesStoreViewModel();
            modelDB.Game = (from g in db.Games
                            where g.gameID.Equals(id)
                            select g);
            return View(modelDB);
        }
    }
}