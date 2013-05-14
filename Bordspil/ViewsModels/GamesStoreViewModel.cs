using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordspil.Models;

namespace Bordspil.ViewsModels
{
    public class GamesStoreViewModel
    {
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<GameType> GameTypes { get; set; }
        public IEnumerable<User> Users { get; set; }
    }

    public class GameInstanceModel
    {
        public Game GameInstance { get; set; }
        public GameType GameTypeInstance { get; set; }
    }

}