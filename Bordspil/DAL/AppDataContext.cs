using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Bordspil.DAL
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<User> UserProfiles { get; set; }
        public DbSet<ExternalUserInformation> ExternalUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}