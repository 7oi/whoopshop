using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Bordspil.Models;

namespace Bordspil.DAL
{
    public class BordspilInitializer : DropCreateDatabaseIfModelChanges<AppDataContext>
    {
        protected override void Seed(AppDataContext context)
        {
            var users = new List<User>
            {
                new User {UserID = 1, UserName = "Hercules", Points = 999, ProfilePicUrl = ""  },
                new User {UserID = 2, UserName = "Socrates", Points = 42, ProfilePicUrl = ""  },
                new User {UserID = 3, UserName = "Randver", Points = 82, ProfilePicUrl = ""  },
                new User {UserID = 4, UserName = "Tumi Tiger", Points = 99, ProfilePicUrl = ""  },
                new User {UserID = 5, UserName = "Ævar Angantýr Óla", Points = 0, ProfilePicUrl = ""  }
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var games = new List<Game>
            {
                new Game { gameActive = true, gameID = 1, gameName = "Risk", gamePending = false,
                    gamePlayers = new List<User>(),  gameWinner = new User() },

                new Game { gameActive = false, gameID = 2, gameName = "BJ", gamePending = true,
                    gamePlayers = new List<User>(),  gameWinner = new User() }
 
            };
            games.ForEach(s => context.Games.Add(s));
            context.SaveChanges();

            var gamet = new List<GameType>
            {
                new GameType { gameTypeID = 1, gameTypeImgUrl = "", gameTypeLink = "",
                    gameTypeName = "RISK", maxPlayers = 10, minPlayers = 2},

                new GameType { gameTypeID = 2, gameTypeImgUrl = "", gameTypeLink = "",
                    gameTypeName = "BJ", maxPlayers = 100, minPlayers = 20}

            };
            gamet.ForEach(s => context.GameTypes.Add(s));
            context.SaveChanges();

            var externals = new List<ExternalUserInformation>
            {
                new ExternalUserInformation { FullName = "Viktor besti", Id = 1,
                    Link = "", UserId = 1, Verified = true},
                new ExternalUserInformation { FullName = "Andri töffari", Id = 2,
                    Link = "", UserId = 2, Verified = false}

            };
            externals.ForEach(s => context.ExternalUsers.Add(s));
            context.SaveChanges();


        }

    }
}