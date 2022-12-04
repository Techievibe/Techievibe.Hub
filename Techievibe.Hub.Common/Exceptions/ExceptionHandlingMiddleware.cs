using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Techievibe.Hub.Common.ApiModels;
using Techievibe.Hub.Logging.Core;

namespace Techievibe.Hub.Common.Exceptions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISumoLogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ISumoLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            ApiResponse<string> response = null;
            List<string> Errors = new List<string>();

            if (exception.InnerException != null)
            {
                Errors.Add(exception.InnerException.Message);
                //Errors.AddRange(exception.InnerException.Errors);
            }
                
            else
                Errors.Add(exception.Message);

            if (exception is TechievibeException)
            {
                var ex = exception as TechievibeException;
                
                if (ex.Message.ToLower().Contains("bad request"))
                {
                    response = new ApiResponse<string>(null, 400, Errors);
                }
                else if (ex.Message.ToLower().Contains("invalid token"))
                {
                    response = new ApiResponse<string>(null, 401, Errors);
                }
                else if (ex.Message.ToLower().Contains("validation error"))
                {
                    response = new ApiResponse<string>(null, 400, Errors);
                }
            }
            else
            {
                response = new ApiResponse<string>(null, 500, Errors);
                _logger.LogError(exception.Message, exception);
            }
            if (response == null)
                response = new ApiResponse<string>(null, 500, Errors);
            var result = JsonConvert.SerializeObject(response);
            await context.Response.WriteAsync(result);

        }
    }
}
