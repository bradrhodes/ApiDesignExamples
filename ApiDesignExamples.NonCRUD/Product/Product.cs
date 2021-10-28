using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesignExamples.NonCRUD.Product
{
    public record Product
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
