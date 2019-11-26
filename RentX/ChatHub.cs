using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace RentX
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {

            Clients.All.addNewMessageToPage(name, message);

        }
        //public void Send(string name, string message, string connId)
        //{
        //    Clients.Client(connId).broadcastMessage(name, message);
        //}
    }
}