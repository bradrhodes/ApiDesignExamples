using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Order.CQS
{
    public class CreateOrderFromCartCommand : IRequest<Unit>
    {
    }
}
