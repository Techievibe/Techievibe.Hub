using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Techievibe.Hub.Common.Middlewares
{
    public class TracingMiddleware
    {
        private readonly RequestDelegate _next;

        public TracingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Gets invoked for every HTTP Request to set trace ID on the response.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            var headers = Activity.Current.Id;
            context.TraceIdentifier = Guid.NewGuid().ToString();
            string id = context.TraceIdentifier;
            context.Items["X-Trace-Id"] = id;
            context.Response.Headers["X-Trace-Id"] = id;
            await _next(context);
        }
    }
}
