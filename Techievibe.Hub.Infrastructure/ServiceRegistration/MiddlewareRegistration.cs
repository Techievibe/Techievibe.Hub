using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Techievibe.Hub.Common.Middlewares;
using Techievibe.Hub.Infrastructure.Middlewares;

namespace Techievibe.Hub.Infrastructure.ServiceRegistration
{
    public static class MiddlewareRegistration
    {
        public static void AddAllMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseMiddleware<TracingMiddleware>();
        }

        public static void AddExceptionHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        public static void AddTracing(this IApplicationBuilder app)
        {
            app.UseMiddleware<TracingMiddleware>();
        }
    }
}
