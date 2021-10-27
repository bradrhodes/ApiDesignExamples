using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDesignExamples.CRUD.ShippingInfo
{
    public interface IGenericShippingInfoRepository
    {
        Task Create(ShippingInfo shippingInfo);
        Task<IEnumerable<ShippingInfo>> Get(Guid shippingInfoId);
        Task Update(ShippingInfo shippingInfo);
        Task Delete(Guid shippingInfoId);
    }
}