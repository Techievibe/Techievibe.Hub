using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SumoLogic.Logging.AspNetCore;
using Techievibe.Hub.Common.Middlewares;
using Techievibe.Hub.Infrastructure.Middlewares;
using Techievibe.Hub.Infrastructure.ServiceRegistration;
using Techievibe.Hub.Services.Common.Interfaces;
using Techievibe.Hub.Services.Common.Managers;
using Techievibe.Hub.Services.Common.Mappers;

namespace Techievibe.Hub.Services.ServiceRegistration
{
    public static class CommonRegistration
    {
        public static void AddAllServicesWithDependenciesForWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserManager, UserManager>();
            services.AddSingleton<ICommonManager, CommonManager>();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(typeof(UserMapper));
            });

            //Add Infrastructure Dependencies

            LoggerRegistration.AddSumoLogicLoggerForWeb(services, configuration);
            DataStoreRegistration.AddSqlServerDependenciesForWeb(services, configuration);
        }

        public static void AddAllMiddlewaresWithDependenciesForWeb(this IApplicationBuilder app)
        {
            MiddlewareRegistration.AddAllMiddlewares(app);
        }

        public static LoggerOptions GetSumoLogicLoggerOptions()
        {
           return LoggerRegistration.GetSumoLogicLoggerOptions();
        }
    }
}
