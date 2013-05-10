using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Bordspil.Models
{
    
    public class Game
    {
        [Key]
        public int gameID { get; set; }
        public string gameName { get; set; }
        public GameType gameType { get; set; }
        public bool gameActive { get; set; }
        public ICollection<UserProfile> gamePlayers { get; set; }
        public bool gamePending { get; set; }
        public UserProfile gameWinner { get; set; }
    }

    public class GameType
    {
        [Key]
        public int gameTypeID { get; set; }
        public string gameTypeName { get; set; }
        public int maxPlayers { get; set; }
        public int minPlayers { get; set; }
        public string gameTypeLink { get; set; }
        public string gameTypeImgUrl { get; set; }
    }
}