using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDesignExamples.CRUD.Migrations;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ApiDesignExamples.CRUD.Cart
{
    class CartRepository : IGenericCartRepository
    {
        private readonly DatabaseConfig _config;

        public CartRepository(DatabaseConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task AddItemToCart(Guid id, Guid productId, int quantity)
        {
            await using var connection = new SqliteConnection(_config.Name);
            await connection.ExecuteAsync(
                "INSERT INTO CartItems (CartId, ProductId, Quantity) " +
                "VALUES (@CartId, @ProductId, @Quantity) "+
                "ON CONFLICT(CartId, ProductId) DO UPDATE SET Quantity = @Quantity;", 
                new {
                    CartId = id,
                    ProductId = productId,
                    Quantity = quantity
                }).ConfigureAwait(false);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsById(Guid id)
        {
            await using var connection = new SqliteConnection(_config.Name);
            return await connection.QueryAsync<CartItem>(
                "SELECT * FROM CartItems " + 
                "WHERE CartId = @CartId", new {CartId = id}).ConfigureAwait(false);
        }

        public async Task<IEnumerable<CartItem>> GetAllCartItems()
        {
            await using var connection = new SqliteConnection(_config.Name);
            return await connection.QueryAsync<CartItem>(
                "SELECT * FROM CartItems").ConfigureAwait(false);
        }

        public async Task RemoveItemFromCart(Guid cartId, Guid productId)
        {
            await using var connection = new SqliteConnection(_config.Name);
            await connection.ExecuteAsync(
                "DELETE FROM CartItems " +
                "WHERE CartId = @CartId AND ProductId = @ProductId",
                new {
                    CartId = cartId,
                    ProductId = productId
                }).ConfigureAwait(false);
        }

        public async Task DeleteCart(Guid cartId)
        {

            await using var connection = new SqliteConnection(_config.Name);
            await connection.ExecuteAsync(
                "DELETE FROM CartItems WHERE CartId = @CartId",
                new {
                    CartId = cartId,
                }).ConfigureAwait(false);
        }

        public Task AlterQuantity(Guid cartId, Guid productId, int newQuantity)
        {
            return AddItemToCart(cartId, productId, newQuantity);
        }
    }
}