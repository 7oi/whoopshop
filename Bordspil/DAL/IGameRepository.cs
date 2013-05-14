using System;
using Bordspil.Models;

namespace Bordspil.DAL
{
    public interface IGameRepository
    {
        void DeleteGame(int gameID);
        void Dispose();
        Game GetGameByID(int id);
        System.Collections.Generic.IEnumerable<Game> GetGames();
        void InsertGame(Game game);
        void UpdateGame(Game game);

        void Save();

        void SaveGame(Game game);

        System.Collections.Generic.IEnumerable<GameType> GetGameType();
        object GetGameTypeByID(int? id);
    }
}
