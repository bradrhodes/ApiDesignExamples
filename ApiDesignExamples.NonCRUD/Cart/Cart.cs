using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ApiDesignExamples.NonCRUD.Cart
{
    public record Cart
    {
        public Guid Id { get; init; }
        public IEnumerable<Item> Items { get; init; }
    }
}
