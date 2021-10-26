using System;

namespace ApiDesignExamples.CRUD.Cart
{
    public record CartItem
    {
        public Guid CartId { get; init; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}