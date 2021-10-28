using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Order.CQS
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}