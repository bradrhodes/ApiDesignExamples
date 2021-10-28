using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApiDesignExamples.NonCRUD.Cart.DataModel;
using Dapper;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Cart.CQS
{
    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, Cart>
    {
        private readonly IDbConnectionFactory _dbFactory;

        public GetCartByIdQueryHandler(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task<Cart> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dbFactory.Create();

            var cartItems = await connection.QueryAsync<CartItemDto>(
                "SELECT * FROM CartItems WHERE CartId = @CartId", new {CartId = request.Id}).ConfigureAwait(false);

            var products = await connection.QueryAsync<Product.Product>(
                "SELECT * FROM Product").ConfigureAwait(false);

            return new Cart
            {
                Id = request.Id,
                Items = cartItems.Select(ci => new Item
                {
                    Product = new Product.Product
                    {
                        Id = ci.ProductId,
                        Name = products.FirstOrDefault(p => p.Id.Equals(ci.ProductId))?.Name
                    },
                    Quantity = ci.Quantity
                })
            };
        }
    }
}