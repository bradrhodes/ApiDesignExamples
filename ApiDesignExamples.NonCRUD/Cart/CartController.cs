using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDesignExamples.NonCRUD.Cart.CQS;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDesignExamples.NonCRUD.Cart
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/<CartController>
        [HttpGet("GetAllCarts")]
        public Task<IEnumerable<Cart>> Get()
            => _mediator.Send(new GetAllCartsQuery());

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public Task<Cart> Get(Guid id)
            => _mediator.Send(new GetCartByIdQuery {Id = id});

        // POST api/<CartController>
        [HttpPost("AddItemToCart")]
        public Task AddItemToCart([FromBody] AddItemToCartRequest request)
            => _mediator.Send(new AddItemToCartCommand {CardId = request.CardId, ProductId = request.ProductId, Quantity = request.Quantity});

        // DELETE api/<CartController>/5
        [HttpDelete("{id}/RemoveItemFromCart/{itemId}")]
        public Task Delete(Guid id, Guid itemId)
            => _mediator.Send(new RemoveItemFromCartCommand {CartId = id, ItemId = itemId});

        [HttpPost("{id}/AdjustQuantityOfItem")]
        public Task AdjustQuantityOfItem(Guid id, [FromBody] AdjustQuantityOfItemRequest request)
            => _mediator.Send(new AdjustQuantityOfItemCommand
                {CartId = id, ProductId = request.ProductId, Quantity = request.Quantity});

    }

}
