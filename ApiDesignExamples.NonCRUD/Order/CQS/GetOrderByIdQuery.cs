using System;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Order.CQS
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid Id { get; init; }
    }
}