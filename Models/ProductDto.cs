using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<BrandDto> Brands { get; set; } = new List<BrandDto>();
    }

    public class CreateProductRequestModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public List<int> Categories { get; set; } = new List<int>();
    }

    public class UpdateProductRequestModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public List<int> Categories { get; set; } = new List<int>();
    }

}
