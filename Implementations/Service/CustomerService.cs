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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public bool AddCustomer(CreateCustomerRequestModel model)
        {
            var customer = new Customer
            {
                IsDeleted = false,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                
            };
            _customerRepository.Create(customer);
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            var customer = _customerRepository.Get(id);
            _customerRepository.Delete(customer);
            return true;
        }

        public IList<CustomerDto> GetAllCustomers()
        {
            return _customerRepository.GetAll().Select(a => new CustomerDto
            {
               FirstName = a.FirstName,
               Address = a.Address,
               Email = a.Email,
               LastName = a.LastName,
               PhoneNumber = a.PhoneNumber,
               
               
                Id = a.Id,


            }).ToList();
        }

        public CustomerDto GetCustomer(int id)
        {
            var a = _customerRepository.Get(id);
            return new CustomerDto
            {

                FirstName = a.FirstName,
                Address = a.Address,
                Email = a.Email,
                LastName = a.LastName,
                PhoneNumber = a.PhoneNumber,


                Id = a.Id,

            };
        }

        public CustomerDto Login(string email, string password)
        {
            var customer = _customerRepository.GetByEmail(email);
            if (customer == null || customer.Password != password)
            {
                throw new Exception($"User email or password is invalid");
            }
            return new CustomerDto
            {
                FirstName = customer.FirstName,
                Address = customer.Address,
                Email = customer.Email,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Id = customer.Id,
              
            };
        }

        public bool UpdateCustomer(int id, UpdateCustomerRequestModel model)
        {
            var customer = _customerRepository.Get(id);
            customer.PhoneNumber = model.PhoneNumber;
            customer.Address = model.Address;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.PhoneNumber = model.PhoneNumber;
            

            _customerRepository.Update(customer);
            return true;
        }
    }
}
