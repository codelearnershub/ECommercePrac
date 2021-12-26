using ECommerce.Context;
using ECommerce.Entities;
using ECommerce.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Implementations.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ApplicationContext _context;

        public StoreRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Store Create(Store store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();
            return store;
        }

        public void Delete(Store store)
        {
            _context.Stores.Remove(store);
            _context.SaveChanges();
        }

        public Store Get(int id)
        {
            return _context.Stores.Find(id);
        }

        public List<Store> GetAll()
        {
            return _context.Stores.ToList();
        }

        public Store Update(Store store)
        {
            _context.Stores.Update(store);
            _context.SaveChanges();
            return store;
        }
    }
}
