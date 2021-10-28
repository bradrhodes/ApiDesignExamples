using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Cart.CQS
{
    public class AddItemToCartCommand : IRequest<Unit>
    {
        public Guid CardId { get; init; }
        public Item Item { get; init; }
    }

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
                    ProductId = request.Item.Product.Id,
                    Quantity = request.Item.Quantity
                }).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
