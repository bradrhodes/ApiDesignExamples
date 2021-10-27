using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDesignExamples.CRUD.Migrations;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ApiDesignExamples.CRUD.ShippingInfo
{
    public class ShippingInfoRepository : IGenericShippingInfoRepository
    {
        private readonly DatabaseConfig _config;

        public ShippingInfoRepository(DatabaseConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task Create(ShippingInfo shippingInfo)
        {
            await using var connection = GetConnection();

            await connection.ExecuteAsync(
                "INSERT OR IGNORE INTO ShippingInfo (Id, StreetAddress, PostalCode, Province)" +
                "VALUES (@Id, @StreetAddress, @PostalCode, @Province);", 
                shippingInfo).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ShippingInfo>> Get(Guid shippingInfoId)
        {
            await using var connection = GetConnection();

            return await connection.QueryAsync<ShippingInfo>(
                "SELECT * FROM ShippingInfo WHERE Id = @Id;", new {Id = shippingInfoId});
        }

        public async Task Update(ShippingInfo shippingInfo)
        {

            await using var connection = GetConnection();

            await connection.ExecuteAsync(
                "UPDATE ShippingInfo SET StreetAddress = @StreetAddress, " +
                "PostalCode = @PostalCode, Province = @Province " +
                "WHERE Id = @Id", 
                shippingInfo).ConfigureAwait(false);
        }

        public async Task Delete(Guid shippingInfoId)
        {
            await using var connection = GetConnection();

            await connection.ExecuteAsync(
                "DELECT FROM ShippingInfo " +
                "WHERE Id = @Id", 
                new {Id = shippingInfoId}).ConfigureAwait(false);
        }
        private SqliteConnection GetConnection()
        {
            return new SqliteConnection(_config.Name);
        }
    }
}