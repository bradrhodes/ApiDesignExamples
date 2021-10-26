using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDesignExamples.CRUD.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGenericCustomerRepository _customerRepository;

        public CustomerController(IGenericCustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public Task<IEnumerable<Customer>> Get()
        {
            return _customerRepository.GetAll();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(Guid id)
        {
            var customer = await _customerRepository.Get(id).ConfigureAwait(false);
            return customer.First();
        }

        // POST api/<CustomerController>
        [HttpPost]
        public Task Post([FromBody] Customer value)
        {
            return _customerRepository.Create(value);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public Task Put(Guid id, [FromBody] Customer value)
        {
            return _customerRepository.Update(value);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            return _customerRepository.Delete(id);
        }
    }
}
