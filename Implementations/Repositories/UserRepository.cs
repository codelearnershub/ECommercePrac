using ECommerce.Context;
using ECommerce.Entities;
using ECommerce.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User Get(int id)
        {
            return _context.Users.Include(a => a.UserRoles).ThenInclude(a => a.Role).SingleOrDefault(a =>a.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.Users.Include(a => a.UserRoles).ThenInclude(a => a.Role).ToList();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(a => a.Email == email);
        }

        public User Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
