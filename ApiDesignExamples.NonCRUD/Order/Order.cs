using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ApiDesignExamples.NonCRUD.Order
{
    public record Order
    {
        public Guid Id { get; init; }

        public IEnumerable<OrderItem> Items { get; init; }

        public CustomerInfo Customer { get; init; }

        public ShippingInfo ShippingInfo { get; init; }
    }
}
