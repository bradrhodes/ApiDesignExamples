using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesignExamples.CRUD.Cart
{
    public class Item
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
