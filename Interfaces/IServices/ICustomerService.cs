using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IServices
{
    public interface ICustomerService
    {
        bool AddCustomer(CreateCustomerRequestModel model);
        bool UpdateCustomer(int id, UpdateCustomerRequestModel model);
        CustomerDto GetCustomer(int id);
        IList<CustomerDto> GetAllCustomers();

        bool DeleteCustomer(int id);
        CustomerDto Login(string email, string password);
    }
}
