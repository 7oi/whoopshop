using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Bordspil.Models
{
    public class Risk : Game
    {
        public ICollection<Country> countries { get; set; }
    }

    public class Country
    {
        [Key]
        public int countryID { get; set; }
        public string countryName { get; set; }
        public Continent continent { get; set; }
        public ICollection<Country> neighbouringCountries { get; set; }
        //public UserProfile occupierID { get; set; }
        public int numberOfTroops { get; set; }
    }

    public class Continent
    {
        [Key]
        public int continentID { get; set; }
        public string continentName { get; set; }
        public int numCountriesInContinent { get; set; }
        public ICollection<Country> countriesInContinent { get; set; }
    }

}