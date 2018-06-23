using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSocketSharp.Server;

namespace Study.Client.Web
{
    public static class WebSocket
    {
        private static WebSocketServer _server;

        public static void Start()
        {
            if (_server != null)
            {
                return;
            }

            _server = new WebSocketServer(4545);
            _server.AddWebSocketService<ChatBehavior>("/chat");

            _server.Start();
        }

        public static void Stop()
        {
            if (_server == null)
            {
                return;
            }

            _server.Stop();
        }
    }
}