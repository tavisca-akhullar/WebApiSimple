using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "App.config")]
namespace MyApi.MiddleWare
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _log.Info($"Calling {httpContext.Request.Method} in Url {httpContext.Request.Path}");
            await _next(httpContext);
            _log.Info($"Response Received with status code {httpContext.Response.StatusCode}");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
