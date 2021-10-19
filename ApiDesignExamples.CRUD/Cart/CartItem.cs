namespace ApiDesignExamples.CRUD.Cart
{
    public record CartItem
    {
        public string CartId { get; init; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}