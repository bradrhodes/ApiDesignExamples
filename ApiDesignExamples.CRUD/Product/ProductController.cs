using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDesignExamples.CRUD.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericProductRepository _productRepository;

        public ProductController(IGenericProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        // GET: api/<ProductController>
        [HttpGet]
        public Task<IEnumerable<Product>> Get()
        {
            return _productRepository.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(Guid id)
        {
            var product = await _productRepository.Get(id).ConfigureAwait(false);

            return product.First();
        }

        // POST api/<ProductController>
        [HttpPost]
        public Task Post([FromBody] Product value)
        {
            return _productRepository.Create(value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public Task Put(Guid id, [FromBody] Product value)
        {
            return _productRepository.Update(value);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            return _productRepository.Delete(id);
        }
    }
}
