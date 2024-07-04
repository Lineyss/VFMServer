using System.Linq;
using System.Net.WebSockets;
using System.Text;
using VFM.Core.Interfaces;
using VFM.Core.Models;

namespace VFM.Application.Services
{
    public class WebSocketHub : IWebSocketHub
    {
        private static List<WebSocketModel> connectionWebSockets = new();
        public (WebSocketModel?, string) RegisterNewWebSocket(Guid id, WebSocket webSocket)
        {
            if (webSocket == null) throw new Exception("WebSocket is None");

            if (connectionWebSockets.FirstOrDefault(element => element.ID == id) == null) return (null, "Ошибка: сокет уже подключен");

            (WebSocketModel model, string Error) = WebSocketModel.Create(webSocket);

            if (model == null) throw new Exception(Error);

            connectionWebSockets.Add(model);

            return (model, "");
        }

        public async Task RecieveMessage(WebSocketModel webSocketModel)
        {
            var buffer = new ArraySegment<byte>(new byte[1024]);
            WebSocket _webSocket = webSocketModel.WebSocket;
            
        }
        public async Task SendMessage(WebSocketModel webSocketModel, string message)
        {
            var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            await webSocketModel.WebSocket.SendAsync(buffer, WebSocketMessageType.Text, true, webSocketModel.Token);
        }

        public WebSocketModel? GetConnectionWebSocket(Guid id) => connectionWebSockets.FirstOrDefault(element=> element.ID == id);
    }
}
