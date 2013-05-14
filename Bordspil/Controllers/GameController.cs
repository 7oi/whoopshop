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
        private IGameRepository GameRepository;

        public GameController() 
        { 
            this.GameRepository = new GameRepository(new AppDataContext()); 
        } 
 
        public GameController(IGameRepository gameRepository) 
        { 
            this.GameRepository = gameRepository; 
        } 
        //
        // GET: /Game/

        public ActionResult Index()
        {
            //var id = 1;
            //Game game = GameRepository.GetGameByID(id);
            //GameRepository.
            var activeGames = (from games in GameRepository.GetGames()
                               where games.gameActive == true
                               select games).Take(10);
            return View(activeGames.ToList());
        }

        //
        // GET: /Game/Details/5

        public ActionResult Details(int id = 0)
        {
            
            Game game = GameRepository.GetGameByID(id);
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
                GameRepository.InsertGame(game);
                //GameRepository.();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        //
        // GET: /Game/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Game game = GameRepository.GetGameByID(id);
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
                GameRepository.UpdateGame(game);
                //db.Entry(game).State = EntityState.Modified;
                GameRepository.SaveGame(game);
                //GameRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        //
        // GET: /Game/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Game game = GameRepository.GetGameByID(id);
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
            Game game = GameRepository.GetGameByID(id);
            GameRepository.DeleteGame(id);
            GameRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            GameRepository.Dispose();
            //base.Dispose(disposing);
        }

        public ActionResult Game(string name)
        {

            if (name == null)
            {
                return RedirectToAction("About"); // var gert til að prufa hvort væri að koma inn null, þarf að búa til view til að búa til leik
            }

            return View();
        }
           /* GamesStoreViewModel modelDB = new GamesStoreViewModel();
            modelDB.Game = (from game in GameRepository.GetGames()
                            where gameName == name
                            select game);
            modelDB.GameType = (from type in db.GameTypes
                                where type.gameTypeName.Equals(name)
                                select type);
            //modelDB.UserProfile = (from user in db.UserProfiles
            //                       select user);
            return View(modelDB);
        }
            */
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
            GameInstanceModel model = new GameInstanceModel();
            model.GameInstance = (from g in GameRepository.GetGames()
                                  where g.gameID == id
                                  select g).SingleOrDefault();

          /*  model.GameTypeInstance = (from t in GameRepository.GetGameTypeByID(id)
                                      //where t.gameTypeID == model.GameInstance.gameType.gameTypeID
                                      select t).First();*/
            
            return View(model);
        }
    }
}