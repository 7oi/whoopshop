using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bordspil.DAL;
using Bordspil.ViewsModels;
using Bordspil.Models;

namespace Bordspil.Controllers
{
    public class GameController : Controller
    {
        private GameRepository db;

        public GameController() 
        { 
            this.db = new GameRepository(new AppDataContext());
        } 
 
        public GameController(GameRepository gameRepository) 
        { 
            this.db = gameRepository; 
        } 
        //
        // GET: /Game/

        public ActionResult Index()
        {
            //var id = 1;
            //Game game = GameRepository.GetGameByID(id);
            //GameRepository.
            var activeGames = (from games in db.GetGames()
                               where games.gameActive == true
                               select games).Take(10);
            return View(activeGames.ToList());
        }

        //
        // GET: /Game/Details/5

        public ActionResult Details(int id = 0)
        {
            
            Game game = db.GetGameByID(id);
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
                db.InsertGame(game);
                //GameRepository.();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        //
        // GET: /Game/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Game game = db.GetGameByID(id);
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
                db.UpdateGame(game);
                //db.Entry(game).State = EntityState.Modified;
                db.SaveGame(game);
                //GameRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        //
        // GET: /Game/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Game game = db.GetGameByID(id);
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
            Game game = db.GetGameByID(id);
            db.DeleteGame(id);
            db.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            //base.Dispose(disposing);
        }

        public ActionResult Game(string name)
        {

            if (name == null)
            {
                return RedirectToAction("About"); // var gert til að prufa hvort væri að koma inn null, þarf að búa til view til að búa til leik
            }
            GamesStoreViewModel game = new GamesStoreViewModel();
            game.Games = db.GetAllGameByGameType(name);
            game.GameTypeInstance = db.GetGameTypeByName(name);
            return View(game);
        }
           
        public ActionResult Play(int? id)
        {
            
            if (id == null)
            {
                return RedirectToAction("Game");
            }
            if (User.Identity.IsAuthenticated.Equals(false))
            {
                RedirectToAction("Login");
            }
            GamesStoreViewModel model = new GamesStoreViewModel();
            model.GameInstance = (from g in db.GetGames()
                                  where g.gameID == id
                                  select g).SingleOrDefault();
            model.GameTypeInstance = (from t in db.GetGameType()
                                      where t.gameTypeID == model.GameInstance.gameType.gameTypeID
                                      select t).SingleOrDefault();
            return View(model);
        }

        public ActionResult LeikreglurAllar()
        {
            return View();
        }

        public ActionResult ReglurBJ()
        {
            return View();
        }

        public ActionResult ReglurRisk()
        {
            return View();
        }
    }
}