using System;

namespace ApiDesignExamples.NonCRUD.Order
{
    public record OrderItem  
    {
        public Guid ProductId { get; init; }
        public string Name { get; init; }
        protected int Quantity { get; init; }
    }
}