namespace ApiDesignExamples.NonCRUD.Cart
{
    public record Item
    {
        public Product.Product Product { get; init; }
        public int Quantity { get; init; }
    }
}