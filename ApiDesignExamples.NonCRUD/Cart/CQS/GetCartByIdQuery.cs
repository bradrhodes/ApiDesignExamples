using System;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Cart.CQS
{
    public class GetCartByIdQuery : IRequest<Cart>
    {
        public Guid Id { get; init; }
    }
}