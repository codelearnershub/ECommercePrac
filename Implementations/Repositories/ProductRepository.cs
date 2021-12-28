using ECommerce.Context;
using ECommerce.Entities;
using ECommerce.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Implementations.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product Get(int id)
        {
            return _context.Products.Include(a => a.ProductCategories)
                .ThenInclude(a => a.Category).SingleOrDefault(a => a.Id == id);
        }

        public List<Product> GetAll()
        {
            return _context.Products.Include(a => a.ProductCategories)
                .ThenInclude(a => a.Category).ToList();
        }

        public bool ProductExists(string productName)
        {
            return _context.Products.Any(a => a.ProductName == productName);
        }

        public Product Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}
