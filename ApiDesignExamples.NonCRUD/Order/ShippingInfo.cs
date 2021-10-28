namespace ApiDesignExamples.NonCRUD.Order
{
    public record ShippingInfo
    {
        public string StreetAddress { get; init; }
        public string PostalCode { get; init; }
        public string Province { get; init; }
    }
}