using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        Product Create(Product product);
        Product Update(Product product);
        Product Get(int id);
        List<Product> GetAll();
        void Delete(Product product);
    }
}
