namespace ApiDesignExamples.CRUD.Customer
{
    public record Customer
    {
        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}