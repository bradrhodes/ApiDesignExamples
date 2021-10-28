using System;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Product.CQS
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IDbConnectionFactory _dbFactory;

        public GetProductByIdQueryHandler(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dbFactory.Create();
            return connection.QuerySingleAsync<Product>("SELECT * FROM Product WHERE Id = @Id;", request);
        }
    }
}