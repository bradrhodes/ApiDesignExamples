using System;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Product.CQS
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; init; }
    }
}