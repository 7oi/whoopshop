using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bordspil.Models
{
    public class RiskRepository : GameRepository
    {
        public int landID { get; set; }
        public string landName { get; set; }
        public int continentID { get; set; }
        //public List<landID> neighbouringLands { get; set; }
        public int occupier { get; set; }
        public int numberOfTroops { get; set; }
    }
}