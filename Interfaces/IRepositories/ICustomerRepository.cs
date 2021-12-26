using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IRepositories
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        Customer Update(Customer customer);
        Customer Get(int id);
        List<Customer> GetAll();
        void Delete(Customer customer);
    }
}
