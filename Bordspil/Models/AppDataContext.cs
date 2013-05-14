using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Bordspil.Models
{
    public class AppDataContext : DbContext
    {
        /// <summary>
        /// Class that coordinates Entity Framework functionality
        /// </summary>
        public AppDataContext()
            : base("DefaultConnection")
        {
        }
        /// <summary>
        /// Property sets for all entity sets
        /// One set represents one database table
        /// </summary>
        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ExternalUserInformation> ExternalUsers { get; set; }

        /// <summary>
        /// Prevents table names from being pluralized
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Game>();
            modelBuilder.Entity<GameType>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<ExternalUserInformation>();

        }


        internal void SaveChanges(Game game)
        {
            throw new NotImplementedException();
        }
    }
}