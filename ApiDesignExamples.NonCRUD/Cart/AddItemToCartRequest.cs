using System;

namespace ApiDesignExamples.NonCRUD.Cart
{
    public record AddItemToCartRequest
    {
        public Guid CardId { get; init; }
        public Item Item { get; init; }
    }
}