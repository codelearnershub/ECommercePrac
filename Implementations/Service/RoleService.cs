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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public bool AddRole(CreateRoleRequestModel model)
        {
            var role = new Role
            {
                IsDeleted = false,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Description = model.Description,
                Name = model.Name
            };
            _roleRepository.Create(role);
            return true;
        }

        public bool DeleteRole(int id)
        {
            var role = _roleRepository.Get(id);
            _roleRepository.Delete(role);
            return true;
        }

        public IList<RoleDto> GetAllRoles()
        {
            return _roleRepository.GetAll().Select(a => new RoleDto
            {
                Name = a.Name,
                Description = a.Description,
                Id = a.Id,
              

            }).ToList();
        }

        public RoleDto GetRole(int id)
        {
            var role = _roleRepository.Get(id);
            return new RoleDto
            {

                Name = role.Name,
                Description = role.Description,
                Id = role.Id,
              
            };
        }

        public bool UpdateRole(int id, UpdateRoleRequestModel model)
        {
            var role = _roleRepository.Get(id);
            role.Description = model.Description;
            role.Name = model.Name;
            _roleRepository.Update(role);
            return true;
        }
    }
}
