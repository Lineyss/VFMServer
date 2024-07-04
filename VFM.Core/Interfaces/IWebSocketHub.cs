using System.Net.WebSockets;
using VFM.Core.Models;

namespace VFM.Core.Interfaces
{
    public interface IWebSocketHub
    {
        WebSocketModel? GetConnectionWebSocket(Guid id);
        (WebSocketModel WebSocket, string Error) RegisterNewWebSocket(Guid id, WebSocket webSocket);
    }
}