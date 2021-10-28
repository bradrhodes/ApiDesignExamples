using System;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Cart.CQS
{
    public class RemoveItemFromCartCommand : IRequest<Unit>
    {
        public Guid CartId { get; init; }
        public Guid ItemId { get; init; }
    }
}