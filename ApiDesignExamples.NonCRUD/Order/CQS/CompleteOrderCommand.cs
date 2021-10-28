using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Order.CQS
{
    public class CompleteOrderCommand : IRequest<IEnumerable<string>>
    {
    }

    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand, IEnumerable<string>>
    {
        public Task<IEnumerable<string>> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
