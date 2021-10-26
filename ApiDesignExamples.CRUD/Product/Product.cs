using System;

namespace ApiDesignExamples.CRUD.Product
{
    public record Product
    {
        public Guid Id { get; init; }
        public String Name { get; init; }
    }
}