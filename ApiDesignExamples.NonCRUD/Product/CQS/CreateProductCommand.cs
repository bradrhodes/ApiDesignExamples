using System;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Product.CQS
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
    }
}
