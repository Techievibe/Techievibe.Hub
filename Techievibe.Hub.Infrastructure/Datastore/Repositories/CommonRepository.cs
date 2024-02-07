using System.Data.SqlClient;
using Techievibe.Hub.Common;
using Techievibe.Hub.Infrastructure.Datastore.Factories;
using Techievibe.Hub.Infrastructure.Datastore.Interfaces;
using Techievibe.Hub.Infrastructure.Datastore.Providers;

namespace Techievibe.Hub.Infrastructure.Datastore.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly IDataProvider<SqlConnection> _dataProvider;
        private readonly IConnectionFactory<SqlConnection> _connectionFactory;
        public CommonRepository(IDataProvider<SqlConnection> dataProvider, IConnectionFactory<SqlConnection> connectionFactory)
        {
            _dataProvider = dataProvider;
            _connectionFactory = connectionFactory;

        }

        public bool CheckDbConnection()
        {
            using var mySqlConnection = _connectionFactory.CreateConnection();
            try
            {
                _dataProvider.OpenConnection(mySqlConnection);

                _dataProvider.CloseConnection(mySqlConnection);

            }
            catch (Exception ex)
            {
                throw new Techievibe.Hub.Common.Exceptions.TechievibeServerException(GlobalConstants.EXCEPTION_SQL_CHECKDBCONNECTION, ex);
            }

            return true;
        }
    }
}
