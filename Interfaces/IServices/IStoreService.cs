using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IServices
{
    public interface IStoreService
    {
        bool AddStore(CreateStoreRequestModel model);
        bool UpdateStore(int id, UpdateStoreRequestModel model);
        StoreDto GetStore(int id);
        IList<StoreDto> GetAllStores();
        bool DeleteStore(int id);
    }
}
