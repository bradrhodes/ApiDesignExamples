using System;
using System.Linq;

namespace ApiDesignExamples.CRUD.ShippingInfo
{
    public record ShippingInfo
    {
        public Guid Id { get; init; }
        public string StreetAddress { get; init; }
        public string PostalCode { get; init; }
        public string Province { get; init; }
    }
}
