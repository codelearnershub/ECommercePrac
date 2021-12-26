using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities
{
    public class OrderBrand : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
