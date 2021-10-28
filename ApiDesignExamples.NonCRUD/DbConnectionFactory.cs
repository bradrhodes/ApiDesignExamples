using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ApiDesignExamples.NonCRUD.Migrations;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace ApiDesignExamples.NonCRUD
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }

    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly DatabaseConfig _config;

        public DbConnectionFactory(DatabaseConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public IDbConnection Create()
        {
            return new SqliteConnection(_config.Name);
        }
    }
}
