using System.Data.SqlClient;
using Techievibe.Hub.Common.DataModels;
using Dapper;
using Techievibe.Hub.Infrastructure.Datastore.Interfaces;
using Techievibe.Hub.Infrastructure.Datastore.Providers;
using Techievibe.Hub.Infrastructure.Datastore.Factories;

namespace Techievibe.Hub.Infrastructure.Datastore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataProvider<SqlConnection> _dataProvider;
        private readonly IConnectionFactory<SqlConnection> _connectionFactory;
        public UserRepository(IDataProvider<SqlConnection> dataProvider, IConnectionFactory<SqlConnection> connectionFactory)
        {
            _dataProvider = dataProvider;
            _connectionFactory = connectionFactory;

        }
        public Task<int> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var sql = "Select * FROM T_USR";
            using (var mySqlConnection = _connectionFactory.CreateConnection())
            { 
                _dataProvider.OpenConnection(mySqlConnection);

                var result = await mySqlConnection.QueryAsync<User>(sql);

                _dataProvider.CloseConnection(mySqlConnection);

                return result.ToList();

            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var sql = "Select * FROM T_USR WHERE USR_ID=@USR_ID";
            using (var mySqlConnection = _connectionFactory.CreateConnection())
            {
                _dataProvider.OpenConnection(mySqlConnection);

                var result = await mySqlConnection.QuerySingleOrDefaultAsync<User>(sql, new { USR_ID = id });

                _dataProvider.CloseConnection(mySqlConnection);

                return result;

            }
        }

        public Task<int> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
