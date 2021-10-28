using System;

namespace ApiDesignExamples.NonCRUD.Cart.DataModel
{
    public record CartItemDto
    {
        public Guid CartId { get; init; }
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }
}