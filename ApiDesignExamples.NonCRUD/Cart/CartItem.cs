using System;

namespace ApiDesignExamples.NonCRUD.Cart
{
    public record CartItem
    {
        public Guid CartId { get; init; }
        public Product.Product Product { get; init; }
        public int Quantity { get; init; }
    }
}