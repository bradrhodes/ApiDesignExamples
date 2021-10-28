using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Order.CQS
{
    public class CreateOrderFromCartCommandHandler : IRequestHandler<CreateOrderFromCartCommand, Unit>
    {
        public Task<Unit> Handle(CreateOrderFromCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}