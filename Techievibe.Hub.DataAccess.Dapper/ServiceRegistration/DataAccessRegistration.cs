using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using Techievibe.Hub.DataAccess.Core.Factories;
using Techievibe.Hub.DataAccess.Core.Providers;
using Techievibe.Hub.DataAccess.Dapper.Interfaces;
using Techievibe.Hub.DataAccess.Dapper.Repositories;

namespace Techievibe.Hub.DataAccess.Dapper.ServiceRegistration
{
    public static class DataAccessRegistration
    {
        public static void AddSqlServerDependenciesForWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDataProvider<SqlConnection>, SqlDataProvider>();
            services.AddSingleton<IConnectionFactory<SqlConnection>, SqlConnectionFactory>();
            services.AddSingleton<IUserRepository, UserRepository>();
            //_loggerOptions = new LoggerOptions
            //{
            //    Uri = configuration[GlobalConstants.CONFIG_KEY_PREFIX + CommonConstants.Config.CONFIG_KEY_SUMOLOGIC_ENDPOINT]
            //};
        }
    }
}
