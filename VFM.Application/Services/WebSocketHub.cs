using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace VFM.Application.Services
{
    public class WebSocketHub
    {
        private static Dictionary<Guid, WebSocket> connectionWebSocket = new Dictionary<Guid, WebSocket>();
        public (bool, string) RegisterNewWebSocket(Guid id, WebSocket webSocket)
        {
            if (connectionWebSocket.TryGetValue(id, out webSocket)) return (false, "Ошибка: сокет уже подключен");
            if (webSocket == null) throw new Exception("WebSocket is None");
/*            if (id.) throw new Exception("Id is None");*/
            connectionWebSocket.Add(id, webSocket);

            return (true, "");
        }

        public WebSocket GetConnection
    }
}
