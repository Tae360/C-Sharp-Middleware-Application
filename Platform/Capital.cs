using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
namespace FinalProject
{
    public static class Capital
    {
        public static async Task Endpoint(HttpContext context)
        {
            string capital = null;
            string country = context.Request.RouteValues["country"] as string;
            switch ((country ?? "").ToLower())
            {
                case "us":
                    capital = "Washington";
                    break;
                case "canada":
                    capital = "Ottawa";
                    break;
                case "san francisco":
                    LinkGenerator generator =
                    context.RequestServices.GetService<LinkGenerator>();
                    string url = generator.GetPathByRouteValues(context,
                    "population", new { city = country });
                    context.Response.Redirect(url);
                    return;
            }
            if (capital != null)
            {
                await context.Response
                .WriteAsync($"{capital} is the capital of {country}");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }
    }
}