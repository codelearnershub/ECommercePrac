using ECommerce.Entities;
using ECommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class BrandDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public BrandStatus BrandStatus { get; set; }
        public string BrandImage { get; set; }
        public List<StoreDto> Stores { get; set; } = new List<StoreDto>();
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }

    public class CreateBrandRequestModel
    {
        public int ProductId { get; set; }
        public string BrandName { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string BrandImage { get; set; }
    }

    public class UpdateBrandRequestModel
    {
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string BrandImage { get; set; }
    }


}
