using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Bordspil.Models;

namespace Bordspil.DAL
{
    public class GameRepository : Bordspil.DAL.IGameRepository
    {
        private AppDataContext context;

        public GameRepository(AppDataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This returns all games
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Game> GetGames()
        {
            return context.Games.ToList();
        }

        public Game GetGameByID(int id)
        {
            return context.Games.Find(id);
        }

        public void InsertGame(Game game)
        {
            context.Games.Add(game);
        }

        public void DeleteGame(int gameID)
        {
            Game game = context.Games.Find(gameID);
            context.Games.Remove(game);
        }

        public void UpdateGame(Game game)
        {
            context.Entry(game).State = EntityState.Modified;
        }

        private bool disposed = false;
        
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose ()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

    