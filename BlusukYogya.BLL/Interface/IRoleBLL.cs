using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.BLL.DTO;
using BlusukYogya.Data;

namespace BlusukYogya.BLL.Interface
{
    public interface IRoleBLL
    {
        Task<IEnumerable<RoleDTO>> GetAllRoles();
        Task<Task> AddRole(RoleCreateDTO roleCreateDTO);
        Task<Task> AddUserToRole(int userId, int roleId);
    }
}
