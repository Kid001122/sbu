namespace HodlSolution
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
    using System;
    using System.Threading.Tasks;

    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKey;

        public ApiKeyMiddleware(RequestDelegate next, string apiKey)
        {
            _next = next;
            _apiKey = apiKey;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("ApiKey", out StringValues apiKey) || apiKey != _apiKey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await _next.Invoke(context);
        }
    }
    }