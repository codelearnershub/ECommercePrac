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
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationContext _context;

        public BrandRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool BrandExists(string brandName)
        {
            return _context.Brands.Any(a => a.BrandName == brandName);
           
        }

        public Brand Create(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return brand;
        }

        public void Delete(Brand brand)
        {
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }

        public Brand Get(int id)
        {
            return _context.Brands
                .Include(a => a.OrderBrands).ThenInclude(b => b.Order)
                .Include(a => a.StoreBrands).ThenInclude(c => c.Store)
                .Include(a => a.Product)
                .SingleOrDefault(d => d.Id == id);
        }

        public List<Brand> GetAll()
        {
            return _context.Brands
                .Include(a => a.OrderBrands).ThenInclude(b => b.Order)
                .Include(a => a.StoreBrands).ThenInclude(c => c.Store)
                .Include(a => a.Product).ToList();
        }

        public Brand GetByBrandName(string brandName)
        {
            return _context.Brands.SingleOrDefault(a => a.BrandName == brandName);

        }

        public IQueryable<Brand> Query<T>()
        {
            return _context.Brands.AsQueryable();
        }

        public Brand Update(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
            return brand;
        }
    }
}
