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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        

        public UserService(IUserRepository userRepository , IRoleRepository roleRepository)
        {

            _userRepository = userRepository;
            _roleRepository = roleRepository;

        }
        public bool AddUser(CreateUserRequestModel model)
        {

            var user = new User
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
                StoreId = model.StoreId,
               

            };

            var roles = _roleRepository.GetSelectedRoles(model.Roles);
            foreach(var store in roles)
            {
                var userRole = new UserRole
                {
                    Role = store,
                    RoleId = store.Id,
                    User = user,
                    UserId = user.Id,
                };
                user.UserRoles.Add(userRole);
            }
            _userRepository.Create(user);
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = _userRepository.Get(id);
            _userRepository.Delete(user);
            return true;
        }

        public IList<UserDto> GetAllUsers()
        {
            return _userRepository.GetAll().Select(a => new UserDto
            {
                FirstName = a.FirstName,
                Address = a.Address,
                Email = a.Email,
                LastName = a.LastName,
                PhoneNumber = a.PhoneNumber,
                Id = a.Id,
                Roles = a.UserRoles.Select(b => new RoleDto
                {
                    Id = b.Role.Id,
                    Name = b.Role.Name
                }).ToList()


            }).ToList();
        }

        public UserDto GetUser(int id)
        {
            var user = _userRepository.Get(id);
            return new UserDto
            {
                FirstName = user.FirstName,
                Address = user.Address,
                Email = user.Email,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id,
                Roles = user.UserRoles.Select(b => new RoleDto
                {
                    Id = b.Role.Id,
                    Name = b.Role.Name
                }).ToList()
            };
        }

        public UserDto Login(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);
            if(user == null || user.Password != password)
            {
                return null;
            }
            return new UserDto
            {
                FirstName = user.FirstName,
                Address = user.Address,
                Email = user.Email,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id,
                Roles = user.UserRoles.Select(b => new RoleDto
                {
                    Id = b.Role.Id,
                    Name = b.Role.Name
                }).ToList()
            };

        }

        public bool UpdateUser(int id, UpdateUserRequestModel model)
        {
            var customer = _userRepository.Get(id);
            customer.PhoneNumber = model.PhoneNumber;
            customer.Address = model.Address;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.PhoneNumber = model.PhoneNumber;


            _userRepository.Update(customer);
            return true;
        }
    }
}
