using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VFM.API.Tegs
{
    public class WebSocket : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.HttpContext.WebSockets.IsWebSocketRequest)
                context.HttpContext.Response.StatusCode = 400;

            base.OnResultExecuting(context);
        }
    }
}
