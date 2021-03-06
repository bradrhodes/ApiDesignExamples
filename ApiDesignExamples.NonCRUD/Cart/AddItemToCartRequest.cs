using System;

namespace ApiDesignExamples.NonCRUD.Cart
{
    public record AddItemToCartRequest
    {
        public Guid CardId { get; init; }
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }
}