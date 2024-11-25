using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RestaurantsPresentation.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public TimeMiddleware(RequestDelegate next, ILogger<TimeMiddleware> logger)
        {

            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var sw = Stopwatch.StartNew();
            await _next(httpContext);
            sw.Stop();

            //if ( sw.ElapsedMilliseconds / 1000 > 0)
            //{
                _logger.LogInformation("the http verb {verb} at {path} takes longer than {milli} milliseconds",httpContext.Request.Method, httpContext.Request.Path, sw.ElapsedMilliseconds);
            //}
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}
