using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Product.CQS
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
