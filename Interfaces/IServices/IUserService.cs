using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IServices
{
    public interface IUserService
    {
        bool AddUser(CreateUserRequestModel model);
        bool UpdateUser(int id, UpdateUserRequestModel model);
        UserDto GetUser(int id);
        IList<UserDto> GetAllUsers();

        bool DeleteUser(int id);
        UserDto Login(string email, string password);
    }
}
