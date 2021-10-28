using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDesignExamples.CRUD.Order
{
    public interface IGenericOrderRepository
    {
        Task Create(Guid id, OrderState status);
        Task<IEnumerable<Order>> Get(Guid id);
        Task<IEnumerable<Order>> GetAll();
        Task Update(Order order);
        Task Delete(Guid id);
        Task AddItemToOrder(Guid id, Guid productId, int quantity);
        Task RemoveItemFromOrder(Guid cartId, Guid productId);
        Task<IEnumerable<OrderItem>> GetItemsInOrder(Guid orderId);
    }
}