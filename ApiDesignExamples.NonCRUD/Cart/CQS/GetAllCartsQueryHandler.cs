using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApiDesignExamples.NonCRUD.Cart.DataModel;
using Dapper;
using MediatR;

namespace ApiDesignExamples.NonCRUD.Cart.CQS
{
    public class GetAllCartsQueryHandler : IRequestHandler<GetAllCartsQuery, IEnumerable<Cart>>
    {
        private readonly IDbConnectionFactory _dbFactory;

        public GetAllCartsQueryHandler(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task<IEnumerable<Cart>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dbFactory.Create();

            var cartItems = await connection.QueryAsync<CartItemDto>(
                "SELECT * FROM CartItems").ConfigureAwait(false);

            var products = await connection.QueryAsync<Product.Product>(
                "SELECT * FROM Product").ConfigureAwait(false);

            return cartItems
                .GroupBy(ci => ci.CartId)
                .Select(g => new Cart
                {
                    Id = g.Key,
                    Items = g.Select(ci => new Item
                    {
                        Product = new Product.Product
                        {
                            Id = ci.ProductId,
                            Name = products.FirstOrDefault(p => string.Equals(p.Id, ci.ProductId))?.Name,
                        },
                        Quantity = ci.Quantity
                    })
                });
        }
    }
}