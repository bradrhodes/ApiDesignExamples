using System;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Cart.CQS
{
    public class AddItemToCartCommandHandler : IRequestHandler<AddItemToCartCommand, Unit>
    {
        private readonly IDbConnectionFactory _dbFactory;

        public AddItemToCartCommandHandler(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task<Unit> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
        {
            using var connection = _dbFactory.Create();

            await connection.ExecuteAsync(
                "INSERT INTO CartItems (CartId, ProductId, Quantity) " +
                "VALUES (@CartId, @ProductId, @Quantity) "+
                "ON CONFLICT(CartId, ProductId) DO UPDATE SET Quantity = @Quantity;", 
                new {
                    CartId = request.CardId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                }).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}