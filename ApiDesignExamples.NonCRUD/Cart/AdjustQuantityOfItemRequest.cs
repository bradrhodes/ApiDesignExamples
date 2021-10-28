using System;

namespace ApiDesignExamples.NonCRUD.Cart
{
    public record AdjustQuantityOfItemRequest
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }
}