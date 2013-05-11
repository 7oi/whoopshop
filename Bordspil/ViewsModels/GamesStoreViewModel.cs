using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bordspil.ViewsModels
{
    public class GamesStoreViewModel
    {
        public IEnumerable<Bordspil.Models.Game> Game { get; set; }
        public IEnumerable<Bordspil.Models.GameType> GameType { get; set; }
        public IEnumerable<Bordspil.Models.UserProfile> UserProfile { get; set; }
    }
}