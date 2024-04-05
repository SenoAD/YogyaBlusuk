using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Domain;

namespace BlusukYogya.Data.Interface
{
    public interface IRoleData : ICrudData<Role>
    {
        Task<Task> AddUserToRole(int userId, int roleId);
    }
}
