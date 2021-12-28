using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IRepositories
{
    public interface IStoreRepository
    {
        Store Create(Store store);
        Store Update(Store store);
        Store Get(int id);
        List<Store> GetAll();
        void Delete(Store store);
        List<Store> GetSelectedStores(List<int> Ids);
    }
}
