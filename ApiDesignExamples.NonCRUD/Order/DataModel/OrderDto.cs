using System;
using System.Collections.Generic;

namespace ApiDesignExamples.NonCRUD.Order.DataModel
{
    public abstract record OrderDto
    {
        public Guid Id { get; init; }

        public Guid CustomerId { get; init; }

        public Guid ShippingInfoId { get; init; }


        public record IncompleteOrderDto : OrderDto
        {
            public IEnumerable<string> Messages { get; init; }
        }

        public record ReadyOrderDto : OrderDto { }

        public record CompleteOrderDto : OrderDto { }
    }
}
