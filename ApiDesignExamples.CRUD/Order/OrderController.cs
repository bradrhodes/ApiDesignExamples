using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDesignExamples.CRUD.Cart;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDesignExamples.CRUD.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IGenericOrderRepository _orderRepo;
        private readonly IGenericCartRepository _cartRepo;

        public OrderController(IGenericOrderRepository orderRepo, IGenericCartRepository cartRepo)
        {
            _orderRepo = orderRepo ?? throw new ArgumentNullException(nameof(orderRepo));
            _cartRepo = cartRepo ?? throw new ArgumentNullException(nameof(cartRepo));
        }
        // GET: api/<OrderController>
        [HttpGet]
        public Task<IEnumerable<Order>> Get()
        {
            return _orderRepo.GetAll();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<Order> Get(Guid id)
        {
            return (await _orderRepo.Get(id).ConfigureAwait(false)).First();
        }

        // POST api/<OrderController>
        [HttpPost("{cartId}")]
        public async Task Post(Guid cartId)
        {
            // Create the order
            await _orderRepo.Create(cartId, OrderState.Incomplete).ConfigureAwait(false);

            // Fetch the items from the cart
            var items = await _cartRepo.GetCartItemsById(cartId).ConfigureAwait(false);

            // Add the items to the order
            await items.Each(async item => await _orderRepo.AddItemToOrder(cartId, item.ProductId, item.Quantity)).ConfigureAwait(false);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public Task Put(Guid id, [FromBody] Order order)
        {
            return _orderRepo.Update(order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            return _orderRepo.Delete(id);
        }
    }
}
