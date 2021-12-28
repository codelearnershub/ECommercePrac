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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool CategoryExists(string categoryName)
        {
            return _context.Categories.Any(a => a.CategoryName == categoryName);
        }

        public Category Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public Category Get(int id)
        {
            return _context.Categories.Include(a => a.ProductCategories)
                 .ThenInclude(b => b.Product).ThenInclude(b => b.Brands).SingleOrDefault(a => a.Id == id);
        }

        public List<Category> GetAll()
        {
            return _context.Categories.Include(a => a.ProductCategories)
                .ThenInclude(b => b.Product).ThenInclude(b => b.Brands).ToList();
        }

        public IList<Category> GetSelectedCategories(List<int> ids)
        {
            return _context.Categories.Where(a => ids.Contains(a.Id)).ToList();
        }

        public Category Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }
    }
}
