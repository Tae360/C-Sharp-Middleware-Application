﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
namespace FinalProject
{
    public class QueryStringMiddleWare
    {
        private RequestDelegate? next;
        // ...statements omitted for brevity...
    }
    public class LocationMiddleware
    {
        private RequestDelegate next;
        private MessageOptions options;
        public LocationMiddleware(RequestDelegate nextDelegate,
        IOptions<MessageOptions> opts)
        {
            next = nextDelegate;
            options = opts.Value;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/location")
            {
                await context.Response
                .WriteAsync($"{options.StateName}, {options.CountyName}");
            }
            else
            {
                await next(context);
            }
        }
    }
}
