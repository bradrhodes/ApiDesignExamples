using System;

namespace ApiDesignExamples.CRUD.Product
{
    public record Product
    {
        public string Id { get; init; }
        public String Name { get; init; }
    }
}