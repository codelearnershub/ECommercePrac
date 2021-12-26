using ECommerce.Context;
using ECommerce.Entities;
using ECommerce.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Implementations.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationContext _context;

        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Role Create(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }

        public void Delete(Role role)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }

        public Role Get(int id)
        {
            return _context.Roles.Find(id);
        }

        public List<Role> GetAll()
        {
            return _context.Rolles.ToList();
        }

        public Role Update(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;
        }
    }
}
