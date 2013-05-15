using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Bordspil.DAL;
using System.Web.Script.Serialization;
using Bordspil.GameService;
using System.Runtime.Caching;

namespace Bordspil
{
    // GameHub takes care of the signalR connection
    public class GameHub : Hub
    {
        public CardService theDeck = new CardService();
   
        public void Join(string groupId)
        {
            // Adds user to group
            Groups.Add(Context.ConnectionId, groupId);
        }

        public void ChatSend(string group, string name, string message)
        {
            // Sends chat message to all users in group
            // We want to make sure the trolls don't get to fill the chat with emptiness
            if (!String.IsNullOrWhiteSpace(message))
            {
                Clients.Group(group).sendMessage(name, message);
            }
        }

        public void ChooseSeat(string group, string seatnr)
        {
            Clients.Group(group).SitDown(seatnr);
            
        }

        public void LeaveGame(string group, string seatnr)
        {
            Clients.Group(group).Quit(seatnr);
        }

        public void MakeTheBet(string group, string seatnr)
        {
            Clients.Group(group).Bet(seatnr);
        }

        public void Turn(string group, string seatnr)
        {
            Clients.Group(group).WhosTurn(seatnr);
        }

        public void ShuffleTheDeck()
        {
            theDeck.Shuffle();
        }

        public void NewCard(string group, string seatnr, string upside)
        {
            Clients.Group(group).GetCard(seatnr, theDeck.DealCard(), upside);
        }

        public void UpdateTotal(string group, string seatnr)
        {
            Clients.Group(group).Total(group, seatnr);
        }

        public void PlayerStands(string group, string seatnr)
        {
            Clients.Group(group).Stand(seatnr);
        }


    }
}