namespace ApiDesignExamples.NonCRUD.Order
{
    public record AddCustomerInfoToOrderRequest
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}