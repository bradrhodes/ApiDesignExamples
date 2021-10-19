using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDesignExamples.CRUD.Cart
{
    public interface IGenericCartRepository
    {
        Task AddItemToCart(string id, string productId, int quantity);

        Task<IEnumerable<CartItem>> GetCartItemsById(Guid id);

        Task<IEnumerable<CartItem>> GetAllCartItems();

        Task RemoveItemFromCart(Guid cartId, Guid productId);

        Task DeleteCart(Guid cartId);

        Task AlterQuantity(Guid cartId, Guid productId, int newQuantity);
    }
}