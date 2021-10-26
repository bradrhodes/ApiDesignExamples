using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDesignExamples.CRUD.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDesignExamples.CRUD.Cart
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IGenericCartRepository _cartRepository;
        private readonly IGenericProductRepository _productRepository;


        public CartController(IGenericCartRepository cartRepository, IGenericProductRepository productRepository)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        
        // GET: api/<CartController>
        [HttpGet]
        public async Task<IEnumerable<Cart>> Get()
        {
            var cartItems = await _cartRepository.GetAllCartItems().ConfigureAwait(false);
            var products = await _productRepository.GetAll().ConfigureAwait(false);

            return cartItems
                .GroupBy(ci => ci.CartId)
                .Select(g => new Cart
                {
                    Id = g.Key,
                    Items = g.Select(source => new Item
                    {
                        ProductId = source.ProductId,
                        ProductName = products.FirstOrDefault(p => string.Equals(p.Id, source.ProductId))?.Name,
                        Quantity = source.Quantity
                    })
                });
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public async Task<Cart> Get(Guid id)
        {

            var cartItems = await _cartRepository.GetCartItemsById(id).ConfigureAwait(false);
            var products = await _productRepository.GetAll().ConfigureAwait(false);

            return cartItems
                .GroupBy(ci => ci.CartId)
                .Select(g => new Cart
                {
                    Id = g.Key,
                    Items = g.Select(source => new Item
                    {
                        ProductId = source.ProductId,
                        ProductName = products.FirstOrDefault(p => string.Equals(p.Id, source.ProductId))?.Name,
                        Quantity = source.Quantity
                    })
                }).First();
        }

        // POST api/<CartController>
        [HttpPost]
        public async Task Post([FromBody] Cart value)
        {
            foreach (var item in value.Items)
            {
                await _cartRepository.AddItemToCart(value.Id, item.ProductId, item.Quantity);
            }
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] Cart value)
        {
            await _cartRepository.DeleteCart(id).ConfigureAwait(false);

            foreach (var item in value.Items)
            {
                await _cartRepository.AddItemToCart(value.Id, item.ProductId, item.Quantity);
            }
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            return _cartRepository.DeleteCart(id);
        }

        [HttpPost("{id}/Items")]
        public Task AddItem(Guid id, [FromBody] Item item)
        {
            return _cartRepository.AddItemToCart(id, item.ProductId, item.Quantity);
        }

        [HttpDelete("{id}/Items/{itemId}")]
        public Task RemoveItem(Guid id, Guid itemId)
        {
            return _cartRepository.RemoveItemFromCart(id, itemId);
        }

    }
}
