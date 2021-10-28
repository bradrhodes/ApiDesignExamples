using System;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using SQLitePCL;

namespace ApiDesignExamples.NonCRUD.Cart.CQS
{
    public class RemoveItemFromCartCommandHandler : IRequestHandler<RemoveItemFromCartCommand, Unit>
    {
        private readonly IDbConnectionFactory _dbFactory;

        public RemoveItemFromCartCommandHandler(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task<Unit> Handle(RemoveItemFromCartCommand request, CancellationToken cancellationToken)
        {
            using var connection = _dbFactory.Create();

            await connection.ExecuteAsync(
                "DELETE FROM CartItems " +
                "WHERE CartId = @CartId AND ProductId = @ProductId",
                new {
                    CartId = request.CartId,
                    ProductId = request.ItemId
                }).ConfigureAwait(false);

            return Unit.Value;
        }
    }

    public class AdjustQuantityOfItemCommand : IRequest<Unit>
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }

    public class AdjustQuantityOfItemCommandHandler : IRequestHandler<AdjustQuantityOfItemCommand, Unit>
    {
        private readonly IDbConnectionFactory _dbFactory;

        public AdjustQuantityOfItemCommandHandler(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }
        public async Task<Unit> Handle(AdjustQuantityOfItemCommand request, CancellationToken cancellationToken)
        {
            using var connection = _dbFactory.Create();

            await connection.ExecuteAsync(
                "INSERT INTO CartItems (CartId, ProductId, Quantity) " +
                "VALUES (@CartId, @ProductId, @Quantity) "+
                "ON CONFLICT(CartId, ProductId) DO UPDATE SET Quantity = @Quantity;", 
                new {
                    CartId = request.CartId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                }).ConfigureAwait(false);
            return Unit.Value;
        }
    }
}