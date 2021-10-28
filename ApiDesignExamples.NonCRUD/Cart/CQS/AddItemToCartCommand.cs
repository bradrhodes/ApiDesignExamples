using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Cart.CQS
{
    public class AddItemToCartCommand : IRequest<Unit>
    {
        public Guid CardId { get; init; }
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
