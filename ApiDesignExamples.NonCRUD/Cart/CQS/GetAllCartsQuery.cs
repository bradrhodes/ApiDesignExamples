using System.Collections.Generic;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Cart.CQS
{
    public class GetAllCartsQuery : IRequest<IEnumerable<Cart>>
    {
    }
}
