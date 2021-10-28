using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDesignExamples.CRUD.Migrations;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ApiDesignExamples.CRUD.Order
{
    class OrderRepository : IGenericOrderRepository
    {
        private readonly DatabaseConfig _config;

        public OrderRepository(DatabaseConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task Create(Guid id, OrderState status)
        {
            await using var connection = GetConnection();

            await connection.ExecuteAsync(
                "INSERT OR IGNORE INTO Order (Id, Status)" +
                "VALUES (@Id, @Status);", 
                new {Id = id, Status = status.ToString()}).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Order>> Get(Guid id)
        {
            await using var connection = GetConnection();

            return await connection.QueryAsync<Order>(
                "SELECT * FROM Order WHERE Id = @Id;", new {Id = id});
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            await using var connection = GetConnection();

            return await connection.QueryAsync<Order>(
                "SELECT * FROM Order;");
        }

        // Note: Does this do what you'd expect it to?
        public async Task Update(Order order)
        {
            await using var connection = GetConnection();
            await connection.ExecuteAsync("UPDATE Order " +
                                          "SET CustomerId = @CustomerId, ShippingInfoId = @ShippingInfoId " +
                                          "WHERE Id = @Id", order);

        }

        public async Task Delete(Guid id)
        {
            await using var connection = GetConnection();
            await connection.ExecuteAsync("DELETE FROM Order WHERE Id = @id" , id);

        }

        public async Task AddItemToOrder(Guid id, Guid productId, int quantity)
        {
            await using var connection = new SqliteConnection(_config.Name);
            await connection.ExecuteAsync(
                "INSERT INTO OrderItems (OrderId, ProductId, Quantity) " +
                "VALUES (@OrderId, @ProductId, @Quantity) "+
                "ON CONFLICT(OrderId, ProductId) DO UPDATE SET Quantity = @Quantity;", 
                new {
                    CartId = id,
                    ProductId = productId,
                    Quantity = quantity
                }).ConfigureAwait(false);
        }

        public async Task RemoveItemFromOrder(Guid orderId, Guid productId)
        {
            await using var connection = new SqliteConnection(_config.Name);
            await connection.ExecuteAsync(
                "DELETE FROM OrderItems " +
                "WHERE OrderId = @OrderId AND ProductId = @ProductId",
                new {
                    OrderId = orderId,
                    ProductId = productId
                }).ConfigureAwait(false);
        }

        public async Task<IEnumerable<OrderItem>> GetItemsInOrder(Guid orderId)
        {
            await using var connection = new SqliteConnection(_config.Name);
            return await connection.QueryAsync<OrderItem>(
                "SELECT * FROM Orderitems " + 
                "WHERE OrderId = @OrderId", new {OrderId = orderId}).ConfigureAwait(false);
        }

        private SqliteConnection GetConnection()
        {
            return new SqliteConnection(_config.Name);
        }
    }
}