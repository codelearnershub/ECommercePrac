using ECommerce.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Entities
{
    public class Brand : BaseEntity 
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string BrandName { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public BrandStatus BrandStatus { get; set; }
        public string BrandImage { get; set; }
        public ICollection<StoreBrand> StoreBrands { get; set; } = new List<StoreBrand>();
        public ICollection<OrderBrand> OrderBrands { get; set; } = new List<OrderBrand>();

    }
}
