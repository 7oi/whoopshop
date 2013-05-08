using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bordspil.Models
{
    public class GameEntity
    {
        public int gameID { get; set; }
        public int gameType { get; set; }
        public string gameName { get; set; }
        public bool gameActive { get; set; }
        //public List<userID> gamePlayers { get; set; } // userID not declared yet
        public int numberOfPlayers { get; set; }
        //  public chatID gameChat { get; set; } -- chat not implemented
        //public userID gameWinner { get; set; }
    }
}