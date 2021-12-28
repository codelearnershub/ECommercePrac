using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IServices
{
    public interface IProductService
    {

        bool AddProduct(CreateProductRequestModel model);
        bool UpdateProduct(int id, UpdateProductRequestModel model);
        ProductDto Get(int id);
        IList<ProductDto> GetAllProducts();
      
        bool DeleteProduct(int id);
    }
}
