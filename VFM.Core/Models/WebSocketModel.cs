using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace VFM.Core.Models
{
    public class WebSocketModel
    {
        private readonly CancellationTokenSource cancellationTokenRegistration = new();
        private WebSocketModel(WebSocket webSocket)
        {
            ID = Guid.NewGuid();
            WebSocket = webSocket;
            Token = cancellationTokenRegistration.Token;
        }

        public Guid ID { get; set; }
        public WebSocket WebSocket { get; set; }
        public CancellationToken Token { get; set; }

        public static (WebSocketModel? WebSocket, string Error) Create(WebSocket webSocket)
        {
            if (webSocket == null) return (null, "Ошибка: WebSocket не может быть null");

            return (new WebSocketModel(webSocket), "");
        }
    }
}
