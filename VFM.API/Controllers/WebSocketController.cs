using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;

namespace VFM.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebSocketController : Controller
    {
        private async Task Receive(WebSocket webSocket, Action<string> handleMessage)
        {
            var buffer = new ArraySegment<byte>(new byte[1024]);
            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                    handleMessage(message);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    break;
                }
            }
        }

        [HttpGet]
        [Tegs.WebSocket]
        public async Task Get()
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await Receive(webSocket, async (string message) =>
            {
                var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Сервер получил: " + message));
                await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            });
        }
    }
}
