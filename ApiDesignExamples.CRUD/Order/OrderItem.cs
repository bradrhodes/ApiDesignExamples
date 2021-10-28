using System;

namespace ApiDesignExamples.CRUD.Order
{
    public record OrderItem  
    {
        public Guid OrderId { get; init; }
        public Guid ProductId { get; init; }
        protected int Quantity { get; init; }
    }
}