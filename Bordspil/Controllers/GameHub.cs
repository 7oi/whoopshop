using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Bordspil.DAL;
using System.Web.Script.Serialization;
using Bordspil.GameService;
using System.Runtime.Caching;
using System.Threading.Tasks;
using Bordspil.Models;
using System.Threading;

namespace Bordspil
{
    public class GameEndPoint : PersistentConnection
    {

    }
    // GameHub takes care of the signalR connection
    public class GameHub : Hub
    {
        #region Properties
        //public static Deck theDeck { get; set; }
        public static Dice theDice { get; set; }
        //public static List<ConnectedPlayer> players;
        public int NumPlayers = 0;

        public UserRepository users = new UserRepository(new AppDataContext());
        public GameRepository games { get; set; }
        
        #endregion

        #region Constructor

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

        //public override Task OnConnected()
        //{    
        //    return base.OnConnected();
        //}
        //public List<ConnectedPlayer> UpdateView()
        //{

        //    return players;
        //}

        public int NumberOfPlayers()
        {
            return NumPlayers;
        }

        #endregion

        #region Chat

        /// <summary>
        /// Sends chat messages between users
        /// </summary>
        /// <param name="group"></param>
        /// <param name="message"></param>
        public void ChatSend(string group, string me, string message)
        {
            // Sends chat message to all users in group
            // We want to make sure the trolls don't get to fill the chat with emptiness
            if (!String.IsNullOrWhiteSpace(message))
            {
                Clients.Group(group).SendMessage(me, message);
            }
        } 
        #endregion

        #region Player actions

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
            NumPlayers++;
            // Find the user in the database
            var usr = users.GetUserByName(HttpContext.Current.User.Identity.Name);
            //players.Add( new ConnectedPlayer(usr.UserName, Context.ConnectionId, usr.Points, seat));
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
            NumPlayers--;
            //var discard = players.Find(p => p.Name == usr.UserName);
            //players.Remove(discard);
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
            Clients.Group(group).Total(seatnr);
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

        /// <summary>
        /// Takes care of returning the winnings to the players
        /// </summary>
        /// <param name="points"></param>
        public void ReturnWinnings(string group, string name, string seatnr, string points)
        {
            var usr = users.GetUserByName(name); 
            usr.Points = Convert.ToInt32(points);
            users.UpdateUser(usr);
            users.Save();
            Thread.Sleep(2000);
            Clients.Group(group).ResetGame(name, seatnr);
            Clients.OthersInGroup(group).ResetGameForOutsiders();
        }

        public void DealerStart(string group)
        {
            Clients.Group(group).StartRound();
        }
        #endregion

        #region Card tricks
        /// <summary>
        /// Creates a new deck of cards for the game
        /// </summary>
        //public void CreateDeck()
        //{
        //    theDeck = new Deck();
        //}

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        //public void ShuffleTheDeck()
        //{
        //    theDeck.Shuffle();
        //}

        /// <summary>
        /// Draws a new card
        /// </summary>
        /// <param name="group"></param>
        /// <param name="seatnr"></param>
        /// <param name="upside"></param>
        /// 
        public void NewCard(string group, string seatnr, Card dealt)
        {
            var c = new { value = Convert.ToInt32(dealt.Value), suit = Convert.ToInt32(dealt.Suit), upside = Convert.ToInt32(dealt.upside) };
            Clients.Group(group).GetCard(seatnr, c);
        } 
        #endregion

        public void Turn(string group, string seatnr)
        {
            Clients.Group(group).WhosTurn(seatnr);
        }
    }
}