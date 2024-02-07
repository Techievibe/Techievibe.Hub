using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using Techievibe.Hub.Infrastructure.Datastore.Factories;
using Techievibe.Hub.Infrastructure.Datastore.Providers;
using Techievibe.Hub.Infrastructure.Datastore.Interfaces;
using Techievibe.Hub.Infrastructure.Datastore.Repositories;

namespace Techievibe.Hub.Infrastructure.ServiceRegistration
{
    public static class DataStoreRegistration
    {
        public static void AddSqlServerDependenciesForWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDataProvider<SqlConnection>, SqlDataProvider>();
            services.AddSingleton<IConnectionFactory<SqlConnection>, SqlConnectionFactory>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ICommonRepository, CommonRepository>();
        }
    }
}
