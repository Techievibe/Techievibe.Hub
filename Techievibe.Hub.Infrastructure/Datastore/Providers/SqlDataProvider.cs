using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techievibe.Hub.Infrastructure.Datastore.Factories;

namespace Techievibe.Hub.Infrastructure.Datastore.Providers
{
    public class SqlDataProvider : IDataProvider<SqlConnection>
    {
        private readonly IConnectionFactory<SqlConnection> _connectionFactory;
        public SqlDataProvider(IConnectionFactory<SqlConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public void CloseConnection(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("cannot close Sql connection, connection object is null.");

            if (connection.State == System.Data.ConnectionState.Closed)
                throw new InvalidOperationException("cannot close Sql connection, it is already closed.");

            connection.Close();
        }

        public ConnectionState GetConnectionState(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("cannot check Sql connection state, connection object is null.");

            return connection.State;

        }

        public void OpenConnection(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("cannot open Sql connection, connection object is null.");

            if (connection.State == System.Data.ConnectionState.Open)
                throw new InvalidOperationException("cannot open Sql connection, it is already open.");

            connection.Open();
        }


    }
}
