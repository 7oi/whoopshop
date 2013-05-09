using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Bordspil.Models;

namespace Bordspil.Initializers
{
    public class RiskInitializer : DropCreateDatabaseIfModelChanges<GameContext>
    {
        protected override void Seed(GameContext context)
        {
            var countries = new List<Country> 
            {
                new Country { countryName = "Alaska", continent = null, numberOfTroops = 0, neighbouringCountries = null},
            };
            countries.ForEach(c => context.RiskCountries.Add(c));
            context.SaveChanges();

            var continents = new List<Continent> 
            {
                new Continent { continentID = 1, continentName = "North America", numCountriesInContinent = 9 },
                new Continent { continentID = 2, continentName = "South America", numCountriesInContinent = 4 },
                new Continent { continentID = 3, continentName = "Europe", numCountriesInContinent = 7 },
                new Continent { continentID = 4, continentName = "Africa", numCountriesInContinent = 6 },
                new Continent { continentID = 5, continentName = "Asia", numCountriesInContinent = 12 },
                new Continent { continentID = 6, continentName = "Australia", numCountriesInContinent = 4 },
            };
            continents.ForEach(con => context.RiskContinents.Add(con));
            context.SaveChanges();

            var risks = new List<Risk> 
            {
                new Risk { gameName = "foo", gameActive = false, numberOfPlayers = 2 },
            };
            risks.ForEach(r => context.RiskInstances.Add(r));
            context.SaveChanges();


        }
    }
}