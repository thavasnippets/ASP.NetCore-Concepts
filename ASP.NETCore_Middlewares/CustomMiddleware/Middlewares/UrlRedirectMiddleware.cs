using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddleware.Middlewares
{
    public class UrlRedirectMiddleware
    {
        private readonly RequestDelegate next;
        public UrlRedirectMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            if(ctx.Request.Path == "/")
            {
                ctx.Request.Path = "/api/Sample";
            }
            await next.Invoke(ctx);
        }
    }
}
