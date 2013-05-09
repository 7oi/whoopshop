using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Bordspil
{
    public class GameHub : Hub
    {
        public void Join(string groupId)
        {
            Groups.Add(Context.ConnectionId, groupId);
        }

        public void ChatSend(string groupName, string name, string message)
        {
            // TO DO: Implement like in tutorial
            // Clients.OthersInGroup(groupName).sendMessage(name, message);
        }
    }
}