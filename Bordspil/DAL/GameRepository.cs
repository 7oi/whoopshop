using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Bordspil.DAL;
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


        public void Save()
        {
            context.SaveChanges();
        } 


        /// <summary>
        /// This returns all games
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Game> GetGames()
        {
            return context.Games.ToList();
        }

        /// <summary>
        /// returns game (instance) by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Game GetGameByID(int id)
        {
            return context.Games.Find(id);
        }



        /// <summary>
        /// Insert game (instance)
        /// </summary>
        /// <param name="game"></param>
        public void InsertGame(Game game)
        {
            context.Games.Add(game);
        }

        /// <summary>
        /// Delete game (instance)
        /// </summary>
        /// <param name="gameID"></param>
        public void DeleteGame(int gameID)
        {
            Game game = context.Games.Find(gameID);
            context.Games.Remove(game);
        }

        /// <summary>
        /// Updates game 
        /// </summary>
        /// <param name="game"></param>
        public void UpdateGame(Game game)
        {
            context.Entry(game).State = EntityState.Modified;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveGame(Game game)
        {
            context.SaveChanges(game);
        }

        public IEnumerable<GameType> GetGameType()
        {
            return context.GameTypes.ToList();
        }


        /// <summary>
        /// returns game type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GameType GetGameTypeByID(int id)
        {
            return context.GameTypes.Find(id);
        }


        public void UpdateGameType(GameType gameType)
        {
            context.Entry(gameType).State = EntityState.Modified;
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


        public object GetGameTypeByID(int? id)
        {
            throw new NotImplementedException();
        }

        void IGameRepository.DeleteGame(int gameID)
        {
            throw new NotImplementedException();
        }

        void IGameRepository.Dispose()
        {
            throw new NotImplementedException();
        }

        Game IGameRepository.GetGameByID(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Game> IGameRepository.GetGames()
        {
            throw new NotImplementedException();
        }

        void IGameRepository.InsertGame(Game game)
        {
            throw new NotImplementedException();
        }

        void IGameRepository.UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }

        void IGameRepository.Save()
        {
            throw new NotImplementedException();
        }

        void IGameRepository.SaveGame(Game game)
        {
            throw new NotImplementedException();
        }

        object IGameRepository.GetGameTypeByID(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
