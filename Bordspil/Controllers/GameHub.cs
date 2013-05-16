using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Bordspil.DAL;
using System.Web.Script.Serialization;
using Bordspil.GameService;
using System.Runtime.Caching;
using Bordspil.Models;

namespace Bordspil
{
    // GameHub takes care of the signalR connection
    public class GameHub : Hub
    {
        #region Properties
        public static Deck theDeck { get; set; }
        public Dice theDice { get; set; }
        public UserRepository users { get; set; }
        public GameRepository games { get; set; }
        public List<Player> players { get; set; }
        #endregion

        #region Constructor
        public GameHub()
        {
            users = new UserRepository(new AppDataContext());
            games = new GameRepository(new AppDataContext());
        }
        #endregion

        #region Basic functions
        /// <summary>
        /// Join joins current user into the game
        /// </summary>
        /// <param name="groupId"></param>
        public void Join(string groupId)
        {
            // Adds user to group
            Groups.Add(Context.ConnectionId, groupId);
        } 
        #endregion

        #region Chat

        /// <summary>
        /// Sends chat messages between users
        /// </summary>
        /// <param name="group"></param>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public void ChatSend(string group, string message)
        {
            // Sends chat message to all users in group
            // We want to make sure the trolls don't get to fill the chat with emptiness
            if (!String.IsNullOrWhiteSpace(message))
            {
                Clients.Group(group).sendMessage(message);
            }
        } 
        #endregion

        #region Player actions
        /// <summary>
        /// Function for creating the dealer
        /// </summary>
        /// <param name="group"></param>
        public void CreateDealer(string group)
        {
            Clients.Group(group).Dealer();
        }

        /// <summary>
        /// Broadcasts when user chooses a seat to others in the group
        /// </summary>
        /// <param name="group"></param>
        /// <param name="me"></param>
        /// <param name="points"></param>
        /// <param name="seatnr"></param>
        public void ChooseSeat(string group, string seatnr)
        {
            int seat = Convert.ToInt32(seatnr);
            // Find the user in the database
            var usr = users.GetUserByName(HttpContext.Current.User.Identity.Name);
            Clients.Group(group).SitDown(usr.UserName, usr.Points, seat);
        }

        /// <summary>
        /// Broadcasts when user leaves game to other users
        /// </summary>
        /// <param name="group"></param>
        /// <param name="seatnr"></param>
        public void LeaveGame(string group, string points, string seatnr)
        {
            var usr = users.GetUserByName(HttpContext.Current.User.Identity.Name);
            usr.Points = Convert.ToInt32(points);
            users.UpdateUser(usr);
            users.Save();
            Clients.Group(group).Quit(seatnr);
        }

        /// <summary>
        /// If the player stands
        /// </summary>
        /// <param name="group"></param>
        /// <param name="me"></param>
        /// <param name="seatnr"></param>
        public void PlayerStands(string group, string me, string seatnr)
        {
            Clients.Group(group).Stand(me, seatnr);
        }

        /// <summary>
        /// Updates the total score of players
        /// </summary>
        /// <param name="group"></param>
        /// <param name="seatnr"></param>
        public void UpdateTotal(string group, string seatnr)
        {
            Clients.Group(group).Total(group, seatnr);
        }

        /// <summary>
        /// Handles the betting
        /// </summary>
        /// <param name="group"></param>
        /// <param name="seatnr"></param>
        /// <param name="amount"></param>
        public void MakeTheBet(string group, string seatnr, string amount)
        {
            Clients.Group(group).Bet(seatnr, amount);
        }

        public void ReturnWinnings(string points)
        {
            var usr = users.GetUserByName(HttpContext.Current.User.Identity.Name);
            usr.Points = Convert.ToInt32(points);
            users.UpdateUser(usr);
            users.Save();
        }
        #endregion

        #region Card tricks
        /// <summary>
        /// Creates a new deck of cards for the game
        /// </summary>
        public void CreateDeck()
        {
            theDeck = new Deck();
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        public void ShuffleTheDeck()
        {
            theDeck.Shuffle();
        }

        /// <summary>
        /// Draws a new card
        /// </summary>
        /// <param name="group"></param>
        /// <param name="seatnr"></param>
        /// <param name="upside"></param>
        /// 
        public void NewCard(string group, string seatnr, string upside)
        {
            Random v = new Random();
            Random s = new Random();
            Card c = new Card(v.Next(1, 13), s.Next(1, 4));
            Clients.Group(group).GetCard(seatnr, c, upside);
        } 
        #endregion

        public void Turn(string group, string seatnr)
        {
            Clients.Group(group).WhosTurn(seatnr);
        }



        

        

    }

    
}