using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDesignExamples.CRUD.Migrations;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ApiDesignExamples.CRUD.Product
{
    public class ProductRepository : IGenericProductRepository
    {
        private readonly DatabaseConfig _config;

        public ProductRepository(DatabaseConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task Create(Product product)
        {
            await using var connection = new SqliteConnection(_config.Name);
            await connection.ExecuteAsync("INSERT OR IGNORE INTO Product (Id, Name) " +
                                          "VALUES (@Id, @Name);", product);

        }

        public async Task<IEnumerable<Product>> Get(Guid id)
        {
            await using var connection = new SqliteConnection(_config.Name);

            return await connection.QueryAsync<Product>("SELECT * FROM Product WHERE Id = @Id;", id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            await using var connection = new SqliteConnection(_config.Name);

            return await connection.QueryAsync<Product>("SELECT * FROM Product;");
        }
        public async Task Update(Product product)
        {
            await using var connection = new SqliteConnection(_config.Name);
            await connection.ExecuteAsync("UPDATE Product SET Name = @Name WHERE Id = @Id", product);
        }

        public async Task Delete(Guid id)
        {
            await using var connection = new SqliteConnection(_config.Name);
            await connection.ExecuteAsync("DELETE FROM Product WHERE Id = @Id", new {Id = id});
        }
    }
}