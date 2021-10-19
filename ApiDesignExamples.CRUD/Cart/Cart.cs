using System.Collections.Generic;

namespace ApiDesignExamples.CRUD.Cart
{
    public record Cart
    {
        public string Id { get; init; }

        public IEnumerable<Item> Items { get; init; }
    }
}