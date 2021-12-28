using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        User Create(User user);
        User Update(User user);
        User Get(int id);
        List<User> GetAll();
        void Delete(User user);
        User GetByEmail(string email);
    }
}
