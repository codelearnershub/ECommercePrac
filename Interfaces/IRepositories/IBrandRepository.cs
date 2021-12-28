using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IRepositories
{
    public interface IBrandRepository
    {
        Brand Create(Brand brand);
        Brand Update(Brand brand);
        Brand Get(int id);
        List<Brand> GetAll();
        void Delete(Brand brand);
        Brand GetByBrandName(string brandName);
        bool BrandExists(string brandName);
        IQueryable<Brand> Query<T>();
    }
}
