using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDesignExamples.CRUD.Migrations;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ApiDesignExamples.CRUD.Customer
{
    public class CustomerRepository: IGenericCustomerRepository
    {
        private readonly DatabaseConfig _config;

        public CustomerRepository(DatabaseConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task Create(Customer customer)
        {
            await using var connection = GetConnection();

            await connection.ExecuteAsync(
                "INSERT OR IGNORE INTO Customer (Id, FirstName, LastName)" +
                "VALUES (@Id, @FirstName, @LastName);", 
                customer).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Customer>> Get(Guid customerId)
        {
            await using var connection = GetConnection();

            return await connection.QueryAsync<Customer>(
                "SELECT * FROM Customer WHERE Id = @Id;", new {Id = customerId});
        }

        public async Task Update(Customer customer)
        {
            await using var connection = GetConnection();

            await connection.ExecuteAsync(
                "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName " +
                "WHERE Id = @Id", 
                customer).ConfigureAwait(false);
        }

        public async Task Delete(Customer customer)
        {
            await using var connection = GetConnection();

            await connection.ExecuteAsync(
                "DELECT FROM Customer " +
                "WHERE Id = @Id", 
                customer).ConfigureAwait(false);
        }

        private SqliteConnection GetConnection()
        {
            return new SqliteConnection(_config.Name);
        }
    }
}
