using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IRepositories
{
    public interface IRoleRepository
    {
        Role Create(Role role);
        Role Update(Role role);
        Role Get(int id);
        List<Role> GetAll();
        void Delete(Role role);
        IList<Role> GetSelectedRoles(List<int> ids);
    }
}
