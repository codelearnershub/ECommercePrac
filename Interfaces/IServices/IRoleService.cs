using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IServices
{
    public interface IRoleService
    {
        bool AddRole(CreateRoleRequestModel model);
        bool UpdateRole(int id, UpdateRoleRequestModel model);
        RoleDto GetRole(int id);
        IList<RoleDto> GetAllRoles();

        bool DeleteRole(int id);
    }
}
