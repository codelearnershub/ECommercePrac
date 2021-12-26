using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities
{
    public class StoreBrand : BaseEntity
    {
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
