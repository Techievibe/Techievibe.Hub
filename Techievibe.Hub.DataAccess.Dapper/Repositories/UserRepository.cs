using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techievibe.Hub.DataAccess.Dapper.Interfaces;
using System.Data.SqlClient;
using Techievibe.Hub.DataAccess.Core.Providers;
using Techievibe.Hub.DataAccess.Core.Factories;
using Techievibe.Hub.DataAccess.Dapper;
using Techievibe.Hub.Common.DataModels;
using Dapper;

namespace Techievibe.Hub.DataAccess.Dapper.Repositories
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
