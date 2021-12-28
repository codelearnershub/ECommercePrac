using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IList<ProductDto> Products { get; set; } = new List<ProductDto>();
    }

    public class CreateCategoryRequestModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    public class UpdateCategoryRequestModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
