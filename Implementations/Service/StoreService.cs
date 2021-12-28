using ECommerce.Entities;
using ECommerce.Interfaces.IRepositories;
using ECommerce.Interfaces.IServices;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Implementations.Service
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService( IStoreRepository storeRepository)
        {
           
            _storeRepository = storeRepository;
        }
        public bool AddStore(CreateStoreRequestModel model)
        {
        
            var store = new Store
            {
               StoreName = model.StoreName,
               Address = model.Address,
               Email = model.Email,
               PhoneNumber = model.PhoneNumber,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                IsDeleted = false,

            };
            _storeRepository.Create(store);
            return true;
        }

        public bool DeleteStore(int id)
        {
            var store = _storeRepository.Get(id);
            _storeRepository.Delete(store);
            return true;
        }

        public IList<StoreDto> GetAllStores()
        {
            return _storeRepository.GetAll().Select(a => new StoreDto
            {
               StoreName = a.StoreName,
               Address = a.Address,
               Email = a.Email,
               Id = a.Id,
               PhoneNumber = a.PhoneNumber
              
            }).ToList();
        }

        public StoreDto GetStore(int id)
        {
            var a = _storeRepository.Get(id);
            return new StoreDto
            {
                StoreName = a.StoreName,
                Address = a.Address,
                Email = a.Email,
                Id = a.Id,
                PhoneNumber = a.PhoneNumber
            };
        }

        public bool UpdateStore(int id, UpdateStoreRequestModel model)
        {
            var store = _storeRepository.Get(id);
            store.Email = model.Email;
            store.Address = model.Address;
            store.PhoneNumber = model.PhoneNumber;
            store.StoreName = model.StoreName;
            _storeRepository.Update(store);
            return true;
        }
    }
}
