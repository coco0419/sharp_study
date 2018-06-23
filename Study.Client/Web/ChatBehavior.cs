using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Study.Client.Web
{
    public class ChatBehavior : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            base.OnMessage(e);

            Sessions.Broadcast(string.Empty);
        }
    }
}