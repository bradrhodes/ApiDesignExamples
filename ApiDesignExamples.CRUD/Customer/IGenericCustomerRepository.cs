using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDesignExamples.CRUD.Customer
{
    public interface IGenericCustomerRepository
    {
        Task Create(Customer customer);
        Task<IEnumerable<Customer>> Get(Guid customerId);
        Task Update(Customer customer);
        Task Delete(Customer customer);
    }
}