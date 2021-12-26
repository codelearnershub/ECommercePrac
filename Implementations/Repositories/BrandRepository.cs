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
            return _context.Brands.Find(id);
        }

        public List<Brand> GetAll()
        {
            return _context.Brands.ToList();
        }

        public Brand Update(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
            return brand;
        }
    }
}
