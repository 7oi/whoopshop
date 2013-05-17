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
using System.IO;

namespace Bordspil.Controllers
{
    public class GameController : Controller
    {
        private GameRepository db;
        GamesStoreViewModel model = new GamesStoreViewModel();

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
        
        public ActionResult Create(string input)
        {
            if (input == null)
            {
                return RedirectToAction("Home");
            }
            Game game = new Game();
            game.gameType = db.GetGameTypeByName(input);
            game.gameActive = true;
            game.gameName = game.gameType.gameTypeName + " " + db.GetAllGameByGameType(input).Count();
            db.InsertGame(game);
            return RedirectToAction("Play", game);
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

        public ActionResult Games(string name)
        {

            if (name == null)
            {
                return RedirectToAction("About"); // var gert til að prufa hvort væri að koma inn null, þarf að búa til view til að búa til leik
            }
            model.Games = db.GetAllGameByGameType(name);
            model.GameTypeInstance = db.GetGameTypeByName(name);
            return View(model);
        }
           
        public ActionResult Play(Game game)
        {
            
            if (game == null)
            {
                return RedirectToAction("Home");
            }
            if (User.Identity.IsAuthenticated.Equals(false))
            {
                RedirectToAction("Login");
            }
            model.GameInstance = db.GetGameByID(game.gameID);
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
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult NewGameType(GameType gameType, IEnumerable<HttpPostedFileBase> files)
        {
            db.CreateGameType(gameType);
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Games/" + gameType.gameTypeName), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddNewGame()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewGame(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Games"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}