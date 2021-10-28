using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Product.CQS
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IDbConnectionFactory _dbFactory;

        public GetAllProductsQueryHandler(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dbFactory.Create();

            return await connection.QueryAsync<Product>("SELECT * FROM Product;");
        }
    }
}