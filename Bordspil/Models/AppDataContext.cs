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
        public AppDataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<BJ> BlackJackInstances { get; set; }
        public DbSet<Risk> RiskInstances { get; set; }
        public DbSet<Country> RiskCountries { get; set; }
        public DbSet<Continent> RiskContinents { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}