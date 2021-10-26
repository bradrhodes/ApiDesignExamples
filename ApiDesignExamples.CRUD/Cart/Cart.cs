using System;
using System.Collections.Generic;

namespace ApiDesignExamples.CRUD.Cart
{
    public record Cart
    {
        public Guid Id { get; init; }

        public IEnumerable<Item> Items { get; init; }
    }
}