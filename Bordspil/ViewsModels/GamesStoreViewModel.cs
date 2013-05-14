using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordspil.DAL;

namespace Bordspil.ViewsModels
{
    public class GamesStoreViewModel
    {
        public IEnumerable<Game> Game { get; set; }
        public IEnumerable<GameType> GameType { get; set; }
        public IEnumerable<UserProfile> UserProfile { get; set; }
    }

    public class GameInstanceModel
    {
        public Game GameInstance { get; set; }
        public GameType GameTypeInstance { get; set; }
    }

}