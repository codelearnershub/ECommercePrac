using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IRepositories
{
    public interface IOrderRepository
    {
        Order Create(Order order);
        Order Update(Order order);
        Order Get(int id);
        List<Order> GetAll();
        void Delete(Order order);
    }
}
