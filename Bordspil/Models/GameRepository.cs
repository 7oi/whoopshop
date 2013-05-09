using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Bordspil.Models
{
    public class GameContext : DbContext
    {
        public GameContext() : base("DefaultConnection")
        {
        }

        public DbSet<BJ> BlackJackInstances { get; set; }
        public DbSet<Risk> RiskInstances { get; set; }
        public DbSet<Country> RiskCountries { get; set; }
        public DbSet<Continent> RiskContinents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public partial class Game
    {
        [Key]
        public int gameID { get; set; }
        public string gameName { get; set; }
        public bool gameActive { get; set; }
        //public ICollection<UserProfile> gamePlayers { get; set; } // userID not declared yet
        public int numberOfPlayers { get; set; }
        public int gameWinner { get; set; }
    }
}