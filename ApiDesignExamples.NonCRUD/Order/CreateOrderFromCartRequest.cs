using System;

namespace ApiDesignExamples.NonCRUD.Order
{
    public record CreateOrderFromCartRequest
    {
        public Guid OrderId { get; init; }
        public Guid CartId { get; init; }
    }
}