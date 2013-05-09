using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Bordspil.Models
{
    
    public partial class Game
    {
        [Key]
        public int gameID { get; set; }
        public string gameName { get; set; }
        public bool gameActive { get; set; }
        public ICollection<UserProfile> gamePlayers { get; set; }
        public int numberOfPlayers { get; set; }
        public UserProfile gameWinner { get; set; }
    }
}