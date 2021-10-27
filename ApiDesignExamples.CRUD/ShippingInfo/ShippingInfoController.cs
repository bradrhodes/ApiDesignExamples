using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDesignExamples.CRUD.ShippingInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingInfoController : ControllerBase
    {
        private readonly IGenericShippingInfoRepository _shippingInfoRepository;

        public ShippingInfoController(IGenericShippingInfoRepository shippingInfoRepository)
        {
            _shippingInfoRepository = shippingInfoRepository ?? throw new ArgumentNullException(nameof(shippingInfoRepository));
        }

        // GET api/<ShippingInfoController>/5
        [HttpGet("{id}")]
        public async Task<ShippingInfo> Get(Guid id)
        {
            var shippingInfos = await _shippingInfoRepository.Get(id).ConfigureAwait(false);
            return shippingInfos.First();
        }

        // POST api/<ShippingInfoController>
        [HttpPost]
        public Task Post([FromBody] ShippingInfo value)
        {
            return _shippingInfoRepository.Create(value);
        }

        // PUT api/<ShippingInfoController>/5
        [HttpPut("{id}")]
        public Task Put(Guid id, [FromBody] ShippingInfo value)
        {
            return _shippingInfoRepository.Update(value);
        }

        // DELETE api/<ShippingInfoController>/5
        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            return _shippingInfoRepository.Delete(id);
        }
    }
}
