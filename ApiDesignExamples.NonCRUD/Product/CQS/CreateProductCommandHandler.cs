using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;

namespace ApiDesignExamples.NonCRUD.Product.CQS
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IDbConnectionFactory _dbFactory;

        public CreateProductCommandHandler(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            using var connection = _dbFactory.Create();

            await connection.ExecuteAsync("INSERT OR IGNORE INTO Product (Id, Name) " +
                                          "VALUES (@Id, @Name);", request).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
