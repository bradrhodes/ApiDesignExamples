using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDesignExamples.CRUD.Product
{
    public interface IGenericProductRepository
    {
        Task Create(Product product);
        Task<IEnumerable<Product>> Get(Guid id);
        Task<IEnumerable<Product>> GetAll();
        Task Update(Product product);
        Task Delete(Guid id);
    }
}