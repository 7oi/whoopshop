using System;
namespace Bordspil.DAL
{
    public interface IGameRepository
    {
        void DeleteGame(int gameID);
        void Dispose();
        Bordspil.Game GetGameByID(int id);
        System.Collections.Generic.IEnumerable<Bordspil.Game> GetGames();
        void InsertGame(Bordspil.Game game);
        void UpdateGame(Bordspil.Game game);
    }
}
