using System;
using System.Linq;
using ApiDesignExamples.CRUD.Cart;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace ApiDesignExamples.CRUD.Order
{
    public record Order
    {
        public Guid Id { get; init; }

        public Guid CustomerId { get; init; }

        public Guid ShippingInfoId { get; init; }

        public OrderState Status { get; init; }

    }
}
