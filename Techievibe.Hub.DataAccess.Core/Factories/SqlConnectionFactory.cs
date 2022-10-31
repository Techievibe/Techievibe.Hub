﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techievibe.Hub.Common;

namespace Techievibe.Hub.DataAccess.Core.Factories
{
    public class SqlConnectionFactory : IConnectionFactory<SqlConnection>
    {
        private string _connectionString;
        private readonly IConfiguration _configuration;
        private SqlConnection _sqlConnection;
        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection CreateConnection()
        {
            if (_connectionString == null)
            {
                if (string.IsNullOrEmpty(_connectionString))
                    GetConnectionString();
            }

            _sqlConnection = new SqlConnection(_connectionString);

            return _sqlConnection;
        }

        public string GetConnectionString()
        {
            _connectionString = _configuration[GlobalConstants.CONFIG_KEY_PREFIX + CommonConstants.Config.CONFIG_KEY_SQLSERVER_CONNECTIONSTRING];

            return _connectionString;
        }

        public SqlConnection GetExistingConnection()
        {
            if (_sqlConnection == null)
                throw new Exception("No existing connection available");
            return _sqlConnection;
        }
    }
}
