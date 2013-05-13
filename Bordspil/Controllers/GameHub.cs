using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Bordspil.Models;

namespace Bordspil
{
    // GameHub takes care of the signalR connection
    public class GameHub : Hub
    {
        
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

    }
}