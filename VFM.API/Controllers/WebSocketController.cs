using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using VFM.Core.Interfaces;
using VFM.Core.Models;

namespace VFM.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebSocketController(IWebSocketHub webSocketHub) : Controller
    {
        private readonly IWebSocketHub webSocketHub = webSocketHub;

        private async Task Receive(WebSocketModel webSocket)
        {
            var buffer = new ArraySegment<byte>(new byte[1024]);
            WebSocket _webSocket = webSocket.WebSocket;
            while (_webSocket.State == WebSocketState.Open)
            {
                var result = await _webSocket.ReceiveAsync(buffer, webSocket.Token);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    await SendAsync(message);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    break;
                }
            }
        }

        private async Task SendAsync(WebSocketModel webSocket ,string message)
        {
            var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            await webSocket.WebSocket.SendAsync(buffer, WebSocketMessageType.Text, true, webSocket.Token);
        }

        [HttpGet]
        [Tegs.WebSocket]
        public async Task Get()
        {
            var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            ClaimsPrincipal user = HttpContext.User;
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid idG;

            if(!Guid.TryParse(id, out idG)) throw new Exception("Jwt токен не сожержит id");

            (WebSocketModel webSocketModel, string Error) = webSocketHub.RegisterNewWebSocket(idG, webSocket);

            if (webSocketModel == null) throw new Exception(Error);

            Receive(webSocketModel);
        }

        [HttpPost]
        public async Task SendMessage(Guid idWebSocket)
        {
            WebSocketModel webSocketModel = webSocketHub.GetConnectionWebSocket(idWebSocket);
        }
    }
}
