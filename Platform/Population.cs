using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
namespace FinalProject
{
    public class Population
    {
        public static async Task Endpoint(HttpContext context)
        {
            string city = context.Request.RouteValues["city"] as string ?? "washington";
            int? pop = null;
            switch (city.ToLower())
            {
                case "washington":
                        pop = 7_615_000;
                        break;
                    case "Canada":
                        pop = 8_419_000;
                        break;
                    case "san francisco":
                        pop = 870_000;
                        break;
                    case "miami":
                        pop = 454_000;
                        break;

                }
                if (pop.HasValue)
                {
                    await context.Response
                    .WriteAsync($"City: {city}, Population: {pop}");
            }
            else {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }
    }
}