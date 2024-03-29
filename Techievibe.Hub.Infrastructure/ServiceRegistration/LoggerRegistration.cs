﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SumoLogic.Logging.AspNetCore;
using Techievibe.Hub.Infrastructure.Logging;

namespace Techievibe.Hub.Infrastructure.ServiceRegistration
{
    public static class LoggerRegistration
    {
        private static LoggerOptions _loggerOptions { get; set; }
        public static void AddSumoLogicLoggerForWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISumoLogger, SumoLogger>();
            _loggerOptions = new LoggerOptions
            {
                Uri = configuration["Techievibe_SumoLogicEndpoint"]
            };
        }

        public static LoggerOptions GetSumoLogicLoggerOptions()
        {
            if (_loggerOptions == null)
                throw new ArgumentNullException("LoggerOptions value cannot be null.");

            return _loggerOptions;
        }
    }
}
