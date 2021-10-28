using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDesignExamples.NonCRUD.Order.CQS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDesignExamples.NonCRUD.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/<OrderController>
        [HttpGet("GetAllOrders")]
        public Task<IEnumerable<Order>> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<Order> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        // POST api/<OrderController>
        [HttpPost("CreateFromCart")]
        public async Task<Order> Post([FromBody] CreateOrderFromCartRequest request)
        {
            await _mediator.Send(new CreateOrderFromCartRequest {CartId = request.CartId, OrderId = request.OrderId});
            return await _mediator.Send(new GetOrderByIdQuery {Id = request.OrderId});
        }

        [HttpPost("{id}/AddCustomerInformation")]
        public async Task<Order> Post([FromBody] AddCustomerInfoToOrderRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id}/AddShippingInfo")]
        public async Task<Order> Post([FromBody] AddShippingInfoToOrderRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id}/CompleteOrder")]
        public async Task<ActionResult> CompleteOrder(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
