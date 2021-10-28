namespace ApiDesignExamples.NonCRUD.Order
{
    public record AddShippingInfoToOrderRequest
    {
        public string StreetAddress { get; init; }

        public string PostalCode { get; init; }

        public string Province { get; init; }
    }
}